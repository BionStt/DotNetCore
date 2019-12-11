# DotNetCore.EntityFrameworkCore

The package provides classes for **Entity Framework Core**.

## EntityFrameworkCoreExtensions

The **EntityFrameworkCoreExtensions** class provides **extension methods**.

```cs
public static class EntityFrameworkCoreExtensions
{
    public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder) { }

    public static void DetectChangesLazyLoading(this DbContext context, bool enabled) { }

    public static IQueryable<T> Include<T>(this IQueryable<T> queryable, Expression<Func<T, object>>[] includes) where T : class { }

    public static IQueryable<T> Queryable<T>(this DbContext context) where T : class { }
}
```

## Repository

### EntityFrameworkCoreCommandRepository

```cs
public class EntityFrameworkCoreCommandRepository<T> : ICommandRepository<T> where T : class
{
    public EntityFrameworkCoreCommandRepository(DbContext context) { }

    public void Add(T item) { }

    public Task AddAsync(T item) { }

    public void AddRange(IEnumerable<T> items) { }

    public Task AddRangeAsync(IEnumerable<T> items) { }

    public void Delete(object key) { }

    public void Delete(Expression<Func<T, bool>> where) { }

    public Task DeleteAsync(object key) { }

    public Task DeleteAsync(Expression<Func<T, bool>> where) { }

    public void Update(object key, T item) { }

    public Task UpdateAsync(object key, T item) { }

    public void UpdatePartial(object key, object item) { }

    public Task UpdatePartialAsync(object key, object item) { }
}
```

### EntityFrameworkCoreQueryRepository

```cs
public class EntityFrameworkCoreQueryRepository<T> : IQueryRepository<T> where T : class
{
    public EntityFrameworkCoreQueryRepository(DbContext context) { }

    public bool Any() { }

    public bool Any(Expression<Func<T, bool>> where) { }

    public Task<bool> AnyAsync() { }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) { }

    public long Count() { }

    public long Count(Expression<Func<T, bool>> where) { }

    public Task<long> CountAsync() { }

    public Task<long> CountAsync(Expression<Func<T, bool>> where) { }

    public T FirstOrDefault(Expression<Func<T, bool>> where) { }

    public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public IEnumerable<T> List() { }

    public IEnumerable<TResult> List<TResult>() { }

    public IEnumerable<T> List(Expression<Func<T, bool>> where) { }

    public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where) { }

    public PagedList<T> List(PagedListParameters parameters) { }

    public PagedList<TResult> List<TResult>(PagedListParameters parameters) { }

    public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters) { }

    public async Task<IEnumerable<T>> ListAsync() { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>() { }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where) { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where) { }

    public Task<PagedList<T>> ListAsync(PagedListParameters parameters) { }

    public T Select(object key) { }

    public TResult Select<TResult>(object key) { }

    public Task<T> SelectAsync(object key) { }

    public Task<TResult> SelectAsync<TResult>(object key) { }

    public T SingleOrDefault(Expression<Func<T, bool>> where) { }

    public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }
}
```

### EntityFrameworkCoreRepository

```cs
public class EntityFrameworkCoreRepository<T> : IRepository<T> where T : class
{
    public EntityFrameworkCoreRepository(DbContext context) { }

    public void Add(T item) { }

    public Task AddAsync(T item) { }

    public void AddRange(IEnumerable<T> items) { }

    public Task AddRangeAsync(IEnumerable<T> items) { }

    public bool Any() { }

    public bool Any(Expression<Func<T, bool>> where) { }

    public Task<bool> AnyAsync() { }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) { }

    public long Count() { }

    public long Count(Expression<Func<T, bool>> where) { }

    public Task<long> CountAsync() { }

    public Task<long> CountAsync(Expression<Func<T, bool>> where) { }

    public void Delete(object key) { }

    public void Delete(Expression<Func<T, bool>> where) { }

    public Task DeleteAsync(object key) { }

    public Task DeleteAsync(Expression<Func<T, bool>> where) { }

    public T FirstOrDefault(Expression<Func<T, bool>> where) { }

    public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public IEnumerable<T> List() { }

    public IEnumerable<TResult> List<TResult>() { }

    public IEnumerable<T> List(Expression<Func<T, bool>> where) { }

    public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where) { }

    public PagedList<T> List(PagedListParameters parameters) { }

    public PagedList<TResult> List<TResult>(PagedListParameters parameters) { }

    public Task<IEnumerable<T>> ListAsync() { }

    public Task<IEnumerable<TResult>> ListAsync<TResult>() { }

    public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where) { }

    public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where) { }

    public Task<PagedList<T>> ListAsync(PagedListParameters parameters) { }

    public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters) { }

    public T Select(object key) { }

    public TResult Select<TResult>(object key) { }

    public Task<T> SelectAsync(object key) { }

    public Task<TResult> SelectAsync<TResult>(object key) { }

    public T SingleOrDefault(Expression<Func<T, bool>> where) { }

    public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public void Update(object key, T item) { }

    public Task UpdateAsync(object key, T item) { }

    public void UpdatePartial(object key, object item) { }

    public Task UpdatePartialAsync(object key, object item) { }
}
```

## Relational Repository

### EntityFrameworkCoreRelationalCommandRepository

```cs
public class EntityFrameworkCoreRelationalCommandRepository<T> : EntityFrameworkCoreCommandRepository<T>, IRelationalCommandRepository<T> where T : class
{
    public EntityFrameworkCoreRelationalCommandRepository(DbContext context) : base(context) { }
}
```

### EntityFrameworkCoreRelationalQueryRepository

```cs
public class EntityFrameworkCoreRelationalQueryRepository<T> : EntityFrameworkCoreQueryRepository<T>, IRelationalQueryRepository<T> where T : class
{
    public EntityFrameworkCoreRelationalQueryRepository(DbContext context) : base(context) { }

    public T FirstOrDefaultInclude(params Expression<Func<T, object>>[] include) { }

    public Task<T> FirstOrDefaultIncludeAsync(params Expression<Func<T, object>>[] include) { }

    public T FirstOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<T> FirstOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult FirstOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<TResult> FirstOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public IEnumerable<T> ListInclude(params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> ListInclude<TResult>(params Expression<Func<T, object>>[] include) { }

    public PagedList<T> ListInclude(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> ListInclude<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<T>> ListIncludeAsync(params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<TResult>> ListIncludeAsync<TResult>(params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListIncludeAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListIncludeAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public IEnumerable<T> ListWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> ListWhereInclude<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<T> ListWhereInclude(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> ListWhereInclude<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<T>> ListWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<TResult>> ListWhereIncludeAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListWhereIncludeAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListWhereIncludeAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public T SingleOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<T> SingleOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult SingleOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<TResult> SingleOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }
}
```

### EntityFrameworkCoreRelationalRepository

```cs
public class EntityFrameworkCoreRelationalRepository<T> : EntityFrameworkCoreRepository<T>, IRelationalRepository<T> where T : class
{
    public EntityFrameworkCoreRelationalRepository(DbContext context) : base(context) { }

    public T FirstOrDefaultInclude(params Expression<Func<T, object>>[] include) { }

    public Task<T> FirstOrDefaultIncludeAsync(params Expression<Func<T, object>>[] include) { }

    public T FirstOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<T> FirstOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult FirstOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<TResult> FirstOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public IEnumerable<T> ListInclude(params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> ListInclude<TResult>(params Expression<Func<T, object>>[] include) { }

    public PagedList<T> ListInclude(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> ListInclude<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public Task<IEnumerable<T>> ListIncludeAsync(params Expression<Func<T, object>>[] include) { }

    public Task<IEnumerable<TResult>> ListIncludeAsync<TResult>(params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListIncludeAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListIncludeAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public IEnumerable<T> ListWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> ListWhereInclude<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<T> ListWhereInclude(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> ListWhereInclude<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<IEnumerable<T>> ListWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<IEnumerable<TResult>> ListWhereIncludeAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListWhereIncludeAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListWhereIncludeAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public T SingleOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<T> SingleOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult SingleOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<TResult> SingleOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }
}
```
