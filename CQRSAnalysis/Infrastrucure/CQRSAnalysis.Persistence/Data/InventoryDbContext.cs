using CQRSAnalysis.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSAnalysis.Persistence.Data;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Name);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}