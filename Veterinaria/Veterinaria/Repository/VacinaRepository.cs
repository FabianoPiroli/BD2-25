using Veterinaria.Data;
using Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Repository
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly VetContext _context;
        public VacinaRepository(VetContext context)
        {
            _context = context;
        }

        public async Task Create(Vacina vacina)
        {
            await _context.Vacinas.AddAsync(vacina);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vacina vacina)
        {
            _context.Vacinas.Update(vacina);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Vacina vacina)
        {
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();
        }

        public async Task<Vacina?> GetById(int id)
        {
            return await _context.Vacinas
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vacina>> GetAll()
        {
            return await _context.Vacinas
                .ToListAsync();
        }

        public async Task<List<Vacina>> GetByName(string name)
        {
            return await _context.Vacinas
                .Where(v => v.Nome != null && v.Nome.Contains(name))
                .ToListAsync();
        }
    }
}
