using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tgasto
{
    public int Igasto { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Valor { get; set; }

    public int? Idtipogasto { get; set; }

    public virtual Ttipogasto? IdtipogastoNavigation { get; set; }
}
