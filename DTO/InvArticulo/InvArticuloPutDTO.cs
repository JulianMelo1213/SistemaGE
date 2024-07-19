namespace SistemaGE.DTO.InvArticulo
{
    public class InvArticuloPutDTO
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
    }
}
