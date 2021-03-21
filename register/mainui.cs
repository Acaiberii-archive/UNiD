using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace register
{
    public partial class mainui : Form
    {
        public mainui()
        {
            InitializeComponent();
        }
        public void BtnReg(object sender, EventArgs e)
        {
            try
            {
                if (!Environment.GetEnvironmentVariable("PATH").Contains(pathh.Text))
                {
                    Environment.SetEnvironmentVariable("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{pathh.Text}", EnvironmentVariableTarget.Machine);
                    if (Environment.GetEnvironmentVariable("PATH").Contains(pathh.Text))
                    {
                        cpath.Text = "Path registered! Starting CMD...";
                        System.Diagnostics.Process.Start("CMD.exe");
                    }
                    else
                    {
                        cpath.Text = "Path couldn't be registered.";
                    }
                }
                else
                {
                    cpath.Text = "Path already registered.";
                }
            }
            catch (Exception er)
            {
                regbtn.Text = er.Message;
            }
        }
    }
}
