using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class MonturaResultado : IMonturaResultado
    {
        public ITipo Tipo { get; }
        public double Porcentaje { get; }
    }
}
