using AutoMapper;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Models;
using CPMS.Application.Users.Queries.Dtos;
using CPMS.Domain.Enums;
using CPMS.Domain.IdentityEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CPMS.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UserDto>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile? ProfilePhoto { get; set; }
    public DateTime Birthdate { get; set; }
    
    public long IdentificationNumber { get; set; }
    public Gender Gender { get; set; }
    
    public class Handler : IRequestHandler<UpdateUserCommand,UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public Handler(UserManager<User> userManager, IFileService fileService, ICurrentUserService currentUserService, IMapper mapper)
        {
            _userManager = userManager;
            _fileService = fileService;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UserDto result = null;

            User? user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Birthdate = request.Birthdate;
                user.Gender = request.Gender;
                user.IdentificationNumber = request.IdentificationNumber;

                if (request.ProfilePhoto != null)
                {
                    user.ProfilePhoto = _fileService.UploadPhoto(request.ProfilePhoto,PhotoPaths.UserProfilePhotoPath);
                }
                
                await _userManager.UpdateAsync(user);

                result = _mapper.Map<UserDto>(user);
            }

            return result;
        }
    }
}