
using GeneoAPI_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneoAPI_1;

public class GeneoDbContext : DbContext {
    public DbSet<GeneoTree>? Trees {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=admin;password=adminX;database=geneo", new MariaDbServerVersion(new Version(10, 6, 16)));
        base.OnConfiguring(optionsBuilder);
    }
}