// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions
{

    /// <summary>
    /// The String Extensions class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indexes the of any character.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="toFind">To find.</param>
        /// <returns>Index and Char.</returns>
        public static (int index, char value) IndexOfAnyChar(this string? s, params char[] toFind)
        {
            if (s == null)
            {
                return (-1, default(char));
            }

            if (null == toFind || toFind.Length <= 0)
            {
                return (-1, default(char));
            }

            var bestIndex = -1;
            var bestChar = default(char);

            foreach (var c in toFind)
            {
                var index = s.IndexOf(c, 0, bestIndex < 0 ? s.Length : bestIndex);

                if (index >= 0)
                {
                    bestIndex = index;
                    bestChar = c;
                }
            }

            return (bestIndex, bestChar);
        }

        /// <summary>
        ///     Indexes the of any character.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="toFind">To find.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>Index and Char.</returns>
        public static (int index, char value) IndexOfAnyChar(this string? s, char[] toFind, int startIndex)
        {
            if (s == null)
            {
                return (-1, default(char));
            }

            if (null == toFind || toFind.Length <= 0)
            {
                return (-1, default(char));
            }

            var bestIndex = -1;
            var bestChar = default(char);

            foreach (var c in toFind)
            {
                var index = s.IndexOf(c, startIndex, bestIndex < 0 ? s.Length - startIndex : bestIndex - startIndex);

                if (index >= 0)
                {
                    bestIndex = index;
                    bestChar = c;
                }
            }

            return (bestIndex, bestChar);
        }
    }
}