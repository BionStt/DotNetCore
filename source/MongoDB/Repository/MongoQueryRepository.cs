using DotNetCore.Mapping;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.MongoDB
{
    public class MongoQueryRepository<T> : IQueryRepository<T> where T : class
    {
        public MongoQueryRepository(IMongoContext context)
        {
            Collection = context.Database.GetCollection<T>(typeof(T).Name);
        }

        private IMongoCollection<T> Collection { get; }

        public bool Any()
        {
            return Collection.Find(new BsonDocument()).Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).Any();
        }

        public Task<bool> AnyAsync()
        {
            return Collection.Find(new BsonDocument()).AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).AnyAsync();
        }

        public long Count()
        {
            return Collection.CountDocuments(new BsonDocument());
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocuments(where);
        }

        public Task<long> CountAsync()
        {
            return Collection.CountDocumentsAsync(new BsonDocument());
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocumentsAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefault();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return FirstOrDefault(where).Map<TResult>();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefaultAsync();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(FirstOrDefaultAsync(where).Result.Map<TResult>());
        }

        public IEnumerable<T> List()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).ToList();
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return List().Map<IEnumerable<TResult>>();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return List(where).Map<IEnumerable<TResult>>();
        }

        public PagedList<T> List(PagedListParameters parameters)
        {
            return new PagedList<T>(Collection.AsQueryable(), parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters)
        {
            return List(parameters).Map<PagedList<TResult>>();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return Task.FromResult(ListAsync().Map<IEnumerable<TResult>>());
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(ListAsync(where).Map<IEnumerable<TResult>>());
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters)
        {
            return Task.FromResult(List(parameters));
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters)
        {
            return Task.FromResult(List<TResult>(parameters));
        }

        public T Select(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefault();
        }

        public TResult Select<TResult>(object key)
        {
            return Select(key).Map<TResult>();
        }

        public Task<T> SelectAsync(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefaultAsync();
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return Task.FromResult(SelectAsync(key).Result.Map<TResult>());
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefault();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return SingleOrDefault(where).Map<TResult>();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefaultAsync();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(SingleOrDefaultAsync(where).Result.Map<TResult>());
        }

        private static FilterDefinition<T> FilterId(object key)
        {
            return Builders<T>.Filter.Eq("Id", key);
        }
    }
}
