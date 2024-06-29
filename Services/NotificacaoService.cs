using Fiap.Api.Residuos.Data.Repository;
using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _repository;

        public NotificacaoService(INotificacaoRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarNotificacao(NotificacaoModel notificacao) => _repository.Update(notificacao);

        public void CriarNotificacao(NotificacaoModel notificacao) => _repository.Add(notificacao);

        public void DeletarNotificacao(int id)
        {
            var notificacao =_repository.GetById(id);
            if (notificacao != null) 
            {
                _repository.Delete(notificacao);
            }
        }

        public IEnumerable<NotificacaoModel> ListarNotificacoes() => _repository.GetAll();

        public NotificacaoModel ObterNotificacaoPorId(int id) => _repository.GetById(id);
    }
}
