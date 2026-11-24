using System;
using System.IO;
using System.Windows.Forms;

namespace ViewForms
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\", "Data"));

            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data");
            basePath = Path.GetFullPath(basePath);
            AppDomain.CurrentDomain.SetData("DataDirectory", basePath);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VMenu());
        }
    }
}
