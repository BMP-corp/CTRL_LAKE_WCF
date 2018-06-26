using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegreteriaWF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UsernameView.Text = "Segreteria";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //if password is correct
            MessageBox.Show("Credenziali corrette. Caricamento della home in corso...");
            this.Hide();
            HomeSegreteria homepage = new HomeSegreteria(UsernameView.Text);
            homepage.ShowDialog();
            this.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordInputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameView_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}
