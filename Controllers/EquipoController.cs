using Microsoft.AspNetCore.Mvc;
using Cisneros_LigaPro.Repositories;
using Cisneros_LigaPro.Models;

namespace Cisneros_LigaPro.Controllers
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

        [HttpPost]
        public IActionResult Create(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return View(equipo);
            }

            equipo.Id = _equipoRepository.DevuelveListaEquipos().Max(e => e.Id) + 1;
            _equipoRepository.DevuelveListaEquipos().ToList().Add(equipo);

            return RedirectToAction(nameof(List));
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
        
        public IActionResult Details(int id)
        {
            var equipos = _equipoRepository.DevuelveListaEquipos();
            return View(equipos);
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

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var eliminado = _equipoRepository.EliminarEquipo(id);
            if (!eliminado)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(List));
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
    }
}