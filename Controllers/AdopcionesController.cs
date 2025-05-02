    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using AdopcionMascotas.Data;
    using AdopcionMascotas.Modelos;
    using System.Linq;

    namespace AdopcionMascotas.Controllers
    {
        public class AdopcionesController : Controller
        {
            private readonly ApplicationDbContext _context;

            public AdopcionesController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Adopciones/Create
            public IActionResult Create()
            {
                ViewData["MascotaId"] = new SelectList(_context.Mascotas.Where(m => m.EstadoAdopcion == "Disponible"), "Id", "Nombre");
                ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Nombre");
                return View();
            }

            // POST: Adopciones/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Adopcion adopcion)
            {
                if (ModelState.IsValid)
                {
                    var mascota = _context.Mascotas.Find(adopcion.MascotaId);
                    if (mascota != null)
                    {
                        mascota.EstadoAdopcion = "Adoptado";
                        _context.Adopciones.Add(adopcion);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }

                ViewData["MascotaId"] = new SelectList(_context.Mascotas.Where(m => m.EstadoAdopcion == "Disponible"), "Id", "Nombre", adopcion.MascotaId);
                ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Nombre", adopcion.AdoptanteId);
                return View(adopcion);
            }

            // GET: Adopciones
            public IActionResult Index()
            {
                var adopciones = _context.Adopciones
                    .Include(a => a.Mascota)
                    .Include(a => a.Adoptante)
                    .ToList();
                return View(adopciones);
            }
        }
    }
