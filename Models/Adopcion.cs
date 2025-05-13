using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopcionMascotas.Modelos
{
    public class Adopcion
    {
        public int Id { get; set; }

        [Required]
        public int MascotaId { get; set; }

        [ForeignKey("MascotaId")]
        public Mascota Mascota { get; set; }

        [Required]
        public int AdoptanteId { get; set; }

        [ForeignKey("AdoptanteId")]
        public Adoptante Adoptante { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
