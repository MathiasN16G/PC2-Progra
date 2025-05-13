using System.ComponentModel.DataAnnotations;

namespace AdopcionMascotas.Modelos
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string EstadoAdopcion { get; set; }

    
       
    }
}
