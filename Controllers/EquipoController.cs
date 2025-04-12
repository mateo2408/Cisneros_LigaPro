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
        public IActionResult Edit(int id, Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }
        
            var actualizado = _equipoRepository.ActualizarEquipo(id, equipo);
            if (!actualizado)
            {
                return NotFound();
            }
        
            return RedirectToAction(nameof(List));
        }
        
        public IActionResult Details()
        {
             var equipos = _equipoRepository.DevuelveListaEquipos();
            return View(equipos);
         }
        
     public IActionResult DetailsPage(int id)
     {
         var equipo = _equipoRepository.ObtenerEquipoPorId(id);
         if (equipo == null)
         {
             return NotFound();
         }
         return View(equipo);
     }

        public IActionResult Delete(int id)
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