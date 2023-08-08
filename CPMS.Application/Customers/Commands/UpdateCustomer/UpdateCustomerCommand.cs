using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Models;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string IdentificationNumber { get; set; }
    public string DriverLicenseNumber { get; set; }
    public IFormFile? ProfilePhoto { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    
    public class Handler : IRequestHandler<UpdateCustomerCommand,Unit>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer? customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (customer != null)
            {
                customer.Email = request.Email;
                customer.Password = request.Password;
                customer.Name = request.Name;
                customer.Surname = request.Surname;
                customer.IdentificationNumber = request.IdentificationNumber;
                customer.Phone = request.Phone;
                customer.Gender = request.Gender;

                if (request.ProfilePhoto != null)
                {
                    customer.ProfilePhoto =
                        _fileService.UploadPhoto(request.ProfilePhoto, PhotoPaths.CustomerImagePath);
                }

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}