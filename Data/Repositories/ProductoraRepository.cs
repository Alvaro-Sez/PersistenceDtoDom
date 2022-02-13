using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Data.Repositories
{
    public class ProductoraRepository : BaseRepository<ProductoraDbContext, ProductoraEntity, Guid>, IProductoraRepository
    {
        public ProductoraRepository(ProductoraDbContext context) : base(context)
        {
        }
    }
}
