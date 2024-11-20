using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Tipo : ITipo
    {
        public int Id { get; set; }
        public int TipoMonturaId { get; set; }
        public string Alias { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public byte[] Imagen { get; set; } = [];
        public string Sigla { get; set; } = string.Empty;
        public int Generacion { get; set; }
    }
}
