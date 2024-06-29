using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Data.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public NotificacaoRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(NotificacaoModel notificacao)
        {
            _databaseContext.Notificacoes.Add(notificacao);
            _databaseContext.SaveChanges();
        }

        public void Delete(NotificacaoModel notificacao)
        {
            _databaseContext.Notificacoes.Remove(notificacao);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<NotificacaoModel> GetAll()
        {
            return _databaseContext.Notificacoes.ToList();
        }

        public NotificacaoModel GetById(int id) => _databaseContext.Notificacoes.Find(id);

        public void Update(NotificacaoModel notificacao)
        {
            _databaseContext.Notificacoes.Update(notificacao);
            _databaseContext.SaveChanges();
        }
    }
}
