using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Modelos;

namespace AdopcionMascotas.Controllers
{
    public class MascotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Mascotas.Add(mascota);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // o redirige a un listado de mascotas si tienes uno
            }

            return View(mascota);
        }
    }
}
