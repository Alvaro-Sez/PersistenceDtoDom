using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Data.Repositories
{
    public class PeliculaRepository : BaseRepository<ProductoraDbContext, PeliculaEntity, Guid>, IPeliculaRepository
    {
        public PeliculaRepository(ProductoraDbContext context) : base(context)
        {
        }
    }
}
