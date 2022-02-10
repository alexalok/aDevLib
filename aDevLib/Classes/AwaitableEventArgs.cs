using System.Threading.Tasks;

namespace aDevLib.Classes
{
    public class AwaitableEventArgs
    {
        readonly TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
        public   Task                         Task           => _tcs.Task;
        public   void                         SetCompleted() => _tcs.SetResult(null!);
    }
}