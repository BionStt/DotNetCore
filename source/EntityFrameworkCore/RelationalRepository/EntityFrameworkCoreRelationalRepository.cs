using DotNetCore.Objects;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreRelationalRepository<T> :
        EntityFrameworkCoreRepository<T>,
        IRelationalRepository<T>
        where T : class
    {
        public EntityFrameworkCoreRelationalRepository(DbContext context) : base(context)
        {
            EntityFrameworkCoreRelationalCommandRepository = new EntityFrameworkCoreRelationalCommandRepository<T>(context);
            EntityFrameworkCoreRelationalQueryRepository = new EntityFrameworkCoreRelationalQueryRepository<T>(context);
        }

        private EntityFrameworkCoreRelationalCommandRepository<T> EntityFrameworkCoreRelationalCommandRepository { get; }

        private EntityFrameworkCoreRelationalQueryRepository<T> EntityFrameworkCoreRelationalQueryRepository { get; }

        public T FirstOrDefaultInclude(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultInclude(include);
        }

        public Task<T> FirstOrDefaultIncludeAsync(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultIncludeAsync(include);
        }

        public T FirstOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultWhereInclude(where, include);
        }

        public Task<T> FirstOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultWhereIncludeAsync(where, include);
        }

        public TResult FirstOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultWhereSelect(where, select);
        }

        public Task<TResult> FirstOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return EntityFrameworkCoreRelationalQueryRepository.FirstOrDefaultWhereSelectAsync(where, select);
        }

        public IEnumerable<T> ListInclude(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListInclude(include);
        }

        public IEnumerable<TResult> ListInclude<TResult>(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListInclude<TResult>(include);
        }

        public PagedList<T> ListInclude(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListInclude(parameters, include);
        }

        public PagedList<TResult> ListInclude<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListInclude<TResult>(parameters, include);
        }

        public Task<IEnumerable<T>> ListIncludeAsync(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListIncludeAsync(include);
        }

        public Task<IEnumerable<TResult>> ListIncludeAsync<TResult>(params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListIncludeAsync<TResult>(include);
        }

        public Task<PagedList<T>> ListIncludeAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListIncludeAsync(parameters, include);
        }

        public Task<PagedList<TResult>> ListIncludeAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListIncludeAsync<TResult>(parameters, include);
        }

        public IEnumerable<T> ListWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereInclude(where, include);
        }

        public IEnumerable<TResult> ListWhereInclude<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereInclude<TResult>(where, include);
        }

        public PagedList<T> ListWhereInclude(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereInclude(parameters, where, include);
        }

        public PagedList<TResult> ListWhereInclude<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereInclude<TResult>(parameters, where, include);
        }

        public Task<IEnumerable<T>> ListWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereIncludeAsync(where, include);
        }

        public Task<IEnumerable<TResult>> ListWhereIncludeAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereIncludeAsync<TResult>(where, include);
        }

        public Task<PagedList<T>> ListWhereIncludeAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereIncludeAsync(parameters, where, include);
        }

        public Task<PagedList<TResult>> ListWhereIncludeAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.ListWhereIncludeAsync<TResult>(parameters, where, include);
        }

        public T SingleOrDefaultWhereInclude(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.SingleOrDefaultWhereInclude(where, include);
        }

        public Task<T> SingleOrDefaultWhereIncludeAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return EntityFrameworkCoreRelationalQueryRepository.SingleOrDefaultWhereIncludeAsync(where, include);
        }

        public TResult SingleOrDefaultWhereSelect<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return EntityFrameworkCoreRelationalQueryRepository.SingleOrDefaultWhereSelect(where, select);
        }

        public Task<TResult> SingleOrDefaultWhereSelectAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return EntityFrameworkCoreRelationalQueryRepository.SingleOrDefaultWhereSelectAsync(where, select);
        }
    }
}
