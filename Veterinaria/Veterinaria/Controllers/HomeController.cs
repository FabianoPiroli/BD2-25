using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VetContext _context;

        public HomeController
            (ILogger<HomeController> logger,
            VetContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var animais = _context.Animais
                .Include(a => a.TipoAnimal)
                .ToList();
            return View(animais);
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
