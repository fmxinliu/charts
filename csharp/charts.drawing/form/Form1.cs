using System;
using System.Windows.Forms;

namespace charts.drawing.form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.InitSize();
        }

        // 在窗体显示前，设置位置
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
            header = new Header();
            bodyer = new Bodyer();
            sidebar = new Sidebar();
            this.AddSubForm(header, pnlHeader);
            this.AddSubForm(bodyer, pnlBodyer);
            this.AddSubForm(sidebar, pnlSidebar);
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
    }
}
