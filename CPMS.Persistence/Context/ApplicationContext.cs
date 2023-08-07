using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Base;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using CPMS.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Persistence.Context;

public class ApplicationContext: IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
        UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>,
    IApplicationContext
{
    private readonly ICurrentUserService _currentUserService;

    public ApplicationContext(DbContextOptions<ApplicationContext> options, ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
    }
    
    #region Identity User Tables

    public DbSet<User> Users
    {
        get { return base.Users; }
        set { }
    }

    public DbSet<Role> Roles
    {
        get { return base.Roles; }
        set { }
    }

    public DbSet<UserRole> UserRoles
    {
        get { return base.UserRoles; }
        set { }
    }

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

    #endregion


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if(_currentUserService!= null)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.EntityStatus = EntityStatus.Active;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = _currentUserService.UserId;
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.EntityStatus = EntityStatus.Passive;
                        break;
                }
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        base.OnModelCreating(builder);
    }
}