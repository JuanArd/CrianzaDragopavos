using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrianzaDragopavos.Modelo
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
