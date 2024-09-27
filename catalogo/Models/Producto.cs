using System;
using System.Collections.Generic;

namespace catalogo.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string? ImagenRuta { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
