using Confifu.Abstractions;
using Confifu.Abstractions.DependencyInjection;
using Confifu.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confifu.Logging.Microsoft
{
    public static class AppConfigExtensions
    {
        public static IAppConfig UseMicrosoftLogger(this IAppConfig appConfig, Action<ILoggingBuilder> configureAction = null)
        {
            var loggerFactory = new LoggerFactory();

            appConfig
                .RegisterServices(services =>
                {
                    services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory>(loggerFactory));
                    services.AddLogging(loggingBuilder => configureAction?.Invoke(loggingBuilder));
                })
                .SetLoggerFactoryFunc(() => loggerFactory);

            return appConfig;
        }
    }
}
