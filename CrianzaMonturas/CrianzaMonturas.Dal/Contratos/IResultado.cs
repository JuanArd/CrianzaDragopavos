namespace CrianzaMonturas.Dal.Contratos
{
    public interface IResultado
    {
        public ITipo Tipo { get; set; }
        public double Porcentaje { get; set; }
    }
}
