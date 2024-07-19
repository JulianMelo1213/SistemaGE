namespace SistemaGE.DTO.InvTipoDocumento
{
    public class InvTipoDocumentoInsertDTO
    {
        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }

        public string? Efecto { get; set; }
    }
}
