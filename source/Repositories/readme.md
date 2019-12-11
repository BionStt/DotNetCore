# DotNetCore.Repositories

The package provides interfaces for **repositories**.

## Repository

### ICommandRepository

```cs
public interface ICommandRepository<T> where T : class
{
    void Add(T item);

    Task AddAsync(T item);

    void AddRange(IEnumerable<T> items);

    Task AddRangeAsync(IEnumerable<T> items);

    void Delete(object key);

    void Delete(Expression<Func<T, bool>> where);

    Task DeleteAsync(object key);

    Task DeleteAsync(Expression<Func<T, bool>> where);

    void Update(object key, T item);

    Task UpdateAsync(object key, T item);

    void UpdatePartial(object key, object item);

    Task UpdatePartialAsync(object key, object item);
}
```

### IQueryRepository

```cs
public interface IQueryRepository<T> where T : class
{
    bool Any();

    bool Any(Expression<Func<T, bool>> where);

    Task<bool> AnyAsync();

    Task<bool> AnyAsync(Expression<Func<T, bool>> where);

    long Count();

    long Count(Expression<Func<T, bool>> where);

    Task<long> CountAsync();

    Task<long> CountAsync(Expression<Func<T, bool>> where);

    T FirstOrDefault(Expression<Func<T, bool>> where);

    TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

    Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

    IEnumerable<T> List();

    IEnumerable<T> List(Expression<Func<T, bool>> where);

    IEnumerable<TResult> List<TResult>();

    IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where);

    PagedList<T> List(PagedListParameters parameters);

    PagedList<TResult> List<TResult>(PagedListParameters parameters);

    Task<PagedList<T>> ListAsync(PagedListParameters parameters);

    Task<IEnumerable<T>> ListAsync();

    Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where);

    Task<IEnumerable<TResult>> ListAsync<TResult>();

    Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where);

    Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters);

    T Select(object key);

    TResult Select<TResult>(object key);

    Task<T> SelectAsync(object key);

    Task<TResult> SelectAsync<TResult>(object key);

    T SingleOrDefault(Expression<Func<T, bool>> where);

    TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where);

    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);

    Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);
}
```

### IRepository

```cs
public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class { }
```

## Relational Repository

### IRelationalCommandRepository

```cs
public interface IRelationalCommandRepository<T> : ICommandRepository<T> where T : class { }
```

### IRelationalQueryRepository

```cs
public interface IRelationalQueryRepository<T> : IQueryRepository<T> where T : class
{
    T FirstOrDefaultInclude(params Expression<Func<T, object>>[] include);

    Task<T> FirstOrDefaultIncludeAsync(params Expression<Func<T, object>>[] include);

    T FirstOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<T> FirstOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    TResult FirstOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    Task<TResult> FirstOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    IEnumerable<T> ListInclude(params Expression<Func<T, object>>[] include);

    PagedList<T> ListInclude(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    IEnumerable<TResult> ListInclude<TResult>(params Expression<Func<T, object>>[] include);

    PagedList<TResult> ListInclude<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    Task<PagedList<T>> ListIncludeAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    Task<PagedList<TResult>> ListIncludeAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    Task<IEnumerable<T>> ListIncludeAsync(params Expression<Func<T, object>>[] include);

    Task<IEnumerable<TResult>> ListIncludeAsync<TResult>(params Expression<Func<T, object>>[] include);

    IEnumerable<T> ListWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    PagedList<T> ListWhereInclude(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    IEnumerable<TResult> ListWhereInclude<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    PagedList<TResult> ListWhereInclude<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<PagedList<T>> ListWhereIncludeAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<PagedList<TResult>> ListWhereIncludeAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<IEnumerable<T>> ListWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<IEnumerable<TResult>> ListWhereIncludeAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    T SingleOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<T> SingleOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    TResult SingleOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    Task<TResult> SingleOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);
}
```

### IRelationalRepository

```cs
public interface IRelationalRepository<T> : IRepository<T>, IRelationalCommandRepository<T>, IRelationalQueryRepository<T> where T : class { }
```
