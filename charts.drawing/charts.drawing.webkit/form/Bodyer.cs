using System;
using System.Windows.Forms;
using WebKit;

namespace charts.drawing.webkit.form {
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
            this.browser.Url = new Uri(@"http://www.baidu.com");
            this.browser.IsScriptingEnabled = true;
            this.Controls.Add(this.browser);
        }

        public event ProgressChangedEventHandler ProgressChanged;
        public delegate void ProgressChangedEventHandler(long CurrentProgress, long MaximumProgress);

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
            if (this.ProgressChanged != null) {
                this.ProgressChanged(e.CurrentProgress, e.MaximumProgress);
            }
        }

        public void browser_Navigate(String url) {
            this.browser.Navigate(url);
        }
    }
}
