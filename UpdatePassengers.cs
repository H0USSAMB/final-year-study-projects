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
    public partial class UpdatePassengers : Form
    {
        public UpdatePassengers()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");
        private void populate()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string query = "select * from Passager";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void UpdatePassengers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Passagers p = new Passagers();
            p.Show();
            this.Hide();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "")
                MessageBox.Show(" Selectionnez le Passager à Effacer ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "delete  from passager where Passid=" + guna2TextBox4.Text + "";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" Passager suprimé Avec Sucsess ");
                    connection.Close();
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox5.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text= guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox4.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox1.Text = "";
            guna2TextBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            guna2TextBox2.Text = ""; 
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                MessageBox.Show(" Compéltez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "update Passager set PassId = "+guna2TextBox4.Text+ ",PassNom='"+guna2TextBox3.Text+ "',Passport = '"+guna2TextBox1.Text+ "',PassAd = '"+guna2TextBox5.Text+ "',PassNat = '" + comboBox1.Text + "',PassSex = '" + comboBox2.Text + "',PassPhone = '" + guna2TextBox2.Text + "' where Passid = "+guna2TextBox4.Text+"";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" passager Modifier Avec Sucsess ");
                    connection.Close();
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
