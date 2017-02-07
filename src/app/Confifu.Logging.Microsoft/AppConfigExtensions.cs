using Confifu.Abstractions;
using Confifu.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confifu.Logging.Microsoft
{
    public static class AppConfigExtensions
    {
        public static IAppConfig UseMicrosoftLogger(this IAppConfig appConfig, Action<ILoggerFactory> configureAction)
        {
            var loggerFactory = new LoggerFactory();

            configureAction?.Invoke(loggerFactory);

            appConfig.SetLoggerFactoryFunc(() => loggerFactory);

            return appConfig;
        }
    }
}
