using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCore.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Order<T>(this IQueryable<T> queryable, string property, bool ascending)
        {
            if (queryable == default || string.IsNullOrEmpty(property))
            {
                return queryable;
            }

            var properties = property.Split('.');

            var parameterExpression = Expression.Parameter(typeof(T));

            var expressionBody = properties.Aggregate<string, Expression>(parameterExpression, Expression.Property);

            expressionBody = Expression.Convert(expressionBody, typeof(object));

            var expression = Expression.Lambda<Func<T, object>>(expressionBody, parameterExpression).Compile();

            return ascending ? queryable.OrderBy(expression).AsQueryable() : queryable.OrderByDescending(expression).AsQueryable();
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, int size)
        {
            if (queryable == default || !queryable.Any() || index == 0 || size == 0)
            {
                return queryable;
            }

            return queryable.Skip((index - 1) * size).Take(size);
        }
    }
}
