using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.DL;

namespace TechStore.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtname.Text.Trim();
            string password = txtpassword.Text; // don't trim passwords

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string role = LoginDL.ValidateUser(username, password);

                if (role == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (role == "Admin")
                {
                    MessageBox.Show("Signed in as Admin", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: Show main admin dashboard
                }
                else
                {
                    MessageBox.Show($"Signed in as {role}", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: Show role-specific dashboard
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed due to an error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
