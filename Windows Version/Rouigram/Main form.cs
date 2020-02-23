using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing.Imaging;

namespace Rouigram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer.Enabled = false;
            timer.Interval = 1;
        }
        int value = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Set Header Color
            header_panel.BackColor = ColorTranslator.FromHtml("#fc9144");
            Close_button.color = ColorTranslator.FromHtml("#fc9144");
            Minimize.color = ColorTranslator.FromHtml("#fc9144");
            feedback.color = ColorTranslator.FromHtml("#fc9144");
            //Set Timer
            timer.Enabled = false;
            //Set tooltips
            toolTip.SetToolTip(linkLabel1, "https://www.mirhamedrooy.ir");
            toolTip.SetToolTip(Telegram, "مارا در فیس بوک دنبال کنید");
            toolTip.SetToolTip(Instagram, "مارا دراینستاگرام دنبال کنید");
            toolTip.SetToolTip(Twitter, "مارا در توییتر دنبال کنید");
            toolTip.SetToolTip(Get, "دریافت اطلاعات نام کاربری");
            toolTip.SetToolTip(Rouigram, "https://www.mirhamedrooy.ir/rouigram/");
            toolTip.SetToolTip(feedback, "ارسال بازخورد");
            toolTip.SetToolTip(Minimize, "کوچک کردن");
            toolTip.SetToolTip(Close_button, "بستن");
            panel2.BackColor = ColorTranslator.FromHtml("#57a2d0");
            linkLabel1.Text="Alirzea Araby";
        }
        //Set Get Button
        private void Get_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                if (Textbox.Text == "نام کاربری/Username")
                {
                    Close_Error.Visible = true;
                    if (Textbox.Text == "نام کاربری/Username")
                    {
                        Close_Error.Visible = true;
                        bool isrun = false;
                        foreach (Form f in Application.OpenForms)
                        {
                            if (f.Text == "Error")
                            {
                                f.BringToFront();
                            }
                        }
                        if (isrun == false)
                        {
                            Error f = new Error();
                            f.TopLevel = false;
                            f.Parent = this;
                            f.Show();
                            f.BringToFront();
                            pictureBox2.Visible = true;
                            Close_Error.BringToFront();
                        }
                    }
                }
                else
                {
                    int jj = Textbox.Text.Length;
                    if (jj <= 30)
                    {
                        bunifuCircleProgressbar1.Visible = true;
                        bunifuCircleProgressbar1.animated = true;
                        label2.Visible = true;
                        pictureBox2.Visible = true;
                        timer.Enabled = true;
                        /////##############################///
                        string link = Textbox.Text;
                        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create
                                (string.Format("https://mirhamedrooy.ir/api/v1/?username=" + link));

                        WebReq.Method = "GET";

                        HttpWebResponse WebResp_1 = (HttpWebResponse)WebReq.GetResponse();

                        Stream Answer = WebResp_1.GetResponseStream();
                        StreamReader _Answer = new StreamReader(Answer);
                        string Json_String = _Answer.ReadToEnd();
                        Console.WriteLine(_Answer.ReadToEnd());
                        dynamic stuff = JObject.Parse(Json_String);

                        string user_id_Json = stuff.rouigram.user_id;
                        string username_Json = stuff.rouigram.username;
                        string fullname_Json = stuff.rouigram.fullname;
                        string profile_hd_photo_Json = stuff.rouigram.profile_hd_photo;
                        string follower_count_Json = stuff.rouigram.follower_count;
                        string following_count_Json = stuff.rouigram.following_count;
                        string biography_Json = stuff.rouigram.biography;
                        string external_url_Json = stuff.rouigram.external_url;
                        string is_private_Json = stuff.rouigram.is_private;
                        string media_count_Json = stuff.rouigram.media_count;

                        user_id_Main.Text = user_id_Json;
                        usename_Main.Text = username_Json;
                        fullname_Main.Text = fullname_Json;
                        profile_hd_photo_Main.Text = profile_hd_photo_Json;
                        flower_count_Main.Text = follower_count_Json;
                        folowing_count_Main.Text = following_count_Json;
                        biography_Main.Text = biography_Json;
                        external_url_Main.Text = external_url_Json;
                        is_pravate_Main.Text = is_private_Json;
                        media_Count_Main.Text = media_count_Json;
                        Temp.Text = profile_hd_photo_Json;

                        Textbox.Text ="username/نام کاربری";
                    }
                    else
                    {
                        animator1.ShowSync(panel2);
                    }
                }
            }
            else
            {
                bool isrun = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Error")
                    {
                        f.BringToFront();                        
                    }
                }
                if (isrun == false)
                {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();
                }
            }            
        }
        //TexBox
        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (Textbox.Text == "نام کاربری/Username")
            {
                Textbox.Text = "";
                Textbox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (Textbox.Text == "")
            {
                Textbox.Text = "نام کاربری/Username";
                Textbox.ForeColor = System.Drawing.Color.Gray;
            }
        }
        //click
        private void Telegram_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                webBrowser1.Url = new Uri("https://www.facebook.com/mohammadali.mirhamed");                
                feedback.Visible = false;
                Home.Visible = true;
                webBrowser1.Visible = true;
                animator1.ShowSync(panel1);
                panel1.BringToFront();
            }
            else
            {
                bool isrun = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Error")
                    {
                        isrun = true;
                        f.BringToFront();
                        break;
                    }
                }
                if (isrun == false)
                {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();                   
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                System.Diagnostics.Process.Start("https://www.mirhamedrooy.ir/rouigram/");                                                
            }
            else
            {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();                
            }
        }

        private void Twitter_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                webBrowser1.Url = new Uri("https://twitter.com/mohammadali_mir");            
                feedback.Visible = false;
                Home.Visible = true;
                webBrowser1.Visible = true;
                animator1.ShowSync(panel1);
                panel1.BringToFront();
            }
            else
            {
                bool isrun = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Error")
                    {
                        f.BringToFront();
                    }
                }
                if (isrun == false)
                {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();
                }
            }
        }

        private void Instagram_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                webBrowser1.Url = new Uri("https://www.instagram.com/mohammadali_mirhamed/"); 
                feedback.Visible = false;
                Home.Visible = true;
                webBrowser1.Visible = true;
            }
            else
            {
                bool isrun = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Error")
                    {
                        f.BringToFront();
                    }
                }
                if (isrun == false)
                {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();
                }
            }
        }
        private void Linkdin_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                webBrowser1.Url = new Uri("https://www.linkedin.com/in/mohammadali-mirhamed-rooy-480b9ab6?trk=nav_responsive_tab_profile_pic");
                feedback.Visible = false;
                Home.Visible = true;
                webBrowser1.Visible = true;
            }
            else
            {
                bool isrun = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Error")
                    {
                        isrun = true;
                        f.BringToFront();
                        break;
                    }
                }
                if (isrun == false)
                {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con)
            {
                System.Diagnostics.Process.Start("https://www.mirhamedrooy.ir");
            }
            else
            {
                    InternetError f = new InternetError();
                    f.TopLevel = false;
                    f.Parent = this;
                    f.Show();
                    f.BringToFront();
                    feedback.Visible = false;
                    pictureBox2.Visible = true;
                    Close_Child.Visible = true;
                    Close_Child.BringToFront();                
            }
        }
        private void Rouigram_MouseEnter(object sender, EventArgs e)
        {
            Line.Visible = true;
        }

        private void Rouigram_MouseLeave(object sender, EventArgs e)
        {
            Line.Visible = false;
        }         
        //Close Button
        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Set Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            value += 1;
            if (value >= 100)
            {
                timer.Enabled = false;
                timer.Stop();                
                bunifuCircleProgressbar1.animated = false;
                bunifuCircleProgressbar1.Visible = false;
                label2.Visible = false;
                Textbox.Visible = false;
                Telegram.Visible = false;
                Instagram.Visible = false;
                Linkdin.Visible = false;
                Twitter.Visible = false;
                linkLabel1.Visible = false;
                Get.Visible = false;
                pictureBox2.Visible = false;
                ///##########################///
                panel3.Visible = true;
                profile_hd_photo_Main.Visible = true;
                Seeon_Mirhamedrouiy_ir.Visible = true;
                menuStrip1.Visible = true;
                
            }
        }
        //FeedBack
        private void feedback_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            feedback.Enabled = false;
            feedback.Cursor = Cursors.No;
            Close_Feedback.Visible = true;
            bool isrun = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Feedback")
                {                    
                    f.BringToFront();                    
                }
            }
            if (isrun == false)
            {
                Feedback f = new Feedback();
                f.TopLevel = false;
                f.Parent = this;
                f.Show();
                f.BringToFront();
                Close_Feedback.BringToFront();
            }
        }
        private void Home_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            Home.Visible = false;
            feedback.Visible = true;
        }        
        private void Close_Child_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            Close_Child.Visible = false;
            bool isrun = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "InternetError")
                {
                    f.Hide();
                }
            }
        }

        private void Close_Feedback_Click(object sender, EventArgs e)
        {
            Close_Feedback.Visible = false;
            pictureBox2.Visible = false;
            feedback.Enabled = true;
            feedback.Cursor = Cursors.Default;
            bool isrun = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Feedback")
                {
                    f.Hide();
                }
            }
        }

        private void close_panel_Click(object sender, EventArgs e)
        {
            animator1.HideSync(panel1);
        }

        private void Close_Error_Click(object sender, EventArgs e)
        {
            Close_Error.Visible = false;
            pictureBox2.Visible = false;
            feedback.Visible = true;
            bool isrun = false;
            foreach (Form f in Application.OpenForms)
            {
                feedback.Visible = true;
                if (f.Text == "Error")
                {
                    f.Hide();
                    feedback.Visible = true;
                }
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            animator1.HideSync(panel2);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Seeon_Mirhamedrouiy_ir_Click(object sender, EventArgs e)
        {
            string link = usename_Main.Text;
            System.Diagnostics.Process.Start("https://www.mirhamedrooy.ir/rouigram/get.php?username="+link+"&send=get+%2F+دریافت");            
        }

        private void profile_hd_photo_Main_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Temp.Text);
        }

        private void ذخیرهبعنوانفایلمتنیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result;
            string text = user_id.Text + "=" + user_id_Main.Text + "\n" + username.Text + "=" + usename_Main.Text + "\n" + fullname.Text + "=" + fullname_Main.Text + "\n" + profile_hd_photo.Text + "=" + Temp.Text + "\n" + follower_count.Text + "=" + flower_count_Main.Text + "\n" + following_count.Text + "=" + folowing_count_Main.Text + "\n" + biography.Text + "=" + biography_Main.Text + "\n" + external_url.Text + "=" + external_url_Main.Text + "\n" + is_private.Text + "=" + is_pravate_Main.Text + "\n" + media_count.Text + "=" + media_Count_Main.Text;
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine(text);
                writer.Dispose();
                writer.Close();
                result = save.ToString();
                label21.Text = "ذخیره شد(" + result + ")فایل مورد نظر شما در آدرس";
                label21.Location = new Point(0, 3);
                bunifuTileButton2.BringToFront();
                animator3.ShowSync(panel4);
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            animator3.HideSync(panel4);
        }

        private void ذخیرهبعنوانعکسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = value + 1;
            WindowScreenshot(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Rouygram(" + value + ").jpg", ImageFormat.Jpeg);
            label21.Text = "ذخیره شد(" + "Picturs" + ")فایل مورد نظر شما در آدرس";
            label21.Location = new Point(257, 3);
            animator3.ShowSync(panel4);
        }
        private void WindowScreenshot(String filepath, String filename, ImageFormat format)
        {
            Rectangle bounds = this.Bounds;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                string fullpath = filepath + "\\" + filename;

                bitmap.Save(fullpath, format);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            animator1.HideSync(panel3);
        }

        private void دربارهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f = new About();
            bunifuTileButton3.Visible = true;
            f.TopLevel = false;
            f.Parent = this;
            f.Show();
            pictureBox2.Visible = true;
            f.BringToFront();
            bunifuTileButton3.BringToFront();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            bool is_run = false;
            foreach (Form f in Application.OpenForms)
            {
                feedback.Visible = true;
                if (f.Text == "About")
                {
                    f.Hide();
                    pictureBox2.Visible = false;
                    bunifuTileButton3.Visible = false;
                }
            }
        }

    }
}

