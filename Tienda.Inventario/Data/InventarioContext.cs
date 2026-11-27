using Microsoft.EntityFrameworkCore;
using Tienda.Inventario.Models;

namespace Tienda.Inventario.Data;

public class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {
    }

    public DbSet<Producto> Productos => Set<Producto>();
}