using System;
using System.Windows.Forms;
using Modeling.UI.Forms;

namespace Modeling
{
    static class EntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // Comment from SVN
        // Comment from Visual SVN
    }
}