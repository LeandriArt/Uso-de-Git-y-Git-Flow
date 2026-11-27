using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Inventario.Data;

namespace Tienda.Inventario.Controllers;

public class ProductosController : Controller
{
    private readonly InventarioContext _context;

    public ProductosController(InventarioContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _context.Productos
            .AsNoTracking()
            .ToListAsync();

        return View(productos);
    }
}