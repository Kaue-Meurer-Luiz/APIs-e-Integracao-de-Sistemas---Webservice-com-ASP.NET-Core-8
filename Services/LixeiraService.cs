using Fiap.Api.Residuos.Data.Repository;
using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public class LixeiraService : ILixeiraService
    {
        private readonly ILixeiraRepository _repository;

        public LixeiraService(ILixeiraRepository repository)
        {
            _repository = repository;
        }   

        public void AtualizarLixeira(LixeiraModel lixeira) => _repository.Update(lixeira);

        public void CriarLixeira(LixeiraModel lixeira) => _repository.Add(lixeira);

        public void DeletarLixeira(int id)
        {
            var lixeira = _repository.GetById(id);
            if (lixeira != null) 
            {
                _repository.Delete(lixeira);
            }
        }

        public IEnumerable<LixeiraModel> ListarLixeiras() => _repository.GetAll();

        public LixeiraModel ObterLixeiraPorId(int id) => _repository.GetById(id);
    }
}
