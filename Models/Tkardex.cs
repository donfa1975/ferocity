using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tkardex
{
    public int Idkardex { get; set; }

    public int? Idproducto { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Detalle { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public int? TipoKardex { get; set; }

    public virtual Tproducto? IdproductoNavigation { get; set; }
}
