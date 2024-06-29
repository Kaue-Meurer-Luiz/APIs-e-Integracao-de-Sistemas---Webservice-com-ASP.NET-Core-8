using Fiap.Api.Residuos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Residuos.Data.Repository
{
    public class MoradorRepository : IMoradorRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MoradorRepository(DatabaseContext context) 
        {
            _databaseContext = context;
        }


        public void Add(MoradorModel morador)
        {
            _databaseContext.Moradores.Add(morador);
            _databaseContext.SaveChanges();
        }

        public void Delete(MoradorModel morador)
        {
            _databaseContext.Moradores.Remove(morador);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<MoradorModel> GetAll()
        { 
            return _databaseContext.Moradores.ToList();
        }

        public MoradorModel GetById(int id) => _databaseContext.Moradores.Find(id);

        public void Update(MoradorModel morador)
        {
            _databaseContext.Moradores.Update(morador);
            _databaseContext.SaveChanges(); 
        }
    }
}
