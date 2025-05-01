using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cisneros_LigaPro.Data;
using Cisneros_LigaPro.Models;

namespace Cisneros_LigaPro.Controllers;

public class ReportesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var goleadores = _context.Jugadores
            .OrderByDescending(j => j.Goles)
            .Take(5)
            .ToList();

        var asistentes = _context.Jugadores
            .OrderByDescending(j => j.Asistencias)
            .Take(5)
            .ToList();

        var equiposPresupuesto = _context.Equipos
            .OrderByDescending(e => e.Presupuesto)
            .Take(5)
            .ToList();

        return View(new ReporteViewModel
        {
            Goleadores = goleadores,
            Asistentes = asistentes,
            EquiposPresupuesto = equiposPresupuesto
        });
    }
}