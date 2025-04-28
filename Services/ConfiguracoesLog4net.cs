using System.IO;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Repository;
using log4net;

namespace Comunix.Funcoes.Configuracoes
{
    /// <summary>
    /// ConfigurarLog4Net
    /// </summary>
    public class ConfiguracoesLog4net
    {
        public static void Configurar(string dirAppLogs, string applicationName)
        {
            //var diretorio = Path.Combine(dirTrabalho, applicationName);
            //if (string.IsNullOrEmpty(diretorio))
            //    diretorio = @".\log\Diario.log";

            var rollingFileErrorAppender = new RollingFileAppender
            {
                Name = "RollingLogFileErrorAppender",
                File = dirAppLogs + applicationName + "_Error.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = "'_'yyyyMMdd",
                PreserveLogFileNameExtension = true,
                ImmediateFlush = true,
                Layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss.fff} %-5level - %message%newline")
            };
            rollingFileErrorAppender.ActivateOptions();

            var rollingFileAppender = new RollingFileAppender
            {
                Name = "RollingLogFileAppender",
                //File = Path.Combine(diretorio, "Diario.log"),
                File = dirAppLogs + applicationName + ".log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = "'_'yyyyMMdd",
                PreserveLogFileNameExtension = true,
                ImmediateFlush = true,
                Layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss.fff} %-5level - %message%newline")
            };
            rollingFileAppender.ActivateOptions();

            var consoleAppender = new ConsoleAppender
            {
                Name = "ConsoleLoggerAppender",
                Layout = new PatternLayout("[%date{HH:mm:ss} %-5level] %message%newline")
            };
            consoleAppender.ActivateOptions();

            ILoggerRepository repository = LogManager.GetRepository();
            IAppender[] appenders = { rollingFileErrorAppender, rollingFileAppender, consoleAppender };
            BasicConfigurator.Configure(repository, appenders);

            // Get Logger Hierarchy
            var hierarchy = (Hierarchy)repository;
            hierarchy.Configured = false;

            // FileLogger
            var fileLogger = hierarchy.GetLogger("FileLogger") as Logger;
            fileLogger.Level = Level.All;
            fileLogger.Additivity = false; // Evita herança do logger raiz
            fileLogger.AddAppender(rollingFileAppender);

            // FileLoggerError
            var errorLogger = hierarchy.GetLogger("FileLoggerError") as Logger;
            errorLogger.Level = Level.All;
            errorLogger.Additivity = false; // Evita herança do logger raiz
            errorLogger.AddAppender(rollingFileErrorAppender);

            // ConsoleLogger
            var consoleLogger = hierarchy.GetLogger("ConsoleLogger") as Logger;
            consoleLogger.Level = Level.All;
            consoleLogger.Additivity = false;
            consoleLogger.AddAppender(consoleAppender);

            // Configurar repositório
            hierarchy.Configured = true;

        }

    }
}
