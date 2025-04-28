using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Comunix.Funcoes.Geral
{
    public static class LoggerService
    {
        private static Assembly _assembly = null;

        public static void Configurar(Assembly assembly)
        {
            _assembly = assembly;
            log4net.Config.XmlConfigurator.Configure(LogManager.GetRepository(_assembly));
        }

        public static void Debug(string mensagem)
        {
            if (_assembly == null)
                Configurar(Assembly.GetCallingAssembly());

            var FileLogger = LogManager.GetLogger(_assembly, "FileLogger");
            FileLogger.Debug(mensagem);
        }

        public static void Information(string mensagem)
        {
            if (_assembly == null)
                Configurar(Assembly.GetCallingAssembly());

            var FileLogger = LogManager.GetLogger(_assembly, "FileLogger");
            FileLogger.Info(mensagem);

            if (IsConsoleApplication())
            {
                var ConsoleLogger = LogManager.GetLogger(_assembly, "ConsoleLogger");
                ConsoleLogger.Info(mensagem);
            }
        }

        public static void Warning(string mensagem)
        {
            if (_assembly == null)
                Configurar(Assembly.GetCallingAssembly());

            if (IsConsoleApplication())
            {
                var ConsoleLogger = LogManager.GetLogger(_assembly, "ConsoleLogger");
                ConsoleLogger.Warn(mensagem);
            }

            var FileLogger = LogManager.GetLogger(_assembly, "FileLogger");
            FileLogger.Warn(mensagem);

            var FileLoggerError = LogManager.GetLogger(_assembly, "FileLoggerError");
            FileLoggerError.Warn(mensagem);
        }

        public static void Error(string mensagem, Exception ex = null)
        {
            try
            {
                if (_assembly == null)
                    Configurar(Assembly.GetCallingAssembly());

                if (IsConsoleApplication())
                {
                    var ConsoleLogger = LogManager.GetLogger(_assembly, "ConsoleLogger");
                    ConsoleLogger.Error(mensagem);
                }

                var FileLogger = LogManager.GetLogger(_assembly, "FileLogger");
                FileLogger.Error(mensagem, ex);

                var FileLoggerError = LogManager.GetLogger(_assembly, "FileLoggerError");
                FileLoggerError.Error(mensagem, ex);
            }
            catch (Exception exception)
            {
                DebugEmArquivoTxt("LoggerService.Error", "", "Mensagem:" + mensagem + "\n" + "Exception:" + exception.Message);
            }
        }


        #region Classes de log apenas para facilitar a chamada

        /// <summary>
        /// Log de erros
        /// </summary>
        /// <param name="nomeFuncao">Nome da funcao/metodo onde foi gerado o evento</param>
        /// <param name="codInterno">Codigo interno unico que identifica o ponto da gravação</param>
        /// <param name="mensagem">Mensagem de erro</param>
        public static void Erro(string nomeFuncao, string codInterno, string mensagem)
        {
            Error(LinhaComTraco());
            Error("NomeFuncao: " + nomeFuncao);
            Error(mensagem);
            Error(LinhaComTraco());
        }

        /// <summary>
        /// Log de erros
        /// </summary>
        /// <param name="nomeFuncao">Nome da funcao/metodo onde foi gerado o evento</param>
        /// <param name="codInterno">Codigo interno unico que identifica o ponto da gravação</param>
        /// <param name="mensagem">Mensagem do erro</param>
        /// <param name="excecao">Exceção</param>
        public static void Erro(string nomeFuncao, string codInterno, string mensagem, Exception excecao)
        {
            Error(LinhaComTraco());
            Error("NomeFuncao: " + nomeFuncao);
            Error(mensagem, excecao);
            Error(LinhaComTraco());
        }

        /// <summary>
        /// Log de Erros
        /// </summary>
        /// <param name="nomeFuncao">Nome da funcao/metodo onde foi gerado o evento</param>
        /// <param name="codInterno">Codigo interno unico que identifica o ponto da gravação</param>
        /// <param name="mensagem">Mensagem de erro</param>
        /// <param name="query">Query executada</param>
        /// <param name="excecao">Exceção</param>
        public static void Erro(string nomeFuncao, string codInterno, string mensagem, string query, Exception excecao)
        {
            Error(LinhaComTraco());
            Error("NomeFuncao: " + nomeFuncao);
            Error(mensagem, excecao);
            Error("Query:\n" + query);
            Error(LinhaComTraco());
        }

        /// <summary>
        /// Log de Erros
        /// </summary>
        /// <param name="nomeFuncao">Nome da funcao/metodo onde foi gerado o evento</param>
        /// <param name="codInterno">Codigo interno unico que identifica o ponto da gravação</param>
        /// <param name="mensagem">Mensagem de erro</param>
        /// <param name="query">Query executada</param>
        public static void Erro(string nomeFuncao, string codInterno, string mensagem, string query)
        {
            Error(LinhaComTraco());
            Error("NomeFuncao: " + nomeFuncao);
            Error(mensagem);
            Error("Query:\n" + query);
            Error(LinhaComTraco());
        }


        /// <summary>
        /// Log de erros
        /// </summary>
        /// <param name="nomeFuncao">Nome da funcao/metodo onde foi gerado o evento</param>
        /// <param name="codInterno">Codigo interno unico que identifica o ponto da gravação</param>
        /// <param name="mensagem">Mensagem de erro</param>
        public static void Debug(string nomeFuncao, string codInterno, string mensagem)
        {
            Debug(LinhaComTraco());
            Debug("NomeFuncao: " + nomeFuncao);
            Debug(mensagem);
            Debug(LinhaComTraco());
        }
        #endregion

        public static void FecharLog()
        {
            //Log.CloseAndFlush();
        }

        private static int GetConsoleWindowHeight()
        {
            if (IsConsoleApplication())
                return Console.WindowWidth - 18;

            return 80;
        }

        public static string LinhaComTraco()
        {
            string result = string.Empty;
            for (int i = 0; i < GetConsoleWindowHeight(); i++)
                result += "-";

            return result;
        }
        public static string LinhaComDoisTracos()
        {
            string result = string.Empty;
            for (int i = 0; i < GetConsoleWindowHeight(); i++)
                result += "=";

            return result;
        }
        public static string LinhaComAsterisco()
        {
            string result = string.Empty;
            for (int i = 0; i < GetConsoleWindowHeight(); i++)
                result += "*";

            return result;
        }

        private static bool IsConsoleApplication()
        {
            var processName = Process.GetCurrentProcess().ProcessName;
            if (processName.ToLower() == "iisexpress")
                return false;
            if (processName.ToLower() == "w3wp")
                return false;
            if (processName.ToLower() == "dotnet")
                return false;

            return true;
        }


        public static string DebugEmArquivoTxt(string Funcao, string CodRetonoInterno, string Texto)
        {
            string Diretorio = "";
            try
            {
                if (_assembly == null)
                    Configurar(Assembly.GetCallingAssembly());

                var logger = LogManager.GetLogger(_assembly, "FileLoggerError");

                Diretorio = Path.GetDirectoryName(((log4net.Appender.FileAppender)((log4net.Appender.IAppender[])((log4net.Repository.Hierarchy.Logger)logger.Logger).Appenders.SyncRoot)[0]).File);

            }
            catch
            {
            }

            if (string.IsNullOrWhiteSpace(Diretorio))
                Diretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            try
            {
                var random = new Random();
                string numRand = random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + random.Next(0, 9).ToString();

                string NomeArquivo = Funcao + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + numRand + ".log";

                var Arquivo = new StreamWriter(Path.Combine(Diretorio, NomeArquivo));
                Arquivo.WriteLine("");
                Arquivo.WriteLine("".PadLeft(80, '*'));
                Arquivo.WriteLine("Funcao: " + Funcao);
                if (!string.IsNullOrEmpty(CodRetonoInterno))
                    Arquivo.WriteLine("CodRetonoInterno: " + CodRetonoInterno);
                if (!string.IsNullOrEmpty(Texto))
                    Arquivo.WriteLine("Texto: " + Texto);
                Arquivo.WriteLine("".PadLeft(80, '*'));
                Arquivo.Close();

                return NomeArquivo;
            }
            catch
            {
                return "Erro gravar DebugEmArquivoTxt";

            }
        }

    }

}