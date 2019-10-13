using System;
using System.Security.Principal;
using Microsoft.Win32;

#if NET462
using System.Security.Principal;
using Microsoft.Win32;

#endif

namespace aDevLib.Methods
{
    public class EnvironmentMethods
    {
        public static bool IsUnix() => Environment.OSVersion.Platform == PlatformID.Unix;
        public static bool IsWindows() => Environment.OSVersion.Platform == PlatformID.Win32NT;

        /// <summary>
        /// Checks current OS and throws <see cref="PlatformNotSupportedException"/> if it is not PlatformID.Win32NT.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Thrown if current OS is not Win32NT</exception>
        public static void IsWindowsGuard()
        {
            if (!IsWindows())
                throw new PlatformNotSupportedException();
        }
    }
}