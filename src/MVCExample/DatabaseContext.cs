using Microsoft.EntityFrameworkCore;
using MVCExample.Models;

namespace MVCExample;

public class DatabaseContext: DbContext
{
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Moon> Moons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine, LogLevel.Information);
    }
}
