using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrianzaDragopavos.Modelo
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
