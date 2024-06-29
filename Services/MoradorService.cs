using Fiap.Api.Residuos.Data.Repository;
using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _repository;

        public MoradorService(IMoradorRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarMorador(MoradorModel morador) => _repository.Update(morador);

        public void CriarMorador(MoradorModel morador) => _repository.Add(morador);

        public void DeletarMorador(int id)
        {
            var morador = _repository.GetById(id);
            if (morador != null) 
            {
                _repository.Delete(morador);
            }
        }

        public IEnumerable<MoradorModel> ListarMoradores() => _repository.GetAll();

        public MoradorModel ObterMoradorPorId(int id) => _repository.GetById(id);   
    }
}
