using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvUbicacion
{
    public int IdUbicacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estatus { get; set; }

    public virtual ICollection<InvArticuloAlmacen> InvArticuloAlmacens { get; set; } = new List<InvArticuloAlmacen>();
}
