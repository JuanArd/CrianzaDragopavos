using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrianzaDragopavos.Modelo
{
    public class Tipo
    {
        public int Id { get; set; }
        public int TipoMonturaId { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public string Sigla { get; set; }
        public int Generacion { get; set; }
    }
}
