using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Supplierform : Form
    {
        private int selectedProductId;
        private readonly ISupplierBL supplierBL;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Supplierform(ISupplierBL supplierBL)
        {
            InitializeComponent();
            this.supplierBL = supplierBL;
            UIHelper.StyleGridView(dataGridView2);

            paneledit.Visible = false;
             UIHelper.ApplyButtonStyles(dataGridView2);
        }

        private void Supplierform_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            List<Supplier> list = supplierBL.getsuppliers().OfType<Supplier>().ToList();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;


            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false;
            //dataGridView2.Columns["_firstname"].Visible = false;
            //dataGridView2.Columns["_lastname"].Visible = false;
            //dataGridView2.Columns["_type"].Visible = false;
 

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
     
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            string name = txtname1.Text.Trim();
            string address = txtaddress.Text.Trim();
            string email = txtemail.Text.Trim();
            string phone = txtcontact.Text.Trim();

            try
            {
                var supplier = new Supplier(selectedProductId, email, address, name, phone);
                bool result = supplierBL.updatesupplier(supplier);

                MessageBox.Show(result ? "Supplier updated successfully." : "Failed to update supplier.",
                                result ? "Success" : "Error",
                                MessageBoxButtons.OK,
                                result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    ClearFields();
                    paneledit.Visible = false;
                    LoadSuppliers();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while Updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtname1.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            txtcontact.Clear();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<Addsupplierform>();
            form.ShowDialog(this);
        }

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadSuppliers();
            }
            else
            {
                List<Supplier> list =supplierBL.searchsuppliers(search).OfType<Supplier>().ToList();
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = list;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.Columns["id"].Visible = false;

                //dataGridView2.Columns["_firstname"].Visible = false;
                //dataGridView2.Columns["_lastname"].Visible = false;
                //dataGridView2.Columns["_type"].Visible = false;
                UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
                UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
            }
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            Dashboard.Instance.LoadFormIntoPanel(Program.ServiceProvider.GetRequiredService<orders>());
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = dataGridView2.Rows[e.RowIndex];
            selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                txtname1.Text = row.Cells["_name"].Value?.ToString() ?? "";
                txtaddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtemail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["phone"].Value?.ToString() ?? "";

                UIHelper.RoundPanelCorners(paneledit, 20);
                UIHelper.ShowCenteredPanel(this, paneledit);
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool result = supplierBL.deletesupplier(selectedProductId);
                    MessageBox.Show(result ? "Supplier deleted successfully." : "Failed to delete supplier.",
                                    result ? "Deleted" : "Error",
                                    MessageBoxButtons.OK,
                                    result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (result) LoadSuppliers();
                }
            }
        }

        private void btncategory_Click_1(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<PurchaseInvoice>();
            Dashboard.Instance.LoadFormIntoPanel(f);
        }
    }
}
