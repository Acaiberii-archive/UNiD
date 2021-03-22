
namespace register
{
    partial class mainui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.regbtn = new System.Windows.Forms.Button();
            this.pathh = new System.Windows.Forms.TextBox();
            this.cpath = new System.Windows.Forms.RichTextBox();
            this.clearpathbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regbtn
            // 
            this.regbtn.Location = new System.Drawing.Point(12, 38);
            this.regbtn.Name = "regbtn";
            this.regbtn.Size = new System.Drawing.Size(553, 36);
            this.regbtn.TabIndex = 0;
            this.regbtn.Text = "Register with PATH";
            this.regbtn.UseVisualStyleBackColor = true;
            this.regbtn.Click += new System.EventHandler(this.BtnReg);
            // 
            // pathh
            // 
            this.pathh.Location = new System.Drawing.Point(12, 12);
            this.pathh.Name = "pathh";
            this.pathh.Size = new System.Drawing.Size(553, 20);
            this.pathh.TabIndex = 1;
            this.pathh.Text = "Path";
            // 
            // cpath
            // 
            this.cpath.Location = new System.Drawing.Point(12, 134);
            this.cpath.Name = "cpath";
            this.cpath.ReadOnly = true;
            this.cpath.Size = new System.Drawing.Size(553, 62);
            this.cpath.TabIndex = 2;
            this.cpath.Text = "";
            // 
            // clearpathbtn
            // 
            this.clearpathbtn.Location = new System.Drawing.Point(12, 86);
            this.clearpathbtn.Name = "clearpathbtn";
            this.clearpathbtn.Size = new System.Drawing.Size(553, 36);
            this.clearpathbtn.TabIndex = 3;
            this.clearpathbtn.Text = "Clear PATH";
            this.clearpathbtn.UseVisualStyleBackColor = true;
            this.clearpathbtn.Click += new System.EventHandler(this.BtnClear);
            // 
            // mainui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 208);
            this.Controls.Add(this.clearpathbtn);
            this.Controls.Add(this.cpath);
            this.Controls.Add(this.pathh);
            this.Controls.Add(this.regbtn);
            this.Name = "mainui";
            this.Text = "UNiD - Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regbtn;
        private System.Windows.Forms.TextBox pathh;
        private System.Windows.Forms.RichTextBox cpath;
        private System.Windows.Forms.Button clearpathbtn;
    }
}

