using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Repository;

namespace Veterinaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalRepository _animalRepository;
        private readonly VetContext _context;

        /*
        Plano (pseudocódigo detalhado):
        - Adicionar um campo privado para o DbContext usado no projeto (aqui: `VeterinariaContext _context`).
        - Modificar o construtor para receber também o `VeterinariaContext` via injeção de dependência.
        - Atribuir o parâmetro do construtor ao campo `_context`.
        - Manter uso atual de `_animalRepository`.
        - Com o `_context` disponível, a linha que monta `ViewBag.TiposAnimais` passa a compilar corretamente.
        */

        public HomeController
            (ILogger<HomeController> logger,
            IAnimalRepository animalRepository,
            VetContext context
        )
        {
            _logger = logger;
            _animalRepository = animalRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _animalRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TiposAnimais = new SelectList(_context.TiposAnimais, "Id", "Especie");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _animalRepository.Create(animal);
                return RedirectToAction("Index");
            }
            ViewBag.TiposAnimais = new SelectList(_context.TiposAnimais, "Id", "Especie", animal.TipoAnimalId);
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var animal = await _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewBag.TiposAnimais = new SelectList(_context.TiposAnimais, "Id", "Especie", animal.TipoAnimalId);
            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _animalRepository.Update(animal);
                return RedirectToAction("Index");
            }
            ViewBag.TiposAnimais = new SelectList(_context.TiposAnimais, "Id", "Especie", animal.TipoAnimalId);
            return View(animal);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
