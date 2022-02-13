using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Data.Repositories
{
    public class ActorRepository : BaseRepository<ProductoraDbContext, ActorEntity, Guid>, IActorRepository
    {
        public ActorRepository(ProductoraDbContext context) : base(context)
        {
        }
    }
}
