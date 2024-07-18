using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvArticuloSuplidor
{
    public int IdArticuloSuplidor { get; set; }

    public int IdArticulo { get; set; }

    public int IdSuplidor { get; set; }

    public string? CodigoArticulo { get; set; }

    public decimal? UltimoPrecio { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVentaMinimo { get; set; }

    public decimal? PrecioVentaMaximo { get; set; }

    public decimal? MargenBeneficio { get; set; }

    public decimal? PrecioVentaMayor { get; set; }

    public int? CantidadVentaMayor { get; set; }

    public int? CantidadOferta { get; set; }

    public int? CantidadUnidades { get; set; }

    public string? UnidadOferta { get; set; }

    public virtual InvArticulo IdArticuloNavigation { get; set; } = null!;

    public virtual InvSuplidor IdSuplidorNavigation { get; set; } = null!;
}
