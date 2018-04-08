using System;

namespace aDevLib.Methods
{
    public class ArrayMethods
    {
        public static byte[] CombineArrays(byte[] array1, byte[] array2)
        {
            var newArray = new byte[array1.Length + array2.Length];
            Array.Copy(array1, newArray, array1.Length);
            Array.Copy(array2, 0, newArray, array1.Length, array2.Length);
            return newArray;
        }
    }
}