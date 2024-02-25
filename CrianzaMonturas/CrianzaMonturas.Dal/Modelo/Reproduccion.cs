namespace CrianzaMonturas.Dal.Modelo
{
    public class Reproduccion
    {
        public int Id { get; set; }
        public int PadreId { get; set; }
        public int MadreId { get; set; }
        public DateTime FechaReproduccion { get; set; }
        public int? CriaId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
