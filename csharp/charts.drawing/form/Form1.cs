using System;
using System.Windows.Forms;

namespace charts.drawing.form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.InitSize();
        }

        /// 请在窗体显示前设置
        private void InitSize() {
            // 取得当前的屏幕除任务栏外的工作域大小
            this.Width = SystemInformation.WorkingArea.Width;
            this.Height = SystemInformation.WorkingArea.Height;

            // 取得当前的屏幕包括任务栏的工作域大小
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            // 窗体最小尺寸和起始位置
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.InitUi();
            this.InitStatusBar();
        }

        private Header header;
        private Bodyer bodyer;
        private Sidebar sidebar;
        private void InitUi() {
            this.header = new Header();
            this.bodyer = new Bodyer();
            this.sidebar = new Sidebar();

            this.AddSubForm(header, pnlHeader);
            this.AddSubForm(bodyer, pnlBodyer);
            this.AddSubForm(sidebar, pnlSidebar);

            this.sidebar.Navigate += new Sidebar.NavigateEventHandler(this.Website_Navigate);
            this.bodyer.ProgressChanged += new Bodyer.ProgressChangedEventHandler(this.bodyer_ProgressChanged);

            this.toolStripProgressBar1.Visible = false;
            this.toolStripStatusLabel1.Visible = false;
            this.toolStripStatusLabel2.Text = "根目录：" + Application.StartupPath;
        }

        private void AddSubForm(Form form, Panel panel) {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();
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

        private void bodyer_ProgressChanged(long CurrentProgress, long MaximumProgress) {
            if (CurrentProgress < 0 || MaximumProgress <= 0) {
                return;
            }

            this.toolStripProgressBar1.Visible = true;
            this.toolStripStatusLabel1.Visible = true;

            this.toolStripProgressBar1.Value = (int)CurrentProgress;
            this.toolStripProgressBar1.Maximum = (int)MaximumProgress;
            this.toolStripStatusLabel1.Text = CurrentProgress * 100.0f / MaximumProgress + "%";

            if (CurrentProgress >= MaximumProgress) {
                new System.Threading.Thread(delegate() {
                    System.Threading.Thread.Sleep(1000);
                    this.Invoke(new MethodInvoker(delegate {
                        this.toolStripProgressBar1.Visible = false;
                        this.toolStripStatusLabel1.Visible = false;
                    }));
                }).Start();
            }
        }

        private void Website_Navigate() {
            this.bodyer.browser_Navigate(this.header.WebSiteUrl());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(0); // 直接终止进程
        }
    }
}
