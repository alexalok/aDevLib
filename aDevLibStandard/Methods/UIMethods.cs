using System;
using System.Diagnostics;

namespace aDevLibStandard.Methods
{
    public class UIMethods
    {
        public static bool OpenUrlInDefaultBrowser(string link)
        {
            try
            {
                Process.Start(link);
            }
            catch (Exception)
            {
                try
                {
                    Process.Start("IExplore.exe", link);
                }
                catch (Exception)
                {
                    try
                    {
                        Process.Start("explorer.exe", link);
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