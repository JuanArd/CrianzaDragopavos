using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrianzaDragopavos.Modelo
{
    internal class Montura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Salvaje { get; set; }
        public string Sexo { get; set; }
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
    }
}
