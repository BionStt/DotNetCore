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
    public class EntityFrameworkCoreRelationalQueryRepository<T> :
        EntityFrameworkCoreQueryRepository<T>,
        IRelationalQueryRepository<T>
        where T : class
    {
        public EntityFrameworkCoreRelationalQueryRepository(DbContext context) : base(context)
        {
            Queryable = context.Queryable<T>();
        }

        private IQueryable<T> Queryable { get; }

        public T FirstOrDefaultInclude(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultIncludeAsync(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).FirstOrDefaultAsync();
        }

        public T FirstOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).FirstOrDefaultAsync();
        }

        public TResult FirstOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Queryable.Where(where).Select(select).FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Queryable.Where(where).Select(select).FirstOrDefaultAsync();
        }

        public IEnumerable<T> ListInclude(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).ToList();
        }

        public IEnumerable<TResult> ListInclude<TResult>(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).Project<T, TResult>().ToList();
        }

        public PagedList<T> ListInclude(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(Queryable.Include(include), parameters);
        }

        public PagedList<TResult> ListInclude<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<TResult>(Queryable.Include(include).Project<T, TResult>(), parameters);
        }

        public async Task<IEnumerable<T>> ListIncludeAsync(params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Include(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListIncludeAsync<TResult>(params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Include(include).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public Task<PagedList<T>> ListIncludeAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(ListInclude(parameters, include));
        }

        public Task<PagedList<TResult>> ListIncludeAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(ListInclude<TResult>(parameters, include));
        }

        public IEnumerable<T> ListWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).ToList();
        }

        public IEnumerable<TResult> ListWhereInclude<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).Project<T, TResult>().ToList();
        }

        public PagedList<T> ListWhereInclude(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(Queryable.Where(where).Include(include), parameters);
        }

        public PagedList<TResult> ListWhereInclude<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<TResult>(Queryable.Where(where).Include(include).Project<T, TResult>(), parameters);
        }

        public async Task<IEnumerable<T>> ListWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Where(where).Include(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListWhereIncludeAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Where(where).Include(include).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public Task<PagedList<T>> ListWhereIncludeAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(ListWhereInclude(parameters, where, include));
        }

        public Task<PagedList<TResult>> ListWhereIncludeAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(ListWhereInclude<TResult>(parameters, where, include));
        }

        public T SingleOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).SingleOrDefaultAsync();
        }

        public TResult SingleOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Queryable.Where(where).Select(select).SingleOrDefault();
        }

        public Task<TResult> SingleOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Queryable.Where(where).Select(select).SingleOrDefaultAsync();
        }
    }
}
