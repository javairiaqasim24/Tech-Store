using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;
using TechStore.UI;

namespace TechStore.UI
{
    public partial class Customerform : Form
    {
        private readonly ICustomerBL _customerBL;
        private readonly IPersonFactory _personFactory;
        private int selectedCustomerId;

        public Customerform(ICustomerBL customerBL, IPersonFactory personFactory)
        {
            InitializeComponent();
            this._customerBL = customerBL;
            this._personFactory = personFactory;
            paneledit.Visible = false;

            dataGridView2.CellContentClick += dataGridView2_CellContentClick;

            UIHelper.ApplyButtonStyles(dataGridView2);
        }

        private void Customerform_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var list = _customerBL.GetCustomers();
            dataGridView2.Columns.Clear();

            dataGridView2.DataSource = list;
            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dataGridView2.Columns[e.ColumnIndex].Name;
            var row = dataGridView2.Rows[e.RowIndex];
            selectedCustomerId = Convert.ToInt32(row.Cells["id"].Value);

            if (columnName == "Edit")
            {
                txtname.Text = row.Cells["firstname"].Value?.ToString();
                txtlname.Text = row.Cells["lastname"].Value?.ToString();
                txtcontact.Text = row.Cells["phone"].Value?.ToString();
                string type = row.Cells["type"].Value?.ToString() ?? "Walk_in";
                comboBox1.Text = type;

                if (type == "Regular")
                {
                    txtemail.Text = row.Cells["email"].Value?.ToString();
                    txtaddress.Text = row.Cells["address"].Value?.ToString();
                    ToggleRegularFields(true);
                }
                else
                {
                    txtemail.Text = "";
                    txtaddress.Text = "";
                    ToggleRegularFields(false);
                }

                UIHelper.RoundPanelCorners(paneledit, 20);
                UIHelper.ShowCenteredPanel(this, paneledit);
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool result = _customerBL.DeleteCustomer(selectedCustomerId);
                    MessageBox.Show(result ? "Customer deleted successfully." : "Failed to delete customer.", result ? "Deleted" : "Error",
                        MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (result) LoadCustomers();
                }
            }
        }

        private void ToggleRegularFields(bool visible)
        {
            lblEmail.Visible = txtemail.Visible = visible;
            lblAddress.Visible = txtaddress.Visible = visible;

            if (!visible)
            {
                txtemail.Text = "";
                txtaddress.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleRegularFields(comboBox1.Text == "Regular");
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string lname = txtlname.Text.Trim();
            string email = txtemail.Text.Trim();
            string phone = txtcontact.Text.Trim();
            string address = txtaddress.Text.Trim();
            string type = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("First name, Last name, Type, and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (type == "Regular" && (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address)))
            {
                MessageBox.Show("Email and Address are required for regular customers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var customer = (Customer)_personFactory.CreatePerson(PersonType.Customer, selectedCustomerId, email, address, name, phone, lname, type);
                bool result = _customerBL.UpdateCustomer(customer);

                MessageBox.Show(result ? "Customer updated successfully." : "Failed to update customer.", result ? "Success" : "Error",
                    MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    ClearForm();
                    paneledit.Visible = false;
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtname.Clear();
            txtlname.Clear();
            txtcontact.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadCustomers();
                return;
            }

            var results = _customerBL.SearchCustomers(searchText);
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = results;

            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddCustomerform>();
            f.ShowDialog(this);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;
        }
    }
}
