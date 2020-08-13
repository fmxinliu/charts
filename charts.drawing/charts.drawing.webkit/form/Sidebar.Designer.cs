namespace charts.drawing.webkit.form {
    partial class Sidebar {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnNavigate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNavigate
            // 
            this.btnNavigate.Location = new System.Drawing.Point(44, 31);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(75, 25);
            this.btnNavigate.TabIndex = 2;
            this.btnNavigate.Text = "转到";
            this.btnNavigate.UseVisualStyleBackColor = true;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 567);
            this.Controls.Add(this.btnNavigate);
            this.Name = "Sidebar";
            this.Text = "控制栏";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNavigate;
    }
}