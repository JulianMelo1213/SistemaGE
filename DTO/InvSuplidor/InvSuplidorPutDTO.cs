namespace SistemaGE.DTO.InvSuplidor
{
    public class InvSuplidorPutDTO
    {
        public int IdSuplidor { get; set; }

        public string Nombre { get; set; } = null!;

        public string Identificacion { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public bool Estatus { get; set; }

        public string? PersonaContacto { get; set; }

        public string? Comentario { get; set; }

        public string? IdTipoSuplidor { get; set; }

        public string? IdTipoIdentificacion { get; set; }
    }
}
