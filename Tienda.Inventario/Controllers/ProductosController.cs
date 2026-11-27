using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Inventario.Data;
using Tienda.Inventario.Models;

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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Nombre,Descripcion,Precio,Cantidad")] Producto producto)
    {
        if (!ModelState.IsValid)
        {
            return View(producto);
        }

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}