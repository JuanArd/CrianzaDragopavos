using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class TipoMontura : ITipoMontura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
