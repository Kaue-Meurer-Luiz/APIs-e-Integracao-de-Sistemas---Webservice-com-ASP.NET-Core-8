using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Data.Repository
{
    public interface ILixeiraRepository
    {
        IEnumerable<LixeiraModel> GetAll();

        LixeiraModel GetById(int id);
        void Add (LixeiraModel lixeira);  
        void Update (LixeiraModel lixeira);
        void Delete (LixeiraModel lixeira);
        

    }
}
