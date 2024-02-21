namespace CrianzaMonturas.Core.Modelo
{
    public class TipoMontura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoMontura()
        {
            Id = 0;
            Nombre = string.Empty;
        }

    }
}
