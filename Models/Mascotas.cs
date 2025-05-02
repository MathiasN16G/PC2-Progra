using System.ComponentModel.DataAnnotations;

namespace AdopcionMascotas.Modelos
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "La edad debe ser un número positivo")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un estado de adopción")]
        public string EstadoAdopcion { get; set; }

        public Adopcion? Adopcion { get; set; }
    }
}
