using System;

namespace aDevLibStandard.Methods
{
    public class EnvironmentMethods
    {
        public static bool IsUnix()
        {
            var p = (int) Environment.OSVersion.Platform;
            return (p == 4) || (p == 6) || (p == 128);
        }
    }
}