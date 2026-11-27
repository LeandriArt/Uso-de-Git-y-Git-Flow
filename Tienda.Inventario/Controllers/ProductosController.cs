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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Nombre,Descripcion,Precio,Cantidad")] Producto producto)
    {
        if (id != producto.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(producto);
        }

        var productoExistente = await _context.Productos.FindAsync(id);

        if (productoExistente == null)
        {
            return NotFound();
        }

        productoExistente.Nombre = producto.Nombre;
        productoExistente.Descripcion = producto.Descripcion;
        productoExistente.Precio = producto.Precio;
        productoExistente.Cantidad = producto.Cantidad;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _context.Productos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}