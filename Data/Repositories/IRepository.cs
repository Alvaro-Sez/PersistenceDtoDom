using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Productora.Data.Repositories
{
    public interface IRepository<TEntity, in TKey> : IReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey> where TEntity : class
    {
    }
}
