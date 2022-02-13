using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Data.Repositories
{
    public class DirectorRepository : BaseRepository<ProductoraDbContext, DirectorEntity, Guid>, IDirectorRepository
    {
        public DirectorRepository(ProductoraDbContext context) : base(context)
        {
        }
    }
}
