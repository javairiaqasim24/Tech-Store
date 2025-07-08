using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Inventorylogform : Form
    {
        private readonly IInventorylogBl ibl;
        public Inventorylogform(IInventorylogBl ibl)
        {
            InitializeComponent(); UIHelper.StyleGridView(dataGridView2);

            this.ibl = ibl;
        }

        private void Inventorylogform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var list = ibl.getlog("");
            dataGridView2.DataSource=list;
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            var list = ibl.getlog(searchTerm).OrderByDescending(log=>log.log_date);
            dataGridView2.DataSource = list;
        }

      

    }
}
