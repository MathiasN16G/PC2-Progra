using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Data;
using AdopcionMascotas.Modelos;

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
            CargarCombos();
            return View();
        }

        // POST: Adopciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adopcion adopcion)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }

                CargarCombos(adopcion);
                return View(adopcion);
            }

            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == adopcion.MascotaId);

            if (mascota == null)
            {
                Console.WriteLine($"Mascota con ID {adopcion.MascotaId} no encontrada.");
                ModelState.AddModelError("MascotaId", "La mascota seleccionada no existe.");
                CargarCombos(adopcion);
                return View(adopcion);
            }

            mascota.EstadoAdopcion = "Adoptado";
            _context.Adopciones.Add(adopcion);
            _context.SaveChanges();

            Console.WriteLine("Adopción guardada correctamente.");
            return RedirectToAction("Index");
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

        // Método reutilizable para cargar combos
        private void CargarCombos(Adopcion adopcion = null)
{
    ViewData["MascotaId"] = new SelectList(
        _context.Mascotas
            .Where(m => m.EstadoAdopcion == "Disponible")
            .ToList(),
        "Id", "Nombre",
        adopcion?.MascotaId);

    ViewData["AdoptanteId"] = new SelectList(
        _context.Adoptantes.ToList(),
        "Id", "Nombre",
        adopcion?.AdoptanteId);
}
    }
}
