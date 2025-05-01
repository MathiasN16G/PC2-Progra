namespace AdopcionMascotas.Modelos
{
    public class Adopcion
    {
        public int Id { get; set; }

        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }

        public int AdoptanteId { get; set; }
        public Adoptante Adoptante { get; set; }
    }
}
