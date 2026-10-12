using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tbiometrium
{
    public int Idbiometria { get; set; }

    public int Idalumno { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Talla { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Cuello { get; set; }

    public decimal? Cintura { get; set; }

    public decimal? Cadera { get; set; }

    public decimal? Imc { get; set; }

    public decimal? Igc { get; set; }

    public string? Estado { get; set; }

    public virtual Talumno IdalumnoNavigation { get; set; } = null!;
}
