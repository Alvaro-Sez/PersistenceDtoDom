using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Productora.Dto
{
    public class PeliculaDto
    {
        [JsonPropertyName("Titulo")]
        public string Titulo { get; set; }
        [JsonPropertyName("Tematica")]
        public string Tematica { get; set; }
        [JsonPropertyName("Director")]
        public DirectorDto Director { get; set; }
        [JsonPropertyName("Actores")]
        public List<ActorDto> Actores { get; set; }
        [JsonPropertyName("Presupuesto")]
        public int Presupuesto { get; set; }
    }
}
