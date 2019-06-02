using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace aDevLib.Methods
{
    public static class FileMethods
    {
        public static FileStream WaitForFile(string path, FileMode fileMode = FileMode.Create, TimeSpan timeout = default)
        {
            if (timeout == default)
                timeout = TimeSpan.FromSeconds(10);
            var time = Stopwatch.StartNew();
            while (time.ElapsedMilliseconds < timeout.TotalMilliseconds)
            {
                try
                {
                    return new FileStream(path, fileMode, FileAccess.ReadWrite, FileShare.Read);
                }
                catch (IOException e)
                {
                    // access error
                    if (e.HResult != -2147024864)
                        throw;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            throw new TimeoutException($"Failed to get a write handle to {path} within {timeout}");
        }
    }
}