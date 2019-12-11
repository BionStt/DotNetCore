using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreRelationalCommandRepository<T> :
        EntityFrameworkCoreCommandRepository<T>,
        IRelationalCommandRepository<T>
        where T : class
    {
        public EntityFrameworkCoreRelationalCommandRepository(DbContext context) : base(context)
        {
        }
    }
}
