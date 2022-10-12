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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            Vol vol = new Vol();
            vol.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Passagers passagers = new Passagers();
            passagers.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Billets billets = new Billets();
            billets.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Annulation annulation = new Annulation();
            annulation.Show();
            this.Hide();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
