// -----------------------------------------------------------------------
// <copyright file="ValueTypeExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions
{
    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValueType Extensions.
    /// </summary>
    public static class ValueTypeExtensions
    {
        /// <summary>
        /// Elements at or null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        /// Result of ElementAtOrNull as Nullable{TSource}.
        /// </returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        public static TSource? ElementAtOrNull<TSource>([NotNull] this IEnumerable<TSource> source, int index)
            where TSource : struct
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (index >= 0)
            {
                if (source is IList<TSource> list)
                {
                    if (index < list.Count)
                    {
                        return list[index];
                    }
                }
                else
                {
                    return CurrentFromEnumerator(source, index);
                }
            }

            return null;
        }

        /// <summary>
        ///     Get element at index or is no element return null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///     Result of ElementAtOrNull as Nullable{TSource}.
        /// </returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        public static TSource? ElementAtOrNull<TSource>([NotNull] this IList<TSource> source, int index)
            where TSource : struct
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (index >= 0 && index < source.Count)
            {
                return source[index];
            }

            return null;
        }

        /// <summary>
        /// Gets the value or null.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TResult">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// Result of GeTResultOrNull as Nullable{TResult};.
        /// </returns>
        /// <exception cref="ArgumentNullException">dictionary is null.</exception>
        public static TResult? GetValueOrNull<TKey, TResult>(
            [NotNull] this IDictionary<TKey, TResult> dictionary,
            TKey key)
            where TResult : struct
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return null;
        }

        /// <summary>
        ///     Currents from enumerator.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///     Result of CurrentFromEnumerator as Nullable&lt;TSource&gt;.
        /// </returns>
        private static TSource? CurrentFromEnumerator<TSource>(IEnumerable<TSource> source, int index)
            where TSource : struct
        {
            using var e = source.GetEnumerator();
            while (true)
            {
                if (!e.MoveNext())
                {
                    break;
                }

                if (index == 0)
                {
                    return e.Current;
                }

                index--;
            }

            return null;
        }
    }
}