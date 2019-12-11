using DotNetCore.Objects;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.MongoDB
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        public MongoRepository(IMongoContext context)
        {
            MongoCommandRepository = new MongoCommandRepository<T>(context);
            MongoQueryRepository = new MongoQueryRepository<T>(context);
        }

        private MongoCommandRepository<T> MongoCommandRepository { get; }

        private MongoQueryRepository<T> MongoQueryRepository { get; }

        public void Add(T item)
        {
            MongoCommandRepository.Add(item);
        }

        public Task AddAsync(T item)
        {
            return MongoCommandRepository.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            MongoCommandRepository.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return MongoCommandRepository.AddRangeAsync(items);
        }

        public bool Any()
        {
            return MongoQueryRepository.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return MongoQueryRepository.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.AnyAsync(where);
        }

        public long Count()
        {
            return MongoQueryRepository.Count();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.Count(where);
        }

        public Task<long> CountAsync()
        {
            return MongoQueryRepository.CountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.CountAsync(where);
        }

        public void Delete(object key)
        {
            MongoCommandRepository.Delete(key);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            MongoCommandRepository.Delete(where);
        }

        public Task DeleteAsync(object key)
        {
            return MongoCommandRepository.DeleteAsync(key);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return MongoCommandRepository.DeleteAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.FirstOrDefault(where);
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.FirstOrDefault<TResult>(where);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.FirstOrDefaultAsync(where);
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.FirstOrDefaultAsync<TResult>(where);
        }

        public IEnumerable<T> List()
        {
            return MongoQueryRepository.List();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.List(where);
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return MongoQueryRepository.List<TResult>();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.List<TResult>(where);
        }

        public PagedList<T> List(PagedListParameters parameters)
        {
            return MongoQueryRepository.List(parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters)
        {
            return MongoQueryRepository.List<TResult>(parameters);
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.ListAsync(where);
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return MongoQueryRepository.ListAsync();
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return MongoQueryRepository.ListAsync<TResult>();
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.ListAsync<TResult>(where);
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters)
        {
            return MongoQueryRepository.ListAsync(parameters);
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters)
        {
            return MongoQueryRepository.ListAsync<TResult>(parameters);
        }

        public T Select(object key)
        {
            return MongoQueryRepository.Select(key);
        }

        public TResult Select<TResult>(object key)
        {
            return MongoQueryRepository.Select<TResult>(key);
        }

        public Task<T> SelectAsync(object key)
        {
            return MongoQueryRepository.SelectAsync(key);
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return MongoQueryRepository.SelectAsync<TResult>(key);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.SingleOrDefault(where);
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.SingleOrDefault<TResult>(where);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.SingleOrDefaultAsync(where);
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return MongoQueryRepository.SingleOrDefaultAsync<TResult>(where);
        }

        public void Update(object key, T item)
        {
            MongoCommandRepository.Update(key, item);
        }

        public Task UpdateAsync(object key, T item)
        {
            return MongoCommandRepository.UpdateAsync(key, item);
        }

        public void UpdatePartial(object key, object item)
        {
            MongoCommandRepository.UpdatePartial(key, item);
        }

        public Task UpdatePartialAsync(object key, object item)
        {
            return MongoCommandRepository.UpdatePartialAsync(key, item);
        }
    }
}
