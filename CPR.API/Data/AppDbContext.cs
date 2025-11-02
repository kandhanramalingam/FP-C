using CPR.API.Models.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace CPR.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ClientInfo> Clients { get; set; }
        public DbSet<PropertyInfo> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Properties)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
