using System.ComponentModel.DataAnnotations;

namespace Tienda.Inventario.Models;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Range(typeof(decimal), "0.01", "99999999",
        ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue,
        ErrorMessage = "La cantidad no puede ser negativa.")]
    public int Cantidad { get; set; }
}