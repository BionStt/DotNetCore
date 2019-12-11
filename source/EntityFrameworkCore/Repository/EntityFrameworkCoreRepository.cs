using DotNetCore.Objects;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<T> : IRepository<T> where T : class
    {
        public EntityFrameworkCoreRepository(DbContext context)
        {
            EntityFrameworkCoreCommandRepository = new EntityFrameworkCoreCommandRepository<T>(context);
            EntityFrameworkCoreQueryRepository = new EntityFrameworkCoreQueryRepository<T>(context);
        }

        private EntityFrameworkCoreCommandRepository<T> EntityFrameworkCoreCommandRepository { get; }

        private EntityFrameworkCoreQueryRepository<T> EntityFrameworkCoreQueryRepository { get; }

        public void Add(T item)
        {
            EntityFrameworkCoreCommandRepository.Add(item);
        }

        public Task AddAsync(T item)
        {
            return EntityFrameworkCoreCommandRepository.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            EntityFrameworkCoreCommandRepository.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return EntityFrameworkCoreCommandRepository.AddRangeAsync(items);
        }

        public bool Any()
        {
            return EntityFrameworkCoreQueryRepository.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return EntityFrameworkCoreQueryRepository.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.AnyAsync(where);
        }

        public long Count()
        {
            return EntityFrameworkCoreQueryRepository.Count();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.Count(where);
        }

        public Task<long> CountAsync()
        {
            return EntityFrameworkCoreQueryRepository.CountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.CountAsync(where);
        }

        public void Delete(object key)
        {
            EntityFrameworkCoreCommandRepository.Delete(key);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            EntityFrameworkCoreCommandRepository.Delete(where);
        }

        public Task DeleteAsync(object key)
        {
            return EntityFrameworkCoreCommandRepository.DeleteAsync(key);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreCommandRepository.DeleteAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.FirstOrDefault(where);
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.FirstOrDefault<TResult>(where);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.FirstOrDefaultAsync(where);
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.FirstOrDefaultAsync<TResult>(where);
        }

        public IEnumerable<T> List()
        {
            return EntityFrameworkCoreQueryRepository.List();
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return EntityFrameworkCoreQueryRepository.List<TResult>();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.List(where);
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.List<TResult>(where);
        }

        public PagedList<T> List(PagedListParameters parameters)
        {
            return EntityFrameworkCoreQueryRepository.List(parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters)
        {
            return EntityFrameworkCoreQueryRepository.List<TResult>(parameters);
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return EntityFrameworkCoreQueryRepository.ListAsync();
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return EntityFrameworkCoreQueryRepository.ListAsync<TResult>();
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.ListAsync(where);
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.ListAsync<TResult>(where);
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters)
        {
            return EntityFrameworkCoreQueryRepository.ListAsync(parameters);
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters)
        {
            return EntityFrameworkCoreQueryRepository.ListAsync<TResult>(parameters);
        }

        public T Select(object key)
        {
            return EntityFrameworkCoreQueryRepository.Select(key);
        }

        public TResult Select<TResult>(object key)
        {
            return EntityFrameworkCoreQueryRepository.Select<TResult>(key);
        }

        public Task<T> SelectAsync(object key)
        {
            return EntityFrameworkCoreQueryRepository.SelectAsync(key);
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return EntityFrameworkCoreQueryRepository.SelectAsync<TResult>(key);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.SingleOrDefault(where);
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.SingleOrDefault<TResult>(where);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.SingleOrDefaultAsync(where);
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return EntityFrameworkCoreQueryRepository.SingleOrDefaultAsync<TResult>(where);
        }

        public void Update(object key, T item)
        {
            EntityFrameworkCoreCommandRepository.Update(key, item);
        }

        public Task UpdateAsync(object key, T item)
        {
            return EntityFrameworkCoreCommandRepository.UpdateAsync(key, item);
        }

        public void UpdatePartial(object key, object item)
        {
            EntityFrameworkCoreCommandRepository.UpdatePartial(key, item);
        }

        public Task UpdatePartialAsync(object key, object item)
        {
            return EntityFrameworkCoreCommandRepository.UpdatePartialAsync(key, item);
        }
    }
}
