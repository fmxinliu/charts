using System;
using System.Windows.Forms;
using WebKit;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace charts.drawing.openwebkit.form {
    [ComVisible(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class Bodyer : Form {
        public Bodyer() {
            InitializeComponent();
        }

        private void Bodyer_Load(object sender, EventArgs e) {
            this.InitBrowser();
        }

        private WebKitBrowser browser;
        public void InitBrowser() {
            this.browser = new WebKitBrowser();
            this.browser.Dock = DockStyle.Fill;
            //this.browser.Url = new Uri(@"http://www.baidu.com");
            this.browser.Navigate(@"http://www.baidu.com");
            this.Controls.Add(this.browser);
            this.browser.DocumentCompleted += this.browser_DocumentCompleted;
        }

        public void exit() {
            this.browser.Dispose();
        }

        public void browser_Navigate(String url) {
            this.browser.Navigate(url);
            if (this.browser.Url != null) {
                this.browser.Reload(); // 重新加载，刷新dom
            }
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            this.browser.GetScriptManager.ScriptObject = this;
            charts.drawing.webkit.memory.Utils.FlushMemory();
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
            if (this.ProgressChanged != null) {
                this.ProgressChanged(e.CurrentProgress, e.MaximumProgress);
            }
        }

        public event ProgressChangedEventHandler ProgressChanged;
        public delegate void ProgressChangedEventHandler(long CurrentProgress, long MaximumProgress);
    }
}
