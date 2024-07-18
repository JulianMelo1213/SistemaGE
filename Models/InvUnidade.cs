using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvUnidade
{
    public int IdUnidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estatus { get; set; }
}
