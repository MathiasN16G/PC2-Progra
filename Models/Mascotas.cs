using System.ComponentModel.DataAnnotations;

namespace AdopcionMascotas.Modelos
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string EstadoAdopcion { get; set; }

       
    }
}
