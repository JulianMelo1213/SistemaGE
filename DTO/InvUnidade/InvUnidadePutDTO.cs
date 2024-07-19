namespace SistemaGE.DTO.InvUnidade
{
    public class InvUnidadePutDTO
    {
        public int IdUnidad { get; set; }

        public string Descripcion { get; set; } = null!;

        public bool Estatus { get; set; }
    }
}
