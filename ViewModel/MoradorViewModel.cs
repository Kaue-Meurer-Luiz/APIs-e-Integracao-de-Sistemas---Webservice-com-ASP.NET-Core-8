using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.ViewModel
{
    public class MoradorViewModel
    {
        public int MoradorId { get; set; }

        public string MoradorName { get; set; }

        public string Telefone { get; set; }

        public int IdLixeira { get; set; } // Foreign Key


        public LixeiraViewModel Lixeira { get; set; }

    }
}
