using Microsoft.EntityFrameworkCore;
using Cisneros_LigaPro.Models;

namespace Cisneros_LigaPro.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<Jugador> Jugadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CisnerosLigaProDB;Trusted_Connection=True;");
        }
    }
}