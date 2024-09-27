using System;
using System.Collections.Generic;

namespace catalogo.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
