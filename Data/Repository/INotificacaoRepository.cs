using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Data.Repository
{
    public interface INotificacaoRepository
    {
        IEnumerable<NotificacaoModel> GetAll();
        NotificacaoModel GetById(int id);
        void Add(NotificacaoModel notificacao);
        void Update(NotificacaoModel notificacao);
        void Delete(NotificacaoModel notificacao);
    }
}
