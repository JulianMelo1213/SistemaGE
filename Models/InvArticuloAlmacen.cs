using System;
using System.Collections.Generic;

namespace SistemaGE.Models;

public partial class InvArticuloAlmacen
{
    public int IdArticuloAlmacen { get; set; }

    public int IdArticulo { get; set; }

    public int IdAlmacen { get; set; }

    public int IdUbicacion { get; set; }

    public int? BalanceActual { get; set; }

    public int? BalanceMinimo { get; set; }

    public int? BalanceMaximo { get; set; }

    public int? BalanceReservado { get; set; }

    public virtual InvAlmacen IdAlmacenNavigation { get; set; } = null!;

    public virtual InvArticulo IdArticuloNavigation { get; set; } = null!;

    public virtual InvUbicacion IdUbicacionNavigation { get; set; } = null!;
}
