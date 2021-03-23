using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNiDLI
{
    public partial class mainui : Form
    {
        public mainui()
        {
            InitializeComponent();
        }
        public void Redir(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxStreamWriter(readcmd));
            Console.WriteLine("> UNiDCLI redirecting output. OK.");
        }
        public void SendCMD_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo pr = new System.Diagnostics.ProcessStartInfo();
            pr.UseShellExecute = false;
            pr.RedirectStandardOutput = true;
            pr.FileName = "cmd.exe";
            pr.Arguments = $"/C {inputcmd.Text}";
            pr.StandardOutputEncoding = Encoding.Unicode;
            pr.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            var proc = System.Diagnostics.Process.Start(pr);
            proc.BeginOutputReadLine();
            Application.DoEvents();
            proc.WaitForExit();
        }
    }
    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
