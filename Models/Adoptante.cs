namespace AdopcionMascotas.Modelos
{
    public class Adoptante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación 1 a muchos: un adoptante puede adoptar varias mascotas
        public List<Adopcion> Adopciones { get; set; } = new();
    }
}
