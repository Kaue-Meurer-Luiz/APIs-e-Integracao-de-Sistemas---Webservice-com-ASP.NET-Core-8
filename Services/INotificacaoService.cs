using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public interface INotificacaoService
    {

        IEnumerable<NotificacaoModel> ListarNotificacoes();
        NotificacaoModel ObterNotificacaoPorId(int id);
        void CriarNotificacao(NotificacaoModel notificacao);
        void AtualizarNotificacao(NotificacaoModel notificacao);
        void DeletarNotificacao(int id);
    }
}
