using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace YA.Common
{
    public static class LoggerExtensions
    {
        public static IDisposable BeginScopeWith(this ILogger logger, params (string key, object value)[] keys)
        {
            return logger.BeginScope(keys.ToDictionary(x => x.key, x => x.value));
        }

        public static bool LogException(this ILogger logger, Exception ex, params (string key, object value)[] stateKeys)
        {
            logger.Log(LogLevel.Error, 0, stateKeys.ToDictionary(x => x.key, x => x.value), ex.Demystify(), (s, e) => "Unhandled exception occured.");
            return true;
        }
    }
}
