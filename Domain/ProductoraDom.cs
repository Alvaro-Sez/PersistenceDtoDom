using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Domain
{
    public class ProductoraDom
    {
        public string Nombre { get; set; }
        public List<PeliculaDom> Peliculas { get; set; }
    }
}
