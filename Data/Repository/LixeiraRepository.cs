using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Data.Repository
{
    public class LixeiraRepository : ILixeiraRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LixeiraRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }


        public void Add(LixeiraModel lixeira)
        {
            _databaseContext.Lixeiras.Add(lixeira);
            _databaseContext.SaveChanges();
        }

        public void Delete(LixeiraModel lixeira)
        {
            _databaseContext.Lixeiras.Remove(lixeira);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<LixeiraModel> GetAll()
        {
            return _databaseContext.Lixeiras.ToList();
        }


        public LixeiraModel GetById(int id) => _databaseContext.Lixeiras.Find(id);

        public void Update(LixeiraModel lixeira)
        {
            _databaseContext.Lixeiras.Update(lixeira);
            _databaseContext.SaveChanges();
        }
    }
}
