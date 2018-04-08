using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace aDevLibStandard.Extensions
{
    public static class ProcessExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws if the process have already exited</exception>
        /// <exception cref="Win32Exception"></exception>
        public static Task WaitForExitAsync(this Process process,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register(() => tcs.TrySetCanceled());

            return tcs.Task;
        }
    }
}