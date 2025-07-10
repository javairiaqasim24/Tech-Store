using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
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
            string password = txtpassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isValid = LoginDL.ValidateUser(username, password);

                if (!isValid)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Use Usersession values
                string role = Usersession.Role;
                string name = Usersession.FullName;

                MessageBox.Show($"Signed in as {role}", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                // Route based on role
                var dashboard = Program.ServiceProvider.GetRequiredService<Dashboard>();
                dashboard.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed due to an error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
