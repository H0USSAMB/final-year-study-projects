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
    public partial class UpdateVol : Form
    {
        public UpdateVol()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");
        private void populate()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string query = "select * from vol";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        private void UpdateVol_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || guna2TextBox3.Text == "")
                MessageBox.Show(" Compéltez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "update vol set Vsrc='" + comboBox1.Text + "',Vdest = '" +comboBox2.Text + "',VDate = '" + dateTimePicker1.Text + "',Vcap = '" + guna2TextBox3.Text + "' where Vcode = '" + TextBox_username.Text + "'";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" Vol Modifier Avec Sucsess ");
                    connection.Close();
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "")
                MessageBox.Show(" Selectionnez le Volr à Effacer ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "delete  from vol where Vcode=" + TextBox_username.Text+ "";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" Vol suprimé Avec Sucsess ");
                    connection.Close();
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TextBox_username.Text = "";
            guna2TextBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Vol vol = new Vol();
            vol.Show();
            this.Hide();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox_username.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
           
        }
    }
}
