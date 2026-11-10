using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Talumno
{
    public int Idalumno { get; set; }

    public string? Codigo { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? Fechanac { get; set; }

    public DateTime? Fechinscripcion { get; set; }

    public DateTime? Fechaultimopago { get; set; }

    public decimal? Valorapagar { get; set; }

    public sbyte? Activo { get; set; }

    public string? Tipo { get; set; }

    public sbyte? Jiujitsu { get; set; }

    public sbyte? Kickboxing { get; set; }

    public sbyte? Mma { get; set; }

    public DateTime? Proximopago { get; set; }

    public virtual ICollection<Tbiometrium> Tbiometria { get; set; } = new List<Tbiometrium>();

    public virtual ICollection<Tpago> Tpagos { get; set; } = new List<Tpago>();
}
