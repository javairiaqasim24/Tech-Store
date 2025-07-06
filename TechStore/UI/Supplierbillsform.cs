using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;

namespace TechStore.UI
{
    public partial class Supplierbillsform : Form
    {
        private readonly ISupplierBillBl ibl;
        public Supplierbillsform(ISupplierBillBl ibl)
        {
            InitializeComponent();
            this.ibl = ibl;
            UIHelper.StyleGridView(dataGridView2);

        }

        private void Supplierbillsform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var list = ibl.getbill();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["supplier_id"].Visible = false;
            dataGridView2.Columns["batch_id"].Visible = false;

            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");


        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text= textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {
                load();
            }
            var list = ibl.getbillbyname(text);
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource= list;
            dataGridView2.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int bill_id=Convert.ToInt32(textBox1.Text);
            var list=ibl.getbills(bill_id);
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");
            UIHelper.ApplyButtonStyles(dataGridView2);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

                if (columnName == "Details")
                {
                    var selectedBill = dataGridView2.Rows[e.RowIndex].DataBoundItem as Supplierbill;

                    if (selectedBill != null)
                    {
                        // Open new form and pass selected bill ID
                        var detailsForm = new Sbilldetailform(selectedBill.bill_id);
                        detailsForm.ShowDialog();
                    }
                }
            }
        }
    }
}
