using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvArticulo
{
    public int IdArticulo { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estatus { get; set; }

    public string? Imagen { get; set; }

    public string? RegistroSanitario { get; set; }

    public DateOnly? IngresoRegistroSanitario { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdClase { get; set; }

    public int? IdUnidadAdquisicion { get; set; }

    public int? IdUnidadVenta { get; set; }

    public int? IdFabricante { get; set; }

    public virtual ICollection<InvArticuloAlmacen> InvArticuloAlmacens { get; set; } = new List<InvArticuloAlmacen>();

    public virtual ICollection<InvArticuloSuplidor> InvArticuloSuplidors { get; set; } = new List<InvArticuloSuplidor>();
}
