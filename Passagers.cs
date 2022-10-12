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
    public partial class Passagers : Form
    {
        public Passagers()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");
       

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Passagers_Load(object sender, EventArgs e)
        {

        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                MessageBox.Show(" Complétez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "insert into Passager values('" + guna2TextBox4.Text + "','" + guna2TextBox3.Text + "','" + guna2TextBox1.Text + "','" + guna2TextBox5.Text + "','"+comboBox1.Text+ "','" + comboBox2.Text + "','" + guna2TextBox2.Text + "')";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" *Passager Ajouter Avec Sucsess ");
                    connection.Close();
                    

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox4.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox1.Text = "";
            guna2TextBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            guna2TextBox2.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UpdatePassengers passengers = new UpdatePassengers();
            passengers.Show();
            this.Hide();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
