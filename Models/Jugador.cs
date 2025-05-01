namespace Cisneros_LigaPro.Models;

public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int NumeroCamiseta { get; set; }
    public int Goles { get; set; }
    public int Asistencias { get; set; }
    public decimal Sueldo { get; set; }
    public int EquipoId { get; set; }
    public Equipo Equipo { get; set; }
}