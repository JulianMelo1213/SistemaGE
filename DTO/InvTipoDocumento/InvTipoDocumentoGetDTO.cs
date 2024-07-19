namespace SistemaGE.DTO.InvTipoDocumento
{
    public class InvTipoDocumentoGetDTO
    {
        public int IdTipoDocumento { get; set; }

        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }

        public string? Efecto { get; set; }
    }
}
