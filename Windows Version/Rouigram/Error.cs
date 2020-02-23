using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rouigram
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            animator1.ShowSync(webBrowser1);
            webBrowser1.Url = new Uri("http://http://pythony.ir");
            bunifuImageButton1.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            animator1.HideSync(webBrowser1);
            bunifuImageButton1.Visible = false;
        }

        private void Error_Load(object sender, EventArgs e)
        {
            bunifuImageButton1.Visible = false;
            Point p = new Point(this.ParentForm.Width / 2 - this.Width / 2, this.ParentForm.Height / 2 - this.Height / 2);
            this.Location = p;
        }
    }
}
