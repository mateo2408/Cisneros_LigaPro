using Cisneros_LigaPro.Models; // Add this to reference the Equipo class

namespace Cisneros_LigaPro.Repositories // Update namespace to match the project
{
    public class EquipoRepository
    {
        private readonly List<Equipo> _equipos;

        public EquipoRepository()
        {
            _equipos = new List<Equipo>
            {
                new Equipo
                {
                    Id = 1, Nombre = "Liga de Quito", PartidosJugados = 10, PartidosGanados = 10, PartidosEmpatados = 0,
                    PartidosPerdidos = 0
                },
                new Equipo
                {
                    Id = 2, Nombre = "Barcelona SC", PartidosJugados = 12, PartidosGanados = 8, PartidosEmpatados = 2,
                    PartidosPerdidos = 2
                }
            };
        }

        public IEnumerable<Equipo> DevuelveListaEquipos()
        {
            return _equipos;
        }

        public Equipo ObtenerEquipoPorId(int id)
        {
            return _equipos.FirstOrDefault(e => e.Id == id) ?? throw new KeyNotFoundException($"Equipo with Id {id} not found.");
        }
    }
}