using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tpago
{
    public int Idtpago { get; set; }

    public int Idalumno { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Valor { get; set; }

    public int? Tipo { get; set; }

    public virtual Talumno IdalumnoNavigation { get; set; } = null!;
}
