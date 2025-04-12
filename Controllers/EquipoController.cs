using Microsoft.AspNetCore.Mvc;
using Cisneros_LigaPro.Repositories; // Update namespace for EquipoRepository
using Cisneros_LigaPro.Models; // Add this to reference the Equipo class

namespace Cisneros_LigaPro.Controllers // Update namespace to match the project
{
    public class EquipoController : Controller
    {
        private readonly EquipoRepository _equipoRepository;

        public EquipoController(EquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public IActionResult List()
        {
            var equipos = _equipoRepository.DevuelveListaEquipos();
            return View(equipos);
        }
        
        public IActionResult Create()
        {
            var equipo = new Equipo();
            return View(equipo);
        }
        
        public IActionResult Edit(int id)
        {
            var equipo = _equipoRepository.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }
        [HttpPost]
        public IActionResult Edit(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }

            var existingEquipo = _equipoRepository.ObtenerEquipoPorId(equipo.Id);
            if (existingEquipo == null)
            {
                return NotFound();
            }
            
            existingEquipo.Nombre = equipo.Nombre;
            existingEquipo.PartidosJugados = equipo.PartidosJugados;
            existingEquipo.PartidosGanados = equipo.PartidosGanados;
            existingEquipo.PartidosEmpatados = equipo.PartidosEmpatados;
            existingEquipo.PartidosPerdidos = equipo.PartidosPerdidos;

            return RedirectToAction("List");
        }
        
        public IActionResult Details(int id)
        {
            var equipo = _equipoRepository.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        public IActionResult Delet(int id)
        {
            var equipo = _equipoRepository.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }
    }
}