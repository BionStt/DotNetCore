namespace DotNetCore.Repositories
{
    public interface IRelationalRepository<T> : IRepository<T>, IRelationalCommandRepository<T>, IRelationalQueryRepository<T> where T : class { }
}
