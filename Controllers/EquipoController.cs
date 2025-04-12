using Cisneros_LigaPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cisneros_LigaPro.Controllers;

public class EquipoController : Controller
{
    private static List<Equipo> Equipos = new List<Equipo>
    {
        new Equipo { Nombre = "Equipo A", PartidosJugados = 5, PartidosGanados = 3, PartidosEmpatados = 1, PartidosPerdidos = 1 },
        new Equipo { Nombre = "Equipo B", PartidosJugados = 5, PartidosGanados = 2, PartidosEmpatados = 2, PartidosPerdidos = 1 }
    };

    public IActionResult TablaPosiciones()
    {
        return View(Equipos);
    }

    [HttpPost]
    public IActionResult ActualizarEquipo(Equipo equipo)
    {
        var equipoExistente = Equipos.FirstOrDefault(e => e.Nombre == equipo.Nombre);
        if (equipoExistente != null)
        {
            equipoExistente.PartidosJugados = equipo.PartidosJugados;
            equipoExistente.PartidosGanados = equipo.PartidosGanados;
            equipoExistente.PartidosEmpatados = equipo.PartidosEmpatados;
            equipoExistente.PartidosPerdidos = equipo.PartidosPerdidos;
        }
        return RedirectToAction("TablaPosiciones");
    }
}