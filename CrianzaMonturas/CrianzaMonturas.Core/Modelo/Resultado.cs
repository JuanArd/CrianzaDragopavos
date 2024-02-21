namespace CrianzaMonturas.Core.Modelo
{
    public class Resultado
    {
        public Tipo Tipo { get; set; }
        public double Porcentaje { get; set; }

        public Resultado(Tipo tipo, double porcentaje)
        {
            this.Tipo = tipo;
            this.Porcentaje = porcentaje;
        }
    }
}
