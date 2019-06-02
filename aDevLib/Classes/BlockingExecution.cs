using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace aDevLib.Classes
{
    public class BlockingExecution
    {
        readonly SemaphoreSlim    _semaphore                = new SemaphoreSlim(1, 1);
        readonly DisposableObject _disposableObject         = new DisposableObject();
        readonly TimeSpan         _blockingOperationTimeout = TimeSpan.FromSeconds(30);


        public BlockingExecution(TimeSpan timeout) : this()
        {
            _blockingOperationTimeout = timeout;
        }

        public BlockingExecution()
        {
            _disposableObject.ObjectDisposed += _disposableObject_ObjectDisposed;
        }

        public async Task<IDisposable> BeginBlocking()
        {
            if (!await _semaphore.WaitAsync(_blockingOperationTimeout))
                throw new TaskCanceledException("Waiting for semaphore to become available has timed out.");
            return _disposableObject;
        }

        public void EndBlocking()
        {
            _disposableObject.Dispose();
        }

        void _disposableObject_ObjectDisposed(object sender, EventArgs e)
        {
            _semaphore.Release();
        }

        class DisposableObject : IDisposable
        {
            public event EventHandler ObjectDisposed;

            public void Dispose()
            {
                ObjectDisposed(this, EventArgs.Empty);
            }
        }
    }
}