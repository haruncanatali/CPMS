using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Models;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Vehicles.Commands.UpdateVehicle;

public class UpdateVehicleCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Plate { get; set; }
    public string Color { get; set; }
    public bool LPG { get; set; }
    public IFormFile? VehiclePhoto { get; set; }
    public long CustomerId { get; set; }
    public long ModelId { get; set; }
    
    public class Handler : IRequestHandler<UpdateVehicleCommand,Unit>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            Vehicle? vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (vehicle != null)
            {
                vehicle.Plate = request.Plate;
                vehicle.Color = request.Color;
                vehicle.LPG = request.LPG;
                vehicle.CustomerId = request.CustomerId;
                vehicle.ModelId = request.ModelId;

                if (request.VehiclePhoto != null)
                {
                    vehicle.VehiclePhoto = _fileService.UploadPhoto(request.VehiclePhoto, PhotoPaths.VehicleImagePath);
                }

                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}