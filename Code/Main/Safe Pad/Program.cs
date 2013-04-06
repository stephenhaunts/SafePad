using System;
using System.Windows.Forms;
using HauntedHouseSoftware.SecureNotePad.Forms;
using System.IO;

namespace HauntedHouseSoftware.SecureNotePad
{
    [CLSCompliant(true)]
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            MainForm form;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (args.Length >= 1)
            {
                form = IsValidFile(args[0]) ? new MainForm(args[0]) : new MainForm();
            }
            else
            {
                form = new MainForm();
            }

            Application.Run(form);
        }

        private static bool IsValidFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                if (fileName.ToLower().Contains(".scp"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}