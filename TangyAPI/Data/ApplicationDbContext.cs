using Microsoft.EntityFrameworkCore;
using TangyAPI.Models;

namespace TangyAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Entree", AddedOn = new DateTime(2026, 1, 12) },
            new Category { Id = 2, Name = "Appetiser", AddedOn = new DateTime(2026, 2, 23) },
            new Category { Id = 3, Name = "Desert", AddedOn = new DateTime(2026, 3, 17) },
            new Category { Id = 4, Name = "Starter", AddedOn = new DateTime(2026, 4, 15) },
            new Category { Id = 5, Name = "Snaks", AddedOn = new DateTime(2026, 5, 19) }
        );
    }
}
