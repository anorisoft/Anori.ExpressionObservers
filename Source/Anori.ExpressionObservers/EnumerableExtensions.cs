using System;
using System.Collections.Generic;
using Anori.ExpressionObservers;
using JetBrains.Annotations;
using Anori.Extensions;

namespace Anori.ExpressionObservers
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Values at or null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static TSource? ValueAtOrNull<TSource>([NotNull] this IEnumerable<TSource> source, int index)
            where TSource : struct
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ElementAtOrNull(index);
        }

        /// <summary>
        /// References at or null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static TSource ReferenceAtOrNull<TSource>([NotNull] this IEnumerable<TSource> source, int index)
            where TSource : class
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ElementAtOrNull(index);
        }

        /// <summary>
        /// Values at or null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static TSource? ValueAtOrNull<TSource>([NotNull] this IList<TSource> source, int index)
            where TSource : struct
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ElementAtOrNull(index);
        }

        /// <summary>
        /// References at or null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static TSource ReferenceAtOrNull<TSource>([NotNull] this IList<TSource> source, int index)
            where TSource : class
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ElementAtOrNull(index);
        }
    }
}