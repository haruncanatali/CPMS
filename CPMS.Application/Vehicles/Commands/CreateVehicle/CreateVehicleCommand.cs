using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Models;
using CPMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CPMS.Application.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommand : IRequest<Unit>
{
    public string Plate { get; set; }
    public string Color { get; set; }
    public bool LPG { get; set; }
    public IFormFile VehiclePhoto { get; set; }
    public long CustomerId { get; set; }
    public long ModelId { get; set; }
    
    public class Handler : IRequestHandler<CreateVehicleCommand,Unit>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            Vehicle vehicle = new Vehicle
            {
                Plate = request.Plate,
                Color = request.Color,
                LPG = request.LPG,
                CustomerId = request.CustomerId,
                ModelId = request.ModelId,
                VehiclePhoto = _fileService.UploadPhoto(request.VehiclePhoto,PhotoPaths.VehicleImagePath)
            };

            await _context.Vehicles.AddAsync(vehicle, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}