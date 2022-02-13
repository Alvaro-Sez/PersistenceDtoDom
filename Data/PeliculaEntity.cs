using System;
using System.Collections.Generic;

#nullable disable

namespace Productora.Data
{
    public partial class PeliculaEntity
    {
        public PeliculaEntity()
        {
            Actors = new HashSet<ActorEntity>();
        }

        public string Titulo { get; set; }
        public Guid Id { get; set; }
        public string Tematica { get; set; }
        public Guid ProductoraId { get; set; }
        public int Presupuesto { get; set; }

        public virtual ProductoraEntity Productora { get; set; }
        public virtual DirectorEntity Director { get; set; }
        public virtual ICollection<ActorEntity> Actors { get; set; }
    }
}
