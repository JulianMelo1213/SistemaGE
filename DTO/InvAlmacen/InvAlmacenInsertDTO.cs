namespace SistemaGE.DTO.InvAlmacen
{
    public class InvAlmacenInsertDTO
    {

        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }

        public int? IdTipoAlmacen { get; set; }

    }
}
