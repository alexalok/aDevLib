namespace aDevLibStandard.Extensions.CollectionsExtensions
{
    public static class ArrayExtensions
    {
        public static bool TryGetElement<T>(this T[] array, int index, out T element)
        {
            if (index < array.Length)
            {
                element = array[index];
                return true;
            }
            element = default(T);
            return false;
        }
    }
}