using DotNetCoreAngularApp.DataAccess.Configurations;
using DotNetCoreAngularApp.DataAccess.Entities.Settings;
using DotNetCoreAngularApp.DataAccess.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAngularApp.DataAccess
{
    public class DotNetCoreAngularAppDbContext : DbContext
    {
        public DotNetCoreAngularAppDbContext()
        {
        }

        public DotNetCoreAngularAppDbContext(DbContextOptions<DotNetCoreAngularAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<CountryEntity> Countries { get; set; }
        public virtual DbSet<ProvinceEntity> Provinces { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
