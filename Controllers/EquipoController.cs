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
        
        public IActionResult Detalles(int id)
        {
            var equipo = _equipoRepository.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        public IActionResult Editar(int id)
        {
            var equipo = _equipoRepository.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        public IActionResult Eliminar(int id)
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