using System;
using System.Windows.Forms;

namespace charts.drawing {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.InitBrowser();
            this.InitStatusBar();
        }

        private WebBrowser browser;
        public void InitBrowser() {
            IE.SetVersion(IE.Version.IE9);
            this.browser = new WebBrowser();
            this.browser.Dock = DockStyle.Fill;
            this.browser.Url = new Uri(@"http://www.baidu.com");
            this.browser.ScrollBarsEnabled = true;
            this.browser.ScriptErrorsSuppressed = false;
            this.pnlLeft.Controls.Add(this.browser);
            this.browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(browser_ProgressChanged);
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
            throw new NotImplementedException();
        }

        private void btnLoad_Click(object sender, EventArgs e) {

        }

        private void InitStatusBar() {
            this.statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.SelectedPath = @"D:\";
            //if (DialogResult.OK == fbd.ShowDialog()) {
            //    this.toolStripStatusLabel2.Text = "根目录：" + fbd.SelectedPath;
            //}

            FolderBrowserDialogEx fbdEx = new FolderBrowserDialogEx();
            fbdEx.SelectedPath = @"D:\";
            if (DialogResult.OK == fbdEx.ShowDialog()) {
                this.toolStripStatusLabel2.Text = "根目录：" + fbdEx.SelectedPath;
            }
        }
    }
}
