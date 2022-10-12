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
    public partial class Billets : Form
    {
        public Billets()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");
        private void populate()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string query = "select * from Billet";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        private void fillPassenger() 
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand cmd = new SqlCommand("select PassId from Passager", connection);
            SqlDataReader rdr;
            rdr= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PassId", typeof(int));
            dt.Load(rdr);
            comboBox2.ValueMember = "PassId";
            comboBox2.DataSource = dt;
            connection.Close();
        }
        private void fillVolcode()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand cmd = new SqlCommand("select Vcode from Vol", connection);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Vcode", typeof(int));
            dt.Load(rdr);
            comboBox1.ValueMember = "Vcode";
            comboBox1.DataSource = dt;
            connection.Close();
        }

        string Pname, Ppass, Pnat;
        public void fetchpassenger()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string query = "select * from passager where passId = '"+comboBox2.Text+"'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Pname = dr["PassNom"].ToString();
                Ppass = dr["Passport"].ToString();
                Pnat = dr["PassNat"].ToString();
                guna2TextBox4.Text = Pname;
                guna2TextBox3.Text = Ppass;
                guna2TextBox2.Text = Pnat;
            }
            connection.Close();
        }
        private void Billets_Load(object sender, EventArgs e)
        {
            populate();
            fillPassenger();
            fillVolcode();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox2.Text == "" || guna2TextBox1.Text == "")
                MessageBox.Show(" Complétez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "insert into Billet values(" + guna2TextBox6.Text + ",'" + comboBox1.Text + "','" + comboBox2.Text + "','" + guna2TextBox4.Text + "','" + guna2TextBox3.Text + "','" + guna2TextBox2.Text + "'," + guna2TextBox1.Text + ")";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" *Billet Ajouter Avec Sucsess ");
                    
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
            guna2TextBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox1.Text = "";

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchpassenger();

        }
    }
}
