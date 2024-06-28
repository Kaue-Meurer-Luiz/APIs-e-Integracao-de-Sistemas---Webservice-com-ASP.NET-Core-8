namespace Fiap.Api.Residuos.Models
{
    public class MoradorModel 
    {
        public int MoradorId { get; set; }

        public string? MoradorName { get; set; }

        public string? Telefone { get; set; }

        public int IdLixeira { get; set; } // Foreign Key


        public LixeiraModel? Lixeira { get; set; }

    }
}
