using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quiz_application
{
    public partial class new_profil : Form
    {
        public new_profil()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ED33ER6\\MURADOFF_CODE;Initial Catalog=login;Integrated Security=True");
        bool netice;
        int otp=0, say;
        public void TekrarYoxla()
        {
            try
            {
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM login WHERE username =@usern or email=@email", con);
                komanda.Parameters.AddWithValue("@usern", textBox4.Text);
                komanda.Parameters.AddWithValue("@email", textBox5.Text);
                SqlDataReader dr = komanda.ExecuteReader();
               // con.Close();
                if (dr.Read())
                {
                    netice = false;
                }
                else
                {
                    netice = true;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Xeta bas verdi!! : " + ex.Message, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           finally
            {
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {


                    TekrarYoxla();
                    if (netice == true)
                    {
                        if (textBox6.Text == textBox7.Text && say >= 6 && otp <= 4)
                        {
                            con.Open();
                            SqlCommand komanda = new SqlCommand("INSERT INTO login (name, surname, age, username, email, password, OTPcode, adress, qeydiyyatTarixi) VALUES (@name,@surn,@age,@usern,@email,@password,@OTP,@adress, @tarix);", con);
                            komanda.Parameters.AddWithValue("@name", textBox1.Text);
                            komanda.Parameters.AddWithValue("@surn", textBox2.Text);
                            komanda.Parameters.AddWithValue("@age", Convert.ToInt32(textBox3.Text));
                            komanda.Parameters.AddWithValue("@usern", textBox4.Text);
                            komanda.Parameters.AddWithValue("@email", textBox5.Text);
                            komanda.Parameters.AddWithValue("@password", textBox6.Text);
                            komanda.Parameters.AddWithValue("@OTP", textBox8.Text);
                            komanda.Parameters.AddWithValue("@adress", textBox9.Text);
                            komanda.Parameters.AddWithValue("@tarix", textBox10.Text);
                            //komanda.Parameters.AddWithValue("@qTarix", textBox10.Text);
                            komanda.ExecuteNonQuery(); 
                            // con.Close();
                            MessageBox.Show("Uğurla qeydiyyatdan keçdiniz!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            textBox8.Clear();
                            textBox9.Clear();
                            textBox1.Focus();
                            progressBar1.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Məlumatlar xetalıdır!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            textBox8.Clear();
                            textBox9.Clear();
                            textBox1.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bele bir istifadeci adi ve ya email adresi var!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("TextBox bos qala bilmez!!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox1.Focus();
                }

            }
            catch (Exception ex)
            {
              MessageBox.Show("Xeta bas verdi!! : " + ex.Message, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           finally
            {
                con.Close();
            }
        }

        private void new_profil_Load(object sender, EventArgs e)
        {
            textBox10.Text = DateTime.Today.ToShortDateString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = false;
            pictureBox3.Visible = true;
            pictureBox1.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label10.Visible = true;
            label10.Text = textBox6.Text.Length.ToString();
            say = textBox6.Text.Length;
            progressBar1.Visible = true;


            if (say == 0)
            {
                progressBar1.Value = 0;
                label10.Visible = false;
                progressBar1.Visible = false;
            }
            else if (say <= 3)
            {
                //label10.BackColor = Color.Red;
                progressBar1.Value = 10;
                progressBar1.ForeColor = Color.Red;
            }
            else if (say <= 5)
            {
                //label10.BackColor = Color.Red;
                progressBar1.Value = 35;
                progressBar1.ForeColor = Color.Red;
            }
            else if (say >= 6 && say <= 8)
            {
                //label10.BackColor = Color.Yellow;
                progressBar1.Value = 45;
                progressBar1.ForeColor = Color.Yellow;
               
            }
            else if (say >= 12)
            {
                progressBar1.Value = 100;
                progressBar1.ForeColor = Color.Green;
            }
            else if (say >= 9)
            {
                //label10.BackColor = Color.Green;
                progressBar1.Value = 75;
                progressBar1.ForeColor = Color.Green;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
