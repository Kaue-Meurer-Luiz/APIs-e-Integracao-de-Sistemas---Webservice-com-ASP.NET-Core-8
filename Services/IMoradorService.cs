using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public interface IMoradorService
    {
        IEnumerable<MoradorModel> ListarMoradores();
        MoradorModel ObterMoradorPorId(int id);
        void CriarMorador(MoradorModel morador);
        void AtualizarMorador(MoradorModel morador);
        void DeletarMorador(int id);

    }
}
