using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quiz_application
{
    public partial class milyaner : Form
    {
        public milyaner()
        {
            InitializeComponent();
        }
        int suals = 0, duz = 0, serf = 0, xal = 0, san = 0;
        string duzgun_cvb;
        Random sual = new Random();
     //   double
        private void milyaner_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\mil.mp3";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 50;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            button1.BackColor = Color.Cyan;
            button2.BackColor = Color.Cyan; 
            button3.BackColor = Color.Cyan;
            button4.BackColor = Color.Cyan;
            button5.Text = "NOBETI >>>";
            axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\mil.mp3";
            suals++;
            label8.Text = suals.ToString();
            if (suals == 1)
            {
                richTextBox1.Text = "Həkim Babanin sirrini öyrənmək istəyən xanın adı nə idi?";
                button1.Text = "A) Nəzərəli Xan";
                button2.Text = "B) Məhəmməd Xan";
                button3.Text = "C) Simnar Xan";
                button4.Text = "D) Fətəli Xan";
                duzgun_cvb = "C) Simnar Xan";
            }
            else if (suals == 2)
            {
                richTextBox1.Text = "Özbəkistanin əhalisinin sayi nə qədərdir ?";
                button1.Text = "A) 23 milyon nəfər";
                button2.Text = "B) 30 milyon nəfər";
                button3.Text = "C) 42 milyon nəfər";
                button4.Text = "D) 90 milyon nəfər";
                duzgun_cvb   = "B) 30 milyon nəfər";
            }
            else if (suals == 3)
            {
                richTextBox1.Text = "Dəniz səviyyəsindən daha yüksəkdə yerləşən ərazi hansidir ?";
                button1.Text = "A) DAŞKƏSƏN";
                button2.Text = "B) XANKƏNDİ";
                button3.Text = "C) NAXÇIVAN";
                button4.Text = "D) ŞAMAXI";
                duzgun_cvb = "A) DAŞKƏSƏN";
            }
            else if (suals == 4)
            {
                richTextBox1.Text = "Yeganə quru sərhəd qonşusu İspaniya olan ölkə hansıdır ?";
                button1.Text = "A) MƏRAKEŞ";
                button2.Text = "B) FRANSA";
                button3.Text = "C) PORTUQALİYA";
                button4.Text = "D) ÇİLİ";
                duzgun_cvb = "C) PORTUQALİYA";
            }
            else if (suals == 5)
            {
                richTextBox1.Text = "Azerbaycan harada yerlesir ?";
                button1.Text = "avropa";
                button2.Text = "amerika";
                button3.Text = "asiya";
                button4.Text = "afrika";
                duzgun_cvb = "asiya";
            }
            else if (suals == 6)
            {
                richTextBox1.Text = "Azerbaycan harada yerlesir ?";
                button1.Text = "avropa";
                button2.Text = "amerika";
                button3.Text = "asiya";
                button4.Text = "afrika";
                duzgun_cvb = "asiya";
            }
            else if (suals == 7)
            {
                MessageBox.Show("oyun bitmisdir", "Diqqet!!",MessageBoxButtons.OK,MessageBoxIcon.Question);
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
               // Application.Restart();
               
               
            }
        }

        void duzgun()
        {
            duz++;
            san++;
            label7.Text = duz.ToString();
            xal += 100;
            label5.Text = xal.ToString();
            pictureBox2.Visible = true;
            axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\du.mp3";
            if (san == 2)
            {
            //    timer1.Stop();
              //  axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\du.mp3";
            }

        }
        void yanlis()
        {
            serf++;
            san++;
            label6.Text = serf.ToString();
            xal -= 100;
            label5.Text = xal.ToString();
            pictureBox1.Visible = true;
            axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\se.mp3";
          //  if (san == 2)
            {
              //  timer1.Stop();
              //  axWindowsMediaPlayer1.URL = "C:\\Users\\murad\\OneDrive\\Masaüstü\\se.mp3";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            if (button1.Text == duzgun_cvb)
            {
                duzgun();
                button1.BackColor=Color.Green;
              //  timer1.Start();
            }
            else
            {
                yanlis();
                button1.BackColor = Color.Red;
                //timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            if (button2.Text == duzgun_cvb)
            {
                duzgun();
                button2.BackColor = Color.Green;
                //timer1.Start();
            }
            else
            {
                yanlis();
                button2.BackColor = Color.Red;
               // timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            if (button3.Text == duzgun_cvb)
            {
                duzgun();
                button3.BackColor = Color.Green;
               // timer1.Start();
            }
            else
            {
                yanlis();
                button3.BackColor = Color.Red;
                //timer1.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            if (button4.Text == duzgun_cvb)
            {
                duzgun();
                button4.BackColor = Color.Green;
              //  timer1.Start();
            }
            else
            {
                yanlis();
                button4.BackColor = Color.Red;
            //    timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
