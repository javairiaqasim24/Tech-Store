using Microsoft.Extensions.DependencyInjection;
using System;
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
        private readonly IPersonFactory ipf;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Supplierform(ISupplierBL supplierBL, IPersonFactory ipf)
        {
            InitializeComponent();
            this.supplierBL = supplierBL;
            this.ipf = ipf;

            paneledit.Visible = false;
             UIHelper.ApplyButtonStyles(dataGridView2);
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
        }

        private void Supplierform_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            var list = supplierBL.getsuppliers();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false;

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = dataGridView2.Rows[e.RowIndex];
            selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                txtname1.Text = row.Cells["name"].Value?.ToString() ?? "";
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

        private void btnsave1_Click(object sender, EventArgs e)
        {
            string name = txtname1.Text.Trim();
            string address = txtaddress.Text.Trim();
            string email = txtemail.Text.Trim();
            string phone = txtcontact.Text.Trim();

            try
            {
                var supplier = (Supplier)ipf.CreatePerson(PersonType.Supplier, selectedProductId, email, address, name, phone);
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
                var suppliers = supplierBL.searchsuppliers(search);
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = suppliers;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.Columns["id"].Visible = false;

                UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
                UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
            }
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            Dashboard.Instance.LoadFormIntoPanel(Program.ServiceProvider.GetRequiredService<orders>());
        }
    }
}
