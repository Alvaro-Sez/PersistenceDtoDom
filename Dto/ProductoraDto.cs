using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Productora.Dto
{
    public class ProductoraDto
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("Peliculas")]
        public List<PeliculaDto> Peliculas { get; set; }
    }
}
