using Confifu.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace Confifu.Logging.Abstractions
{
    public static class AppConfigExtensions
    {
        private const string LoggerFactoryKey = "LoggerFactory";

        public static IAppConfig SetLoggerFactoryFunc(this IAppConfig appConfig, Func<ILoggerFactory> loggerFactory)
        {
            appConfig[LoggerFactoryKey] = loggerFactory;
            return appConfig;
        }

        public static Func<ILoggerFactory> GetLoggerFactoryFunc(this IAppConfig appConfig) 
            => appConfig[LoggerFactoryKey] as Func<ILoggerFactory>;

        public static ILoggerFactory ResolveLoggerFactory(this IAppConfig appConfig) 
            => appConfig.GetLoggerFactoryFunc()?.Invoke();

        public static ILogger GetLogger(this IAppConfig appConfig, string categoryName)
            => appConfig.ResolveLoggerFactory()?.CreateLogger(categoryName);

        public static ILogger GetLogger<T>(this IAppConfig appConfig)
            => appConfig.ResolveLoggerFactory()?.CreateLogger<T>();
    }
}
