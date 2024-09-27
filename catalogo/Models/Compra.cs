using System;
using System.Collections.Generic;

namespace catalogo.Models;

public partial class Compra
{
    public int CompraId { get; set; }

    public int ClienteId { get; set; }

    public int ProductoId { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cliente? Cliente { get; set; } 

    public virtual Producto? Producto { get; set; } 
}
