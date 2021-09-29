using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace NCRAutomation
{
    public class BasePage
    {
        public static Process process;
        public AutomationElement mainWindow;
        public BasePage()
        {
            process = Process.Start("C:\\Users\\User\\source\\repos\\NCRApplication\\NCRApplication\\bin\\Debug\\netcoreapp3.1\\NCRApplication");
            /*if(process.MainWindowHandle == null)
            {
                mainWindow = AutomationElement.FromHandle(process.MainWindowHandle);
            } */
            Thread.Sleep(2000);
            mainWindow = AutomationElement.FromHandle(process.MainWindowHandle);
        }
        public void closeMainWindow()
        {
            process.Kill();        
        }
    }
}
