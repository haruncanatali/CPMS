using CPMS.Domain.Entities;
using CPMS.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<ParkingLot> ParkingLots { get; set; }
    public DbSet<ParkingService> ParkingServices { get; set; }
    public DbSet<ParkPrice> ParkPrices { get; set; }
    public DbSet<ServicePrice> ServicePrices { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}