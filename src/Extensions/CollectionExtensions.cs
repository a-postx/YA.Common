using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YA.Common.Extensions
{
    public static class CollectionExtensions
    {
        ///<summary>Splits a list into sublists based on the specified batch size.</summary>
        ///<param name="batchSize">The number of items in a batch.</param>
        ///<returns>A set of lists.</returns>
        public static IEnumerable<List<T>> SplitList<T>(this List<T> list, int batchSize)
        {
            if (batchSize > 0)
            {
                for (int i = 0; i < list.Count; i += batchSize)
                {
                    yield return list.GetRange(i, Math.Min(batchSize, list.Count - i));
                }
            }
        }

        ///<summary>Splits a collection into subcollections based on the specified batch size.</summary>
        ///<param name="batchSize">The number of items in a batch.</param>
        ///<returns>A set of lists.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int batchSize)
        {
            return list.Select((item, index) => new { index, item })
                       .GroupBy(x => x.index % batchSize)
                       .Select(x => x.Select(y => y.item));
        }

        ///<summary>Converts a list items into string using StringBuilder.</summary>
        public static string ListToString(this IList list)
        {
            StringBuilder result = new StringBuilder(string.Empty);

            if (list.Count > 0)
            {
                result.Append(list[0]);
                for (int i = 1; i < list.Count; i++)
                    result.AppendFormat(",{0}", list[i]);
            }

            return result.ToString();
        }

        public static IEnumerable<T> If<T>(this IEnumerable<T> enumerable, bool condition, Func<IEnumerable<T>, IEnumerable<T>> action)
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

        public static async Task<IEnumerable<T>> IfAsync<T>(this IEnumerable<T> enumerable, bool condition, Func<IEnumerable<T>, Task<IEnumerable<T>>> action)
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
    }
}
