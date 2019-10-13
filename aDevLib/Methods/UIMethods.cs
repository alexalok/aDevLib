using System;
using System.Diagnostics;

namespace aDevLib.Methods
{
    public class UIMethods
    {
        public static bool OpenUrlInDefaultBrowser(string link)
        {
            EnvironmentMethods.IsWindowsGuard();
            
            var startInfo = new ProcessStartInfo(link)
            {
                UseShellExecute = true
            };
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception)
            {
                try
                {
                    startInfo.FileName = "IExplore.exe";
                    startInfo.Arguments = link;
                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    try
                    {
                        startInfo.FileName = "explorer.exe";
                        Process.Start(startInfo);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}