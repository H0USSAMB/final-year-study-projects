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
    public partial class Annulation : Form
    {
        public Annulation()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-SMJQGPU\SQLEXPRESS;Initial Catalog=LARAM;Integrated Security=True");
        private void fillBilletcode()
        {
            if(connection.State==ConnectionState.Closed)
                connection.Open();


            SqlCommand cmd = new SqlCommand("select Bid from Billet", connection);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Bid", typeof(int));
            dt.Load(rdr);
            comboBox2.ValueMember = "Bid";
            comboBox2.DataSource = dt;
            connection.Close();
        }
        public void fetchVcode()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string query = "select * from Billet where Bid = '" + comboBox2.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                guna2TextBox1.Text = dr["Vcode"].ToString();
               
            }
            connection.Close();
        }
        private void populate()
        {
            if(connection.State == ConnectionState.Closed)
            connection.Open();
            string query = "select * from Annulation";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }
        private void suprimmerBillet()
        {
           
                try
                {
                    if(connection.State == ConnectionState.Closed)
                    connection.Open();
                    string req = "delete  from Billet where Bid=" + comboBox2.Text + "";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    
                    connection.Close();
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            
        }
        private void Annulation_Load(object sender, EventArgs e)
        {
            populate();
            fillBilletcode();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchVcode();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "" )
                MessageBox.Show(" Complétez les informations Svp ");
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string req = "insert into Annulation values(" + guna2TextBox6.Text + "," + comboBox2.Text + ",'" +guna2TextBox1.Text + "','"+dateTimePicker1.Text+"')";
                    SqlCommand command = new SqlCommand(req, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show(" *le billet est annuler ");

                    connection.Close();
                    populate();
                    suprimmerBillet();


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
            guna2TextBox1.Text = "";
            comboBox2.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
    
}
