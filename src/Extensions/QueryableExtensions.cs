using System;
using System.Linq;
using System.Threading.Tasks;

namespace YA.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> If<T>(this IQueryable<T> enumerable, bool condition, Func<IQueryable<T>, IQueryable<T>> action)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (condition)
            {
                return action(enumerable);
            }

            return enumerable;
        }

        public static async Task<IQueryable<T>> IfAsync<T>(this IQueryable<T> enumerable, bool condition, Func<IQueryable<T>, Task<IQueryable<T>>> action)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (condition)
            {
                return await action(enumerable);
            }

            return enumerable;
        }

        public static IQueryable<T> IfElse<T>(this IQueryable<T> enumerable, bool condition, Func<IQueryable<T>, IQueryable<T>> ifAction, Func<IQueryable<T>, IQueryable<T>> elseAction)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (ifAction is null)
            {
                throw new ArgumentNullException(nameof(ifAction));
            }

            if (elseAction is null)
            {
                throw new ArgumentNullException(nameof(elseAction));
            }

            if (condition)
            {
                return ifAction(enumerable);
            }
            else
            {
                return elseAction(enumerable);
            }
        }
    }
}
