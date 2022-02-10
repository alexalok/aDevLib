using System;
using System.Linq;
using JetBrains.Annotations;

namespace aDevLib.Extensions.CollectionsExtensions
{
    public static class ArrayExtensions
    {
        public static bool TryGetElement<T>(this T[] array, int index, out T? element)
        {
            if (index < array.Length)
            {
                element = array[index];
                return true;
            }
            element = default;
            return false;
        }

        [Pure]
        public static T[] AppendArray<T>(this T[] array1, T[] array2)
        {
            var newArray = new T[array1.Length + array2.Length];
            Array.Copy(array1, newArray, array1.Length);
            Array.Copy(array2, 0,        newArray, array1.Length, array2.Length);
            return newArray;
        }

        public static Tuple<T[], T[]> SplitArray<T>(this T[] array, int index)
        {
            var first  = array.Take(index).ToArray();
            var second = array.Skip(index).ToArray();
            return Tuple.Create(first, second);
        }
    }
}