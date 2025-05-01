using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cisneros_LigaPro.Data;
using System.Linq;

namespace Cisneros_LigaPro.Controllers;

public class LigaController : Controller
{
    private readonly ApplicationDbContext _context;

    public LigaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult TablaPosiciones()
    {
        var equipos = _context.Equipos
            .OrderByDescending(e => e.Puntos)
            .ToList();
        return View(equipos);
    }
}