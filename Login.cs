using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rapport_Ram
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            TextBox_username.Text = "";
            TextBox_password.Text = "";
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "" || TextBox_password.Text == "")
                MessageBox.Show("entrer le nom d'utulisateur et le mot de passe");
            else if(TextBox_username.Text=="Admin" && TextBox_password.Text=="Admin")
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            
            }
            else
            {
                MessageBox.Show("le nom d'utulisateur ou le mot de passe est incorect");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
