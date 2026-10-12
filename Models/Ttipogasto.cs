using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Ttipogasto
{
    public int Idtipogasto { get; set; }

    public string Gasto { get; set; } = null!;

    public virtual ICollection<Tgasto> Tgastos { get; set; } = new List<Tgasto>();
}
