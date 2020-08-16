using System;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using charts.drawing.openwebkit.form;

namespace charts.drawing.openwebkit {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f = new Form1();
            try {
                Application.Run(f);
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString(), "crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f.Exit();
            }
        }
    }
}
