using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvTipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estatus { get; set; }

    public string? Efecto { get; set; }
}
