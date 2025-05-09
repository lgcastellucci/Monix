﻿using Comunix.Funcoes.Geral;
using Monix.Models;
using System.Data;
using System.Runtime.InteropServices;

namespace Monix.Controllers
{
    public class VerificarAplicativos : IDisposable
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        private Thread threadListener;
        private bool isRunning;

        public VerificarAplicativos()
        {
            isRunning = false;
        }

        public void Start()
        {
            isRunning = true;
            threadListener = new Thread(HandleRequests);
            threadListener.Start();
        }

        public void Stop()
        {
            isRunning = false;

            // Aguarda a thread terminar, se necessário
            if (threadListener != null && threadListener.IsAlive)
            {
                threadListener.Join();
            }
        }

        private void HandleRequests()
        {
            try
            {
                while (isRunning)
                {
                    LoggerService.Information("Inicio VerificarAplicativos");

                    foreach (DataRow item in DataTableAplicativos.dataTable.Rows)
                    {
                        item["DataUltimaChecagem"] = DateTime.Now;
                        LoggerService.Information("Verificando aplicativo: " + item["Nome"].ToString());

                        if (IsWindowVisible(item["Title"].ToString(), item["ClassName"].ToString(), item["ProcessName"].ToString()))
                        {
                            item["QtdErro"] = "0";
                            LoggerService.Information($"O aplicativo '{item["Nome"]}' está aberto.");
                        }
                        else
                        {
                            item["QtdErro"] = (Convert.ToInt32(item["QtdErro"].ToString()) + 1).ToString();
                            LoggerService.Warning($"O aplicativo '{item["Nome"]}' não está aberto.");
                        }

                        if (Convert.ToInt32(item["QtdErro"].ToString()) == 0)
                            item["Status"] = "Ok"; // Aplicativo está aberto
                        else if (Convert.ToInt32(item["QtdErro"].ToString()) < 5)
                            item["Status"] = "Warn"; // Aplicativo não está aberto
                        else
                            item["Status"] = "Erro"; // Aplicativo não está aberto e já foi verificado mais de 2 vezes

                    }

                    LoggerService.Information("Fim VerificarAplicativos");
                    Thread.Sleep(1000); // 1 segundo
                }
            }
            catch (Exception e)
            {
                LoggerService.Error("Exception");
                LoggerService.Debug(e.Message);
            }
        }

        private bool IsWindowVisible(string title, string className, string processName)
        {
            using (var windowLister = new WindowLister())
            {
                var openWindows = windowLister.GetOpenWindows();
                // Filtra as janelas abertas com base nos critérios fornecidos
                // e verifica se alguma delas corresponde aos critérios
                // de título, classe e nome do processo

                foreach (var window in openWindows)
                {
                    if (window.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                        window.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase) &&
                        window.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                ;
            }
            return false;
        }

        public void Dispose()
        {
            Stop(); // Garante que a thread seja parada ao descartar o objeto
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
        }
    }
}


