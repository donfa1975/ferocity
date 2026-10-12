using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tproducto
{
    public int Idproducto { get; set; }

    public string? Codigo { get; set; }

    public string? NombreProducto { get; set; }

    public string? TipoProducto { get; set; }

    public decimal? Pvp { get; set; }

    public virtual ICollection<Tkardex> Tkardices { get; set; } = new List<Tkardex>();
}
