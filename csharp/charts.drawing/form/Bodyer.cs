using System;
using System.Windows.Forms;

namespace charts.drawing.form {
    public partial class Bodyer : Form {
        public Bodyer() {
            InitializeComponent();
        }

        private void Bodyer_Load(object sender, EventArgs e) {
            this.InitBrowser();
        }

        private WebBrowser browser;
        public void InitBrowser() {
            IE.SetVersion(IE.Version.IE9);
            this.browser = new WebBrowser();
            this.browser.Dock = DockStyle.Fill;
            this.browser.Url = new Uri(@"http://www.baidu.com");
            this.browser.ScrollBarsEnabled = true;
            this.browser.ScriptErrorsSuppressed = false;
            this.Controls.Add(this.browser);
            this.browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(browser_ProgressChanged);
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
        }
    }
}
