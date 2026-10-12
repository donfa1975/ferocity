using System;
using System.Collections.Generic;

namespace Ferocity.Models;

public partial class Tusuario
{
    public int Idusuario { get; set; }

    public string Usuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Nombre { get; set; }

    public int? Nivel { get; set; }
}
