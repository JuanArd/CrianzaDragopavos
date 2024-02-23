using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Resultado : IResultado
    {
        public ITipo Tipo { get; set; }
        public double Porcentaje { get; set; }
    }
}
