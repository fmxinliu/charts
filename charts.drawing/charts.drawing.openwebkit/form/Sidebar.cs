using System;
using System.Windows.Forms;

namespace charts.drawing.openwebkit.form {
    public partial class Sidebar : Form {
        public Sidebar() {
            InitializeComponent();
        }

        public event NavigateEventHandler Navigate;
        public delegate void NavigateEventHandler();

        private void btnNavigate_Click(object sender, EventArgs e) {
            if (this.Navigate != null) {
                this.Navigate();
            }
        }
    }
}
