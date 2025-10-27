using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class VacinaController : Controller
    {
        private readonly VetContext _context;

        public VacinaController(VetContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vacinas = await _context.Vacinas.ToListAsync();
            return View(vacinas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                await _context.Vacinas.AddAsync(vacina);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vacina);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);
            if (vacina == null) return NotFound();
            return View(vacina);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                _context.Vacinas.Update(vacina);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vacina);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);
            if (vacina == null) return NotFound();
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}