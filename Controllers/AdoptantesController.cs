using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Modelos;

namespace AdopcionMascotas.Controllers
{
    public class AdoptantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adoptantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adoptantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                _context.Adoptantes.Add(adoptante);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Puedes cambiar la redirección si deseas
            }

            return View(adoptante);
        }
    }
}
