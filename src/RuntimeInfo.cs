using System;
using System.Runtime;
using System.Runtime.InteropServices;

namespace YA.Common
{
    public enum OsPlatforms
    {
        Unknown = 0,
        Windows = 1,
        Linux = 2,
        OSX = 4
    }

    public static class RuntimeInfo
    {
        // See: https://github.com/dotnet/BenchmarkDotNet/issues/448#issuecomment-308424100
        public static string GetNetCoreVersion()
        {
            var assembly = typeof(GCSettings).Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            return netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2
                ? assemblyPath[netCoreAppIndex + 1]
                : null;
        }

        public static OsPlatforms GetOs()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OsPlatforms.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OsPlatforms.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsPlatforms.OSX;
            }
            else
            {
                return OsPlatforms.Unknown;
            }
        }
    }
}
