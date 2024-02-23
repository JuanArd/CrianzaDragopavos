using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Cruce : ICruce
    {
        public int Tipo1 { get; set; }
        public int Tipo2 { get; set; }
        public int TipoResultado { get; set; }
    }
}
