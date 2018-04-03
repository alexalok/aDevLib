using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TTC.Utils.Environment.Entities;
using TTC.Utils.Environment.Queries;
using TTC.Utils.Environment.Services;

namespace aDevLib.Extensions
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
            CancellationToken cancellationToken = default(CancellationToken)) =>
            aDevLibStandard.Extensions.ProcessExtensions.WaitForExitAsync(process, cancellationToken);

        [CanBeNull]
        [UsedImplicitly]
        public static string GetCommandLine(this Process process, bool tryRemoveExePath = false)
        {
            var wmiService = new WmiService();
            WmiProcess query;
            try
            {
                query = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            }
            catch (Win32Exception)
            {
                return null;
            }
            string cmdLine = query?.CommandLine;
            if (string.IsNullOrEmpty(cmdLine)) //probs not authorized
                return null;
            if (!tryRemoveExePath) return cmdLine;

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

        [UsedImplicitly]
        [CanBeNull]
        public static Process GetParent(this Process process)
        {
            var wmiService = new WmiService();
            var query = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            int parentProcId = query.ParentProcessId;
            if (parentProcId == 0)
                return null;
            var parentProcess = Process.GetProcessById(parentProcId);
            return parentProcess;
        }

        [UsedImplicitly]
        [CanBeNull]
        public static string GetProcessPath(this Process process)
        {
            var wmiService = new WmiService();
            var query = wmiService.QueryFirst<WmiProcess>(new WmiProcessQuery(process));
            return query.ExecutablePath;
        }
    }
}