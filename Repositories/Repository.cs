using Cisneros_LigaPro.Models; 

namespace Cisneros_LigaPro.Repositories
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
                    Id = 1, Nombre = "Liga de Quito",Puntos = 30, PartidosJugados = 10, PartidosGanados = 10, PartidosEmpatados = 0,
                    PartidosPerdidos = 0, Logo = "/images/equipo_1.png"
                },
                new Equipo
                {
                    Id = 2, Nombre = "Barcelona SC",Puntos = 10, PartidosJugados = 12, PartidosGanados = 8, PartidosEmpatados = 2,
                    PartidosPerdidos = 2, Logo = "/images/equipo_2.png"
                }
            };
        }

        public IEnumerable<Equipo> DevuelveListaEquipos()
        {
            return _equipos;
        }

        public bool ActualizarEquipo(int id, Equipo equipo)
        {
            return true;
        }

        public Equipo ObtenerEquipoPorId(int id)
        {
            return _equipos.FirstOrDefault(e => e.Id == id) ?? throw new KeyNotFoundException($"Equipo with Id {id} not found.");
        }
    }
}