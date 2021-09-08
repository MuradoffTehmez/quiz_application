using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quiz_application
{
    public partial class kod : Form
    {
        public kod()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ED33ER6\\MURADOFF_CODE;Initial Catalog=login;Integrated Security=True");
        bool netice;
        public void TekrarYoxla()
        {
            try
            {
                con.Open();
                SqlCommand komanda = new SqlCommand("SELECT * FROM login WHERE email =@email and OTPcode=@OTP", con);
                komanda.Parameters.AddWithValue("@email", textBox1.Text);
                komanda.Parameters.AddWithValue("@OTP", textBox2.Text);
                SqlDataReader dr = komanda.ExecuteReader();
                if (dr.Read())
                {
                    netice = true;
                }
                else
                {
                    netice = false;
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TekrarYoxla();
            if (netice == true)
            {
                try
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        con.Open();
                        SqlCommand komanda = new SqlCommand("UPDATE logn SET password=@new where OTPcode=@OTP and email=@email", con);
                        komanda.Parameters.AddWithValue("@email", textBox1.Text);
                        komanda.Parameters.AddWithValue("@OTP", textBox2.Text);
                        komanda.Parameters.AddWithValue("@new", textBox3.Text);
                        komanda.ExecuteNonQuery();
                        //con.Close();
                        MessageBox.Show("Uğurla kod deyişdirildi!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Məlumatlar xetalıdır!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xeta bas verdi!! :  " + ex.Message, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Bele istifaci yoxdur!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
