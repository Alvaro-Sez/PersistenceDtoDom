using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Productora.Dto
{
    public class DirectorDto
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("Salario")]
        public int Salario { get; set; }
    }
}
