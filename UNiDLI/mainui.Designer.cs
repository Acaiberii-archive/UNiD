
namespace UNiDLI
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
            this.inputcmd = new System.Windows.Forms.TextBox();
            this.sendcmd = new System.Windows.Forms.Label();
            this.readcmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputcmd
            // 
            this.inputcmd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputcmd.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.inputcmd.Location = new System.Drawing.Point(12, 418);
            this.inputcmd.Multiline = true;
            this.inputcmd.Name = "inputcmd";
            this.inputcmd.Size = new System.Drawing.Size(733, 36);
            this.inputcmd.TabIndex = 1;
            // 
            // sendcmd
            // 
            this.sendcmd.AutoSize = true;
            this.sendcmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendcmd.Location = new System.Drawing.Point(751, 415);
            this.sendcmd.Name = "sendcmd";
            this.sendcmd.Size = new System.Drawing.Size(37, 39);
            this.sendcmd.TabIndex = 2;
            this.sendcmd.Text = ">";
            this.sendcmd.Click += new System.EventHandler(this.SendCMD_Click);
            // 
            // readcmd
            // 
            this.readcmd.BackColor = System.Drawing.Color.Black;
            this.readcmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readcmd.ForeColor = System.Drawing.Color.White;
            this.readcmd.Location = new System.Drawing.Point(12, 12);
            this.readcmd.MaxLength = 100000;
            this.readcmd.Multiline = true;
            this.readcmd.Name = "readcmd";
            this.readcmd.Size = new System.Drawing.Size(776, 400);
            this.readcmd.TabIndex = 3;
            // 
            // mainui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.readcmd);
            this.Controls.Add(this.sendcmd);
            this.Controls.Add(this.inputcmd);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "mainui";
            this.Text = "UNiDLI";
            this.Load += new System.EventHandler(this.Redir);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputcmd;
        private System.Windows.Forms.Label sendcmd;
        private System.Windows.Forms.TextBox readcmd;
    }
}

