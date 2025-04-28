using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

public class WindowInfo
{
    public string Title { get; set; }
    public string ClassName { get; set; }
    public string ProcessName { get; set; }
    public string ExecutablePath { get; set; }

    public static WindowInfo[] GetOpenWindows()
    {
        List<WindowInfo> windows = new List<WindowInfo>();

        EnumWindows((hWnd, lParam) =>
        {
            if (IsWindowVisible(hWnd))
            {
                StringBuilder titleBuilder = new StringBuilder(256);
                GetWindowText(hWnd, titleBuilder, titleBuilder.Capacity);
                string title = titleBuilder.ToString();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    StringBuilder classNameBuilder = new StringBuilder(256);
                    GetClassName(hWnd, classNameBuilder, classNameBuilder.Capacity);
                    string className = classNameBuilder.ToString();

                    GetWindowThreadProcessId(hWnd, out uint pid);

                    string processName = "Desconhecido";
                    string executablePath = "";

                    try
                    {
                        using (Process proc = Process.GetProcessById((int)pid))
                        {
                            processName = proc.ProcessName + ".exe";
                            executablePath = proc.MainModule.FileName;
                        }
                    }
                    catch { }

                    windows.Add(new WindowInfo
                    {
                        Title = title,
                        ClassName = className,
                        ProcessName = processName,
                        ExecutablePath = executablePath
                    });
                }
            }

            return true;
        }, IntPtr.Zero);

        return windows.ToArray();
    }

    // Interop
    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
}
