using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Tipo : ITipo
    {
        public int Id { get; set; }
        public int TipoMonturaId { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public string Sigla { get; set; }
        public int Generacion { get; set; }
    }
}
