﻿using System.Collections.Generic;
using System.Linq;
using aDevLib.Classes;

namespace aDevLib.Extensions.CollectionsExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns random element from IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iEnum"></param>
        /// <returns></returns>
        public static T GetRandom<T>(this IReadOnlyCollection<T> iEnum) => iEnum.ElementAt(SRandom.Next(0, iEnum.Count));

        public static bool TryGetElement<T>(this IEnumerable<T> enumerable, int index, out T? element)
        {
            var enumAsArray = enumerable as T[] ?? enumerable.ToArray();
            if (index < enumAsArray.Length)
            {
                element = enumAsArray.ElementAt(index);
                return true;
            }
            element = default;
            return false;
        }
    }
}