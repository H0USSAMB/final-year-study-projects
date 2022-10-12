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

namespace rapport_Ram
{
    public partial class Vol : Form
    {
        public Vol()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_clear_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || guna2TextBox3.Text == "")
                MessageBox.Show(" Complétez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "insert into Vol values('" + TextBox_username.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" +guna2TextBox3.Text + "')";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" *Vol Ajouter Avec Sucsess ");
                    connection.Close();


                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Vol_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TextBox_username.Text = "";
            guna2TextBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UpdateVol vol = new UpdateVol();
            vol.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
