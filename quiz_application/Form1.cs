using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quiz_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ED33ER6\\MURADOFF_CODE;Initial Catalog=login;Integrated Security=True");
        public static string ad;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            pictureBox5.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            pictureBox5.Visible = false;
            pictureBox2.Visible = true;
        }
        int say;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label10.Text = textBox3.Text.Length.ToString();
            say = textBox3.Text.Length;
            label10.Visible = true;
            label5.Visible = true;
            progressBar1.Visible = true;
            label5.Text = "parol gucu";

            int kod = textBox3.Text.Length;
            if (kod > 0 && kod < 5)
            {
                progressBar1.Value = 1;
                progressBar1.ForeColor = Color.Red;
                label4.Text = "Zəif";
            }

            else if (kod >= 5 && kod < 9)
            {
                progressBar1.Value = 2;
                progressBar1.ForeColor = Color.Yellow;
                label4.Text = "Orta";
            }
            else if (kod >= 8)
            {
                progressBar1.Value = 3;
                progressBar1.ForeColor = Color.Green;
                label4.Text = "Güclü";
            }
            else if (say >= 8)
            {
                label5.Text = textBox3.Text.Length.ToString();
                say = textBox3.Text.Length;
            }
            else
            {
                progressBar1.Value = 0;
                label4.Text = "";
                label10.Visible = false;
                progressBar1.Visible = false;
                label5.Visible = false;
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ad = textBox1.Text;
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM login WHERE username = '" + textBox1.Text + "' and password = '" + textBox3.Text + "'", con);
                SqlDataReader dr = komanda.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giriş uğurludur!");
                    milyaner mil = new milyaner();
                    mil.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş xetalıdır!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("XETA bas verdi!! : " + ex.Message, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

     private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = DateTime.Today.ToLongDateString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new_profil q = new new_profil();
            q.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kod sa = new kod();
            sa.Show();
        }
    }
}