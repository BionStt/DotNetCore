using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.Repositories
{
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
}
