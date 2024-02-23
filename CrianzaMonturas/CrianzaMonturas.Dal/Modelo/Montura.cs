using CrianzaMonturas.Dal.Contratos;

namespace CrianzaMonturas.Dal.Modelo
{
    public class Montura : IMontura
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
        IMontura? IMontura.Padre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IMontura? IMontura.Madre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
