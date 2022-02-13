using System;
using System.Collections.Generic;

#nullable disable

namespace Productora.Data
{
    public partial class ProductoraEntity
    {
        public ProductoraEntity()
        {
            Peliculas = new HashSet<PeliculaEntity>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PeliculaEntity> Peliculas { get; set; }
    }
}
