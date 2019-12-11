namespace DotNetCore.Repositories
{
    public interface IRelationalCommandRepository<T> : ICommandRepository<T> where T : class { }
}
