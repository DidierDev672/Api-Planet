using Microsoft.EntityFrameworkCore;

public class PlanetContext : DbContext
{
    public PlanetContext(DbContextOptions<PlanetContext> options) : base(options) { }
    public DbSet<Planet> Planets { get; set; } = null!;
}