using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Rouigram
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            Point p = new Point(this.ParentForm.Width / 2 - this.Width / 2, this.ParentForm.Height / 2 - this.Height / 2);
            this.Location = p;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                if (materialSingleLineTextField1.Text == "")
                {
                    animator1.ShowSync(panel2);
                }
                else
                {
                    //Send Feedback Here At Version 1.1.0
                }
            }
            else
            {
                animator1.ShowSync(panel1);
            }                     
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            animator1.HideSync(panel2);
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            animator1.HideSync(panel1);
        }
    }
}
