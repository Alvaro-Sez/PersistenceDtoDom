using System;
using System.Collections.Generic;

#nullable disable

namespace Productora.Data
{
    public partial class DirectorEntity
    {
        public string Nombre { get; set; }
        public int Salario { get; set; }
        public Guid PeliculaId { get; set; }
        public Guid Id { get; set; }

        public virtual PeliculaEntity Pelicula { get; set; }
    }
}
