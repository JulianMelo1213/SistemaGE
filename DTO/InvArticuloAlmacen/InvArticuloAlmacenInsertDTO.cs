namespace SistemaGE.DTO.InvArticuloAlmacen
{
    public class InvArticuloAlmacenInsertDTO
    {
        public int IdArticulo { get; set; }

        public int IdAlmacen { get; set; }

        public int IdUbicacion { get; set; }

        public int? BalanceActual { get; set; }

        public int? BalanceMinimo { get; set; }

        public int? BalanceMaximo { get; set; }

        public int? BalanceReservado { get; set; }
    }
}
