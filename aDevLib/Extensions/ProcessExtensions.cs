using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.Linq;

namespace aDevLib.Extensions
{
    public static class ProcessExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws if the process has already exited</exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="TaskCanceledException"></exception>
        public static Task WaitForExitAsync(this Process process,
                                            TimeSpan     timeout = default)
        {
            var cts = timeout == default ? null : new CancellationTokenSource(timeout);
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents =  true;
            process.Exited              += (sender, args) => tcs.TrySetResult(null);
            cts?.Token.Register(() => tcs.TrySetCanceled());
            return tcs.Task;
        }
    }
}