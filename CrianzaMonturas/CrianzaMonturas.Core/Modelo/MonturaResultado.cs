namespace CrianzaMonturas.Core.Modelo
{
    public class MonturaResultado
    {
        public Tipo Tipo { get; }
        public double Porcentaje { get; }

        public MonturaResultado()
        {
            Tipo = new();
            Porcentaje = 0;
        }
    }
}
