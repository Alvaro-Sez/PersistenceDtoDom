using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Productora.Dto
{
    public class ActorDto
    {
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string Papel { get; set; }
        public int Salario { get; set; }
    }
}
