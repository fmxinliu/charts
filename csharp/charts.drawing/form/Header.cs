using System;
using System.Windows.Forms;

namespace charts.drawing.form {
    public partial class Header : Form {
        public Header() {
            InitializeComponent();
        }

        public String WebSiteUrl() {
            return this.tbxWebSiteUrl.Text;
        }
    }
}
