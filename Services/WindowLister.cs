using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

public class WindowLister : IDisposable
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    public class ApplicationDetails
    {
        public string Title { get; set; }
        public string ClassName { get; set; }
        public string ProcessName { get; set; }
        public uint ProcessId { get; set; }
        public string ExecutablePath { get; set; }

        public ApplicationDetails(string title, string className, string processName, uint processId, string executablePath)
        {
            Title = title;
            ClassName = className;
            ProcessName = processName;
            ProcessId = processId;
            ExecutablePath = executablePath;
        }
    }

    public List<ApplicationDetails> GetOpenWindows()
    {
        var windowList = new List<ApplicationDetails>();

        // Certifique-se de que não há loops infinitos ou threads bloqueadas
        EnumWindows((hWnd, lParam) =>
        {
            if (IsWindowVisible(hWnd))
            {
                var sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, sb.Capacity);
                var windowTitle = sb.ToString();

                if (!string.IsNullOrWhiteSpace(windowTitle))
                {
                    var classNameBuilder = new StringBuilder(256);
                    GetClassName(hWnd, classNameBuilder, classNameBuilder.Capacity);
                    var className = classNameBuilder.ToString();

                    GetWindowThreadProcessId(hWnd, out uint processId);
                    var processName = Process.GetProcessById((int)processId).ProcessName;

                    var executablePath = GetExecutablePath(hWnd, processId);

                    if (className == "CASCADIA_HOSTING_WINDOW_CLASS")
                    {
                        // Se o nome da classe for "CASCADIA_HOSTING_WINDOW_CLASS", a janela esta rodando em um Console no Windows Terminal.
                        // Com isso o caminho do executável encontrado acima éo executavel do temrinal e não dentro dele 
                        executablePath = "";
                    }


                    windowList.Add(new ApplicationDetails(windowTitle, className, processName, processId, executablePath));
                }
            }
            return true; // Continue enumerando
        }, IntPtr.Zero);

        return windowList;
    }

    private static string GetExecutablePath(IntPtr hWnd, uint pid)
    {
        try
        {
            using (var process = Process.GetProcessById((int)pid))
            {
                return process.MainModule?.FileName ?? string.Empty;
            }
        }
        catch (Win32Exception ex)
        {
            // Isso pode ocorrer se o processo não permitir acesso ao MainModule
            Console.WriteLine($"Erro ao obter o caminho do executável: {ex.Message}");
            return string.Empty;
        }
        catch (Exception ex)
        {
            // Captura outras exceções inesperadas
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            return string.Empty;
        }
    }


    public void Dispose()
    {
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
