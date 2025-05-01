using Comunix.Funcoes.Configuracoes;
using Comunix.Funcoes.Geral;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Configuration;
using Monix.Controllers;
using Monix.Models;
using System.Data;

namespace Monix
{
    public partial class FPrincipal : Form
    {
        private VerificarAplicativos _verificarAplicativos;
        private IConfiguration _configuration;
        public FPrincipal()
        {
            InitializeComponent();

            ConfiguracoesLog4net.Configurar("C:\\AppLogs\\", "Monix");

            CarregarConfiguracoes();
            PopularGridAplicativos();


            #region Iniciando o timer de checagem de janelas
            _verificarAplicativos = new VerificarAplicativos();
            _verificarAplicativos.Start();

            // Aguarda 1 segundo para iniciar completamente a Thread
            Thread.Sleep(1000);
            #endregion
        }

        private void CarregarConfiguracoes()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        private void PopularGridAplicativos()
        {
            gridAplicativos.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            gridAplicativos.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            gridAplicativos.EnableHeadersVisualStyles = false;
            gridAplicativos.DefaultCellStyle.SelectionBackColor = Color.Empty;
            gridAplicativos.AutoGenerateColumns = true;
            gridAplicativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAplicativos.AllowUserToResizeRows = false;
            gridAplicativos.AllowUserToResizeColumns = true;
            gridAplicativos.MultiSelect = false;
            gridAplicativos.DataSourceChanged += gridAplicativosOnDataSourceChanged;
            gridAplicativos.BackgroundColor = SystemColors.ControlLightLight;

            DataTableAplicativos.dataTable.Columns.Add("Nome", typeof(string));
            DataTableAplicativos.dataTable.Columns.Add("Title", typeof(string));
            DataTableAplicativos.dataTable.Columns.Add("ClassName", typeof(string));
            DataTableAplicativos.dataTable.Columns.Add("ProcessName", typeof(string));
            DataTableAplicativos.dataTable.Columns.Add("ExecutablePath", typeof(string));
            DataTableAplicativos.dataTable.Columns.Add("DataUltimaChecagem", typeof(DateTime));
            DataTableAplicativos.dataTable.Columns.Add("QtdErro", typeof(int));
            DataTableAplicativos.dataTable.Columns.Add("Status", typeof(string));

            gridAplicativos.DataSource = DataTableAplicativos.dataTable;

            // Oculta as colunas
            gridAplicativos.Columns["Title"].Visible = false;
            gridAplicativos.Columns["ClassName"].Visible = false;
            gridAplicativos.Columns["ProcessName"].Visible = false;
            gridAplicativos.Columns["ExecutablePath"].Visible = false;

            gridAplicativos.Columns["Nome"].Width = 150;
            gridAplicativos.Columns["DataUltimaChecagem"].Width = 150;
            gridAplicativos.Columns["QtdErro"].Width = 50;
            gridAplicativos.Columns["Status"].Width = 50;

            // Configura o formato da coluna DataUltimaChecagem para exibir segundos
            gridAplicativos.Columns["DataUltimaChecagem"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";


            var aplicativos = _configuration.GetSection("Aplicativos").Get<List<Aplicativo>>();

            if (aplicativos == null || aplicativos.Count == 0)
            {
                MessageBox.Show("Nenhum aplicativo encontrado na configuração.");
                return;
            }

            // Limpa a lista antes de adicionar novos itens
            DataTableAplicativos.dataTable.Rows.Clear();

            // Adiciona cada aplicativo como uma nova linha na grid
            foreach (var aplicativo in aplicativos)
            {
                DataTableAplicativos.dataTable.Rows.Add(aplicativo.Nome, aplicativo.Title, aplicativo.ClassName, aplicativo.ProcessName, aplicativo.ExecutablePath,
                                                        aplicativo.DataUltimaChecagem, aplicativo.QtdErro, aplicativo.Status);
            }


        }
        private void gridAplicativosOnDataSourceChanged(object sender, EventArgs e)
        {
            gridAplicativos.ClearSelection();
        }

        private void gridAplicativos_Leave(object sender, EventArgs e)
        {
            gridAplicativos.ClearSelection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PopularGridAplicativosAbertos();
        }

        private void PopularGridAplicativosAbertos()
        {
            gridAplicativosAbertos.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            gridAplicativosAbertos.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            gridAplicativosAbertos.EnableHeadersVisualStyles = false;
            gridAplicativosAbertos.DefaultCellStyle.SelectionBackColor = Color.Empty;
            gridAplicativosAbertos.AutoGenerateColumns = true;
            gridAplicativosAbertos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAplicativosAbertos.AllowUserToResizeRows = false;
            gridAplicativosAbertos.AllowUserToResizeColumns = true;
            gridAplicativosAbertos.MultiSelect = false;
            gridAplicativosAbertos.DataSourceChanged += gridAplicativosOnDataSourceChanged;
            gridAplicativosAbertos.BackgroundColor = SystemColors.ControlLightLight;

            var _dataTableAplicativosAbertos = new DataTable();

            _dataTableAplicativosAbertos.Columns.Add("Nome", typeof(string));
            _dataTableAplicativosAbertos.Columns.Add("Title", typeof(string));
            _dataTableAplicativosAbertos.Columns.Add("ClassName", typeof(string));
            _dataTableAplicativosAbertos.Columns.Add("ProcessName", typeof(string));
            _dataTableAplicativosAbertos.Columns.Add("ExecutablePath", typeof(string));

            gridAplicativosAbertos.DataSource = _dataTableAplicativosAbertos;

            // Permitir edição no DataGridView
            gridAplicativosAbertos.ReadOnly = false;

            // Garantir que a coluna "ExecutablePath" seja editável
            gridAplicativosAbertos.Columns["ExecutablePath"].ReadOnly = false;

            // Adicionar coluna de botão
            if (!gridAplicativosAbertos.Columns.Contains("Adicionar"))
            {
                var buttonColumn = new DataGridViewButtonColumn
                {
                    Name = "Adicionar",
                    HeaderText = "Ação",
                    Text = "Adicionar",
                    UseColumnTextForButtonValue = true
                };
                gridAplicativosAbertos.Columns.Add(buttonColumn);
            }
            if (!gridAplicativosAbertos.Columns.Contains("Remover"))
            {
                var buttonColumn = new DataGridViewButtonColumn
                {
                    Name = "Remover",
                    HeaderText = "Ação",
                    Text = "Remover",
                    UseColumnTextForButtonValue = true
                };
                gridAplicativosAbertos.Columns.Add(buttonColumn);
            }

            // Limpa a lista antes de adicionar novos itens
            _dataTableAplicativosAbertos.Rows.Clear();

            /*
            LoggerService.Information(" ");
            var listOpenWindows = new ListOpenWindows();
            var windowsList = listOpenWindows.Search();
            foreach (var window in windowsList)
            {
                LoggerService.Information(window.title + " - " + window.hWnd + " - " + window.executablePath);
                _dataTableAplicativosAbertos.Rows.Add(window.title, window.hWnd, "", window.executablePath);
            }
            */

            /*
            LoggerService.Information(" ");
            var windows = WindowInfo.GetOpenWindows();
            foreach (var window in windows)
            {
                LoggerService.Information(window.Title + " - " + window.ClassName + " - " + window.ProcessName + " - " + window.ExecutablePath);
                _dataTableAplicativosAbertos.Rows.Add(window.Title, window.ClassName, window.ProcessName, window.ExecutablePath);
            }
            */

            LoggerService.Information(" ");
            // Listar todas as janelas abertas no Windows
            var windowList = new WindowLister();
            var openWindows = windowList.GetOpenWindows();
            foreach (var window in openWindows)
            {
                LoggerService.Information(window.Title + " - " + window.ClassName + " - " + window.ProcessName + " - " + window.ExecutablePath);
                if (chkAplicacoesPadraoComunix.Checked)
                {
                    if (window.ClassName == "TApplication") //Aplicações feitas em Delphi7
                        _dataTableAplicativosAbertos.Rows.Add("", window.Title, window.ClassName, window.ProcessName, window.ExecutablePath);
                    else if (window.ClassName == "CASCADIA_HOSTING_WINDOW_CLASS") //Aplicações console usando windows terminal mais novo
                        _dataTableAplicativosAbertos.Rows.Add("", window.Title, window.ClassName, window.ProcessName, window.ExecutablePath);
                    else if (window.ClassName == "ConsoleWindowClass") //Aplicações console usando terminal "antigo" do windows
                        _dataTableAplicativosAbertos.Rows.Add("", window.Title, window.ClassName, window.ProcessName, window.ExecutablePath);
                }
                else
                {
                    _dataTableAplicativosAbertos.Rows.Add("", window.Title, window.ClassName, window.ProcessName, window.ExecutablePath);
                }
            }
            windowList.Dispose();

            // Adicionar evento de clique no botão
            gridAplicativosAbertos.CellClick += GridAplicativosAbertos_CellClick;
        }
        private void GridAplicativosAbertos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada é da coluna de botão "Adicionar"
            if (e.RowIndex >= 0 && gridAplicativosAbertos.Columns[e.ColumnIndex].Name == "Adicionar")
            {
                var row = gridAplicativosAbertos.Rows[e.RowIndex];
                var title = row.Cells["Title"].Value?.ToString();
                var className = row.Cells["ClassName"].Value?.ToString();
                var processName = row.Cells["ProcessName"].Value?.ToString();
                var executablePath = row.Cells["ExecutablePath"].Value?.ToString();

                // Verificar se já existe na gridAplicativos
                var exists = DataTableAplicativos.dataTable.AsEnumerable().Any(r =>
                    r.Field<string>("Title") == title &&
                    r.Field<string>("ClassName") == className &&
                    r.Field<string>("ProcessName") == processName &&
                    r.Field<string>("ExecutablePath") == executablePath);

                if (!exists)
                {
                    // Adicionar à gridAplicativos
                    DataTableAplicativos.dataTable.Rows.Add(title, title, className, processName, executablePath, DateTime.Now, 0, "Novo");
                    MessageBox.Show("Aplicativo adicionado com sucesso!");
                }
                else
                {
                    MessageBox.Show("O aplicativo já existe na lista.");
                }
            }
            // Verifica se a célula clicada é da coluna de botão "Remover"
            else if (e.RowIndex >= 0 && gridAplicativosAbertos.Columns[e.ColumnIndex].Name == "Remover")
            {
                var row = gridAplicativosAbertos.Rows[e.RowIndex];
                var title = row.Cells["Title"].Value?.ToString();
                var className = row.Cells["ClassName"].Value?.ToString();
                var processName = row.Cells["ProcessName"].Value?.ToString();
                var executablePath = row.Cells["ExecutablePath"].Value?.ToString();

                // Localizar a linha correspondente no DataTableAplicativos.dataTable
                var rowToRemove = DataTableAplicativos.dataTable.AsEnumerable().FirstOrDefault(r =>
                    r.Field<string>("Title") == title &&
                    r.Field<string>("ClassName") == className &&
                    r.Field<string>("ProcessName") == processName &&
                    r.Field<string>("ExecutablePath") == executablePath);

                if (rowToRemove != null)
                {
                    // Remover a linha do DataTable
                    DataTableAplicativos.dataTable.Rows.Remove(rowToRemove);
                    MessageBox.Show("Aplicativo removido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o aplicativo para remover.");
                }
            }
        }

        private void FPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Parar o timer VerificarAplicativos, se necessário
            if (_verificarAplicativos != null)
            {
                _verificarAplicativos.Stop();
                _verificarAplicativos.Dispose();
            }

            // Certifique-se de liberar outros recursos, se necessário
            // Exemplo: Fechar conexões, liberar objetos, etc.

            // Forçar o encerramento da aplicação
            //Application.Exit();
        }

        private void FPrincipal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide(); // Esconde o formulário quando é minimizado
        }

        private void notifyIconMonix_DoubleClick(object sender, EventArgs e)
        {
            // Restaura o formulário
            if (WindowState == FormWindowState.Minimized)
            {
                // Restaura o formulário se estiver minimizado
                Show();
                WindowState = FormWindowState.Normal;
            }

            // Traz o formulário para frente
            Activate();
        }
    }
}
