namespace SistemaGE.DTO.InvTipoDocumento
{
    public class InvTipoDocumentoPutDTO
    {
        public int IdTipoDocumento { get; set; }

        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }

        public string? Efecto { get; set; }
    }
}
