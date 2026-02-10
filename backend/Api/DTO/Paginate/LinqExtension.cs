using System.Linq.Expressions;

namespace Api.DTO;

public class LinqExtension
{
    private static LambdaExpression CreateExpression(Type type, string propertyName)
        {
            var param = Expression.Parameter(type, "x");

            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            return Expression.Lambda(body, param);
        }

        /// <summary>
        /// Sorts the elements of a sequence according to a key and the sort order.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="query"/>.
        /// </typeparam>
        /// <param name="query">A sequence of values to order.</param>
        /// <param name="key">
        /// Name of the property of <see cref="TSource"/> by which to sort the elements.
        /// </param>
        /// <param name="ascending">True for ascending order, false for descending order.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedQueryable`1"/> whose elements are sorted according to
        /// a key and sort order.
        /// </returns>
        public static IQueryable<TSource> OrderBy<TSource>(IQueryable<TSource> query, string key, bool reverse = false)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return query;
            }

            var lambda = (dynamic)CreateExpression(typeof(TSource), key);

            return reverse
                ? Queryable.OrderByDescending(query, lambda)
                : Queryable.OrderBy(query, lambda);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource>(IQueryable<TSource> query, string key, bool reverse = false)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return (IOrderedQueryable<TSource>)query;
            }

            var lambda = (dynamic)CreateExpression(typeof(TSource), key);

            return reverse
                ? Queryable.ThenByDescending((IOrderedQueryable<TSource>)query, lambda)
                : Queryable.ThenBy((IOrderedQueryable<TSource>)query, lambda);
        }
}