namespace CrianzaMonturas.Core.Modelo
{
    public class Tipo
    {
        public int Id { get; set; }
        public int TipoMonturaId { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public string Sigla { get; set; }
        public int Generacion { get; set; }

        public Tipo()
        {
            Id = 0;
            TipoMonturaId = 0;
            Alias = string.Empty;
            Nombre = string.Empty;
            Imagen = Array.Empty<byte>();
            Sigla = string.Empty;
            Generacion = 0;
        }
    }
}
