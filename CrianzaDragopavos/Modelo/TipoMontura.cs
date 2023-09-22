using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrianzaDragopavos.Modelo
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
