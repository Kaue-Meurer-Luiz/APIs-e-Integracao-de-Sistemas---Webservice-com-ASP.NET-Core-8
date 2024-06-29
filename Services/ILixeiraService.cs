using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public interface ILixeiraService
    {
        IEnumerable<LixeiraModel> ListarLixeiras();
        LixeiraModel ObterLixeiraPorId(int id);
        void CriarLixeira(LixeiraModel lixeira);
        void AtualizarLixeira(LixeiraModel lixeira);
        void DeletarLixeira(int id);

    }
}
