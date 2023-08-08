using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Models;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CPMS.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<Unit>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdentificationNumber { get; set; }
    public string DriverLicenseNumber { get; set; }
    public IFormFile ProfilePhoto { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    
    public class Handler : IRequestHandler<CreateCustomerCommand,Unit>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                Surname = request.Surname,
                IdentificationNumber = request.IdentificationNumber,
                DriverLicenseNumber = request.DriverLicenseNumber,
                ProfilePhoto = _fileService.UploadPhoto(request.ProfilePhoto,PhotoPaths.CustomerImagePath),
                Gender = request.Gender,
                Phone = request.Phone
            };
            
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}