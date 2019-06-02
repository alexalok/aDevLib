using System.Collections.Generic;

namespace aDevLib.Classes
{
    public class LimitedSizeStack<T> : LinkedList<T>
    {
        readonly int _maxSize;

        public LimitedSizeStack(int maxSize)
        {
            _maxSize = maxSize;
        }

        public void Push(T item)
        {
            AddFirst(item);

            if (Count > _maxSize)
                RemoveLast();
        }

        public T Pop()
        {
            var item = First.Value;
            RemoveFirst();
            return item;
        }
    }
}