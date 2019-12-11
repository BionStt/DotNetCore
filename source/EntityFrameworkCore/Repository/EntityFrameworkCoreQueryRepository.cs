using DotNetCore.Mapping;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreQueryRepository<T> : IQueryRepository<T> where T : class
    {
        public EntityFrameworkCoreQueryRepository(DbContext context)
        {
            Context = context;
        }

        private IQueryable<T> Queryable => Context.Queryable<T>();

        private DbContext Context { get; }

        public bool Any()
        {
            return Queryable.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Queryable.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return Queryable.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.AnyAsync(where);
        }

        public long Count()
        {
            return Queryable.LongCount();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return Queryable.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCountAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Queryable.FirstOrDefault(where);
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.FirstOrDefaultAsync(where);
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().FirstOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Queryable.ToList();
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return Queryable.Project<T, TResult>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).ToList();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().ToList();
        }

        public PagedList<T> List(PagedListParameters parameters)
        {
            return new PagedList<T>(Queryable, parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters)
        {
            return new PagedList<TResult>(Queryable.Project<T, TResult>(), parameters);
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters)
        {
            return Task.FromResult(List<TResult>(parameters));
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Queryable.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return await Queryable.Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Queryable.Where(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return await Queryable.Where(where).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters)
        {
            return Task.FromResult(List(parameters));
        }

        public T Select(object key)
        {
            Context.DetectChangesLazyLoading(false);

            return Context.Set<T>().Find(key);
        }

        public TResult Select<TResult>(object key)
        {
            return Select(key).Map<T, TResult>();
        }

        public Task<T> SelectAsync(object key)
        {
            Context.DetectChangesLazyLoading(false);

            return Context.Set<T>().FindAsync(key).AsTask();
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return Task.FromResult(SelectAsync(key).Result.Map<TResult>());
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return Queryable.SingleOrDefault(where);
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.SingleOrDefaultAsync(where);
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().SingleOrDefaultAsync();
        }
    }
}
