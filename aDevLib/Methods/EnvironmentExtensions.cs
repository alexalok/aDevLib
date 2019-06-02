using System;

namespace aDevLib.Methods
{
    public static class EnvironmentExtensions
    {
        public static bool IsUnix() => Environment.OSVersion.Platform == PlatformID.Unix;
        public static bool IsWindows() => Environment.OSVersion.Platform == PlatformID.Win32NT;
    }
}