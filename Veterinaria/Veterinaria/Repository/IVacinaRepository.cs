using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public interface IVacinaRepository
    {
        public Task Create(Vacina vacina);
        public Task Update(Vacina vacina);
        public Task Delete(Vacina vacina);
        public Task<Vacina?> GetById(int id);
        public Task<List<Vacina>> GetAll();
        public Task<List<Vacina>> GetByName(string name);
    }
}
