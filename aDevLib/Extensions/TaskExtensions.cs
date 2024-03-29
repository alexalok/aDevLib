﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace aDevLib.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task; // Very important in order to propagate exceptions
                }
                throw new TaskCanceledException("The operation has timed out.");
            }
        }

        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return; // Very important in order to propagate exceptions
                }
                throw new TaskCanceledException("The operation has timed out.");
            }
        }

        public static async void RunNonAwaitable(this Task task, Action<Exception> onExceptionDelegate)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                onExceptionDelegate(ex);
            }
        }

        public static void RunNonAwaitable(this Task task)
        {
            RunNonAwaitable(task, e => { });
        }
    }
}