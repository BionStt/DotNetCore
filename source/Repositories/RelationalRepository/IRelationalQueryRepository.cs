using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.Repositories
{
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
}
