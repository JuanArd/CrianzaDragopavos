using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Resultado : IResultado
    {
        public ITipo Tipo { get; set; } = new Tipo();
        public double Porcentaje { get; set; }
    }
}
