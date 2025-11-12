using FP_C.API.Models.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace FP_C.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ClientInfo> Clients { get; set; }
        public DbSet<PropertyInfo> Properties { get; set; }
        public DbSet<VehicleInfo> Vehicles { get; set; }
        public DbSet<PolicyInfo> Policies { get; set; }
        public DbSet<AstuteRequest> AstuteRequests { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<BrokerRequest> BrokerRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Properties)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Properties)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Policies)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(v => v.Vehicles)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(b => b.BrokerRequests)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<Broker>()
                .HasMany(b => b.BrokerRequests)
                .WithOne(b => b.Broker)
                .HasForeignKey(b => b.BrokerId);

                

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
