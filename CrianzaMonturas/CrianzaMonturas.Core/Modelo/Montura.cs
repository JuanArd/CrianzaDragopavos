namespace CrianzaMonturas.Core.Modelo
{
    public class Montura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Salvaje { get; set; }
        public string? Sexo { get; set; }
        public int TipoMonturaId { get; set; }
        public int TipoId { get; set; }
        public bool Predispuesto { get; set; }
        public Montura? Padre { get; set; }
        public Montura? Madre { get; set; }
        public int Reproducciones { get; set; }
        public int MaxReproducciones { get; set; }
        public bool Esteril { get; set; }
        public bool Reproducible { get; set; }
        public bool Fecundada { get; set; }

        public Montura()
        {
            Id = 0;
            Nombre = string.Empty;
            Salvaje = true;
            Sexo = string.Empty;
            TipoMonturaId = 0;
            Predispuesto = false;
            Reproducciones = 0;
            MaxReproducciones = 1;
            Esteril = false;
            Reproducible = true;
            Fecundada = false;
        }

    }
}
