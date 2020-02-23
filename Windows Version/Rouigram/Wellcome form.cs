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
    public partial class Wellcome_form : Form
    {
        public Wellcome_form()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 100;
        }
        int value = 0;
        private void Wellcome_form_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            value += 1;
            if (value >= 96)
            {
                timer.Enabled = false;
                timer.Stop();
                this.Hide();
                Form1 mainmenu = new Form1();
                mainmenu.Show();
            }
        }
    }
}
