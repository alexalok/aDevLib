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

        /// <exception cref="PlatformNotSupportedException">Thrown if current OS is not Win32NT</exception>
        public static bool IsAdministrator =>
            new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        /// <exception cref="PlatformNotSupportedException">Thrown if current OS is not Win32NT</exception>
        public static NETFrameworkVersion GetNETFrameworkVersion()
        {
            return Get45PlusFromRegistry();
        }

        // Checking the version using >= will enable forward compatibility.
        static NETFrameworkVersion CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 461808)
                return NETFrameworkVersion.v472orNewer;
            if (releaseKey >= 461308)
                return NETFrameworkVersion.v471;
            if (releaseKey >= 460798)
                return NETFrameworkVersion.v47;
            if (releaseKey >= 394802)
                return NETFrameworkVersion.v462;
            if (releaseKey >= 394254)
                return NETFrameworkVersion.v461;
            if (releaseKey >= 393295)
                return NETFrameworkVersion.v46;
            if (releaseKey >= 379893)
                return NETFrameworkVersion.v452;
            if (releaseKey >= 378675)
                return NETFrameworkVersion.v451;
            if (releaseKey >= 378389)
                return NETFrameworkVersion.v45;
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return NETFrameworkVersion.NotDetected;
        }

        static NETFrameworkVersion Get45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                return ndpKey?.GetValue("Release") != null ?
                    CheckFor45PlusVersion((int)ndpKey.GetValue("Release")) :
                    NETFrameworkVersion.NotDetected;
            }
        }
    }

    public enum NETFrameworkVersion
    {
        NotDetected,
        v45,
        v451,
        v452,
        v46,
        v461,
        v462,
        v47,
        v471,
        v472orNewer,
    }
}