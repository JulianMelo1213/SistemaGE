namespace SistemaGE.DTO.InvAlmacen
{
    public class InvAlmacenPutDTO
    {
        public int IdAlmacen { get; set; }

        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }

        public int? IdTipoAlmacen { get; set; }

    }
}
