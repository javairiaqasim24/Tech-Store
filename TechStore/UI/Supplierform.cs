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
            dataGridView2.Focus();

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


            UIHelper.AddButtonColumn(dataGridView2, "EditColumn", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "DeleteColumn", "Delete", "Delete");


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (txtname1.Focused || txtaddress.Focused || txtemail.Focused || txtcontact.Focused)
                {
                    btnsave1.PerformClick();
                    return true;
                }
                else if (dataGridView2.ContainsFocus)
                {
                    TriggerEditForCurrentRow();
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                btnadd.PerformClick();
                return true;
            }
            else if (keyData == Keys.Delete && dataGridView2.ContainsFocus)
            {
                DeleteSelectedRow();
                return true;
            }
            else if (keyData == Keys.Escape && paneledit.Visible)
            {
                paneledit.Visible = false;
                dataGridView2.Focus();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void TriggerEditForCurrentRow()
        {
            if (dataGridView2.CurrentRow == null)
                return;

            int editColIndex = -1;

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                if (col is DataGridViewButtonColumn && col.Name == "EditColumn")
                {
                    editColIndex = col.Index;
                    break;
                }
            }

            if (editColIndex >= 0)
            {
                var args = new DataGridViewCellEventArgs(editColIndex, dataGridView2.CurrentRow.Index);
                dataGridView2_CellContentClick_1(dataGridView2, args);
            }
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView2.CurrentRow == null)
                return;

            int rowIndex = dataGridView2.CurrentRow.Index;
            int id = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool result = supplierBL.deletesupplier(id);
                    MessageBox.Show(result ? "Supplier deleted successfully." : "Failed to delete supplier.",
                                    result ? "Deleted" : "Error",
                                    MessageBoxButtons.OK,
                                    result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (result)
                        LoadSuppliers();
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UIHelper.AddButtonColumn(dataGridView2, "EditColumn", "Edit", "Edit");
                UIHelper.AddButtonColumn(dataGridView2, "DeleteColumn", "Delete", "Delete");

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

            if (columnName == "EditColumn")
            {
                txtname1.Text = row.Cells["_name"].Value?.ToString() ?? "";
                txtaddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtemail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["phone"].Value?.ToString() ?? "";

                UIHelper.RoundPanelCorners(paneledit, 20);
                UIHelper.ShowCenteredPanel(this, paneledit);
                paneledit.Visible = true;
            }
            else if (columnName == "DeleteColumn")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        bool result = supplierBL.deletesupplier(selectedProductId);
                        MessageBox.Show(result ? "Supplier deleted successfully." : "Failed to delete supplier.",
                                        result ? "Deleted" : "Error",
                                        MessageBoxButtons.OK,
                                        result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                        if (result) LoadSuppliers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
