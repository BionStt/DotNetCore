using DotNetCore.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.MongoDB
{
    public class MongoCommandRepository<T> : ICommandRepository<T> where T : class
    {
        public MongoCommandRepository(IMongoContext context)
        {
            Collection = context.Database.GetCollection<T>(typeof(T).Name);
        }

        private IMongoCollection<T> Collection { get; }

        public void Add(T item)
        {
            Collection.InsertOne(item);
        }

        public Task AddAsync(T item)
        {
            return Collection.InsertOneAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return Collection.InsertManyAsync(items);
        }

        public void Delete(object key)
        {
            Collection.DeleteOne(FilterId(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Collection.DeleteMany(where);
        }

        public Task DeleteAsync(object key)
        {
            return Collection.DeleteOneAsync(FilterId(key));
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return Collection.DeleteManyAsync(where);
        }

        public void Update(object key, T item)
        {
            Collection.ReplaceOne(FilterId(key), item);
        }

        public Task UpdateAsync(object key, T item)
        {
            return Collection.ReplaceOneAsync(FilterId(key), item);
        }

        public void UpdatePartial(object key, object item)
        {
            Collection.ReplaceOne(FilterId(key), item as T);
        }

        public Task UpdatePartialAsync(object key, object item)
        {
            return Collection.ReplaceOneAsync(FilterId(key), item as T);
        }

        private static FilterDefinition<T> FilterId(object key)
        {
            return Builders<T>.Filter.Eq("Id", key);
        }
    }
}
