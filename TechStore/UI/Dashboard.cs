using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.UI;

namespace TechStore
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btninventory_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Inventoryform());
        }

        private void LoadFormIntoPanel(Form form)
        {
            panel2.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            form.Show();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new HomeContentform());
        }
    }
}
