using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace MoreClothingGUI
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        private static Mutex mutex = null;

        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            int argCount = args == null ? 0 : args.Length;
            Console.WriteLine("You specified {0} arguments:", argCount);
            for (int i = 0; i < argCount; i++)
            {
                Console.WriteLine("  {0}", args[i]);
            }

            const string appName = "MoreClothingGUI";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiFormContext(new MainForm()));
        }
    }
}
public class MultiFormContext : ApplicationContext
{
    private int openForms;
    public MultiFormContext(params Form[] forms)
    {
        openForms = forms.Length;

        foreach (var form in forms)
        {
            form.FormClosed += (s, args) =>
            {
                //When we have closed the last of the "starting" forms, 
                //end the program.
                if (Interlocked.Decrement(ref openForms) == 0)
                    ExitThread();
            };

            form.Show();
        }
    }
}