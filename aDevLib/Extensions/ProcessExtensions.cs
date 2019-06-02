using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

#if NET462

using System.Linq;
using System.Management;
using TTC.Utils.Environment.Entities;
using TTC.Utils.Environment.Queries;
using TTC.Utils.Environment.Services;

#endif

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

#if NET462
        [CanBeNull]
        public static string GetCommandLine(this Process process, bool tryRemoveExePath = false)
        {
            var        wmiService = new WmiService();
            WmiProcess query;
            try
            {
                query = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            }
            catch (Exception ex)
            {
                if (ex is Win32Exception ||
                    ex is ManagementException ||
                    ex is COMException ||
                    ex is UnauthorizedAccessException)
                    return null;
                throw;
            }

            string cmdLine = query?.CommandLine;
            if (string.IsNullOrEmpty(cmdLine)) //probs not authorized
                return null;
            if (!tryRemoveExePath)
                return cmdLine;

            //"D:\Programs\Notepad++\notepad++.exe"  
            var splitResult = cmdLine.Trim().Split(new[] {".exe"}, StringSplitOptions.RemoveEmptyEntries);
            if (splitResult.Length <= 1) //only path is available
                return string.Empty;

            if (splitResult[1][0] == '\"')
            {
                if (splitResult[1].Length > 1)
                    splitResult[1] = new string(splitResult[1].Skip(1).ToArray());
                else //there is nothing in cmdline part
                    return string.Empty;
            }

            return string.Join(".exe", splitResult.Skip(1));
        }

        [CanBeNull]
        public static Process GetParent(this Process process)
        {
            var wmiService   = new WmiService();
            var query        = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            int parentProcId = query.ParentProcessId;
            if (parentProcId == 0)
                return null;
            var parentProcess = Process.GetProcessById(parentProcId);
            return parentProcess;
        }

        [CanBeNull]
        public static string GetProcessPath(this Process process)
        {
            var wmiService = new WmiService();
            var query      = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            return query.ExecutablePath;
        }
#endif
    }
}