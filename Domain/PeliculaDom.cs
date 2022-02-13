using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Domain
{
    public class PeliculaDom
    {
        public string Titulo { get; set; }
        public string Tematica { get; set; }
        public DirectorDom Director { get; set; }
        public List<ActorDom> Actores { get; set; }
        public int Presupuesto { get; set; }
    }
}
