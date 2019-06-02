using System.Collections.Generic;
using System.Reflection;

namespace aDevLib.Methods
{
    [Obfuscation(Exclude = true, ApplyToMembers = true)]
    public static class GenericsArithmeticsMethods<T>
    {
        public static T Add(params T[] members)
        {
            var membersStack = new Stack<T>(members);
            while (membersStack.Count > 1)
            {
                dynamic a = membersStack.Pop();
                dynamic b = membersStack.Pop();
                var sum = a + b;
                membersStack.Push(sum);
            }
            return membersStack.Pop();
        }
    }
}