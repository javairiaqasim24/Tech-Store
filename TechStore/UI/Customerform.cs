using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Customerform : Form
    {
        private readonly ICustomerBL _customerBL;
        private readonly IPersonFactory _personFactory;
        private int selectedProductId;

        public Customerform(ICustomerBL _customerBL,IPersonFactory _personFactory)
        {
            InitializeComponent();
          this.  _customerBL = _customerBL;
            this._personFactory = _personFactory;
            paneledit.Visible = false;
            dataGridView2.CellPainting += dataGridView2_CellPainting;

        }
        public void ShowEditPanel()
        {
            paneledit.Left = (this.ClientSize.Width - paneledit.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneledit.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<AddCustomerform>();
            f.ShowDialog(this);
        }
        private void load()
        {
            var list = _customerBL.GetCustomers();
            dataGridView2.Columns.Clear(); // <-- Important to prevent duplicate buttons

            dataGridView2.DataSource = list;
            dataGridView2.Columns["Id"].Visible = false; // Hide the Id column
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust columns to fill the grid
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            editButton.Name = "Edit";
            dataGridView2.Columns.Add(editButton);

            // Add Delete button
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Name = "Delete";
            dataGridView2.Columns.Add(deleteButton);
        }
        private void Customerform_Load(object sender, EventArgs e)
        {
            load();

        }
        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var column = dataGridView2.Columns[e.ColumnIndex];

            if (column.Name == "Edit" || column.Name == "Delete")
            {
                e.PaintBackground(e.CellBounds, true);

                string text = column.Name;
                Color backColor = text == "Edit" ? Color.SteelBlue : Color.IndianRed;
                Color textColor = Color.White;

                using (Brush b = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    dataGridView2.Font,
                    e.CellBounds,
                    textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
        public void RoundPanelCorners(Panel panel, int radius)
        {
            var bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            int diameter = radius * 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                var row = dataGridView2.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);

                txtname.Text = row.Cells["firstname"].Value?.ToString() ?? "";
                txtlname.Text = row.Cells["lastname"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["phone"].Value?.ToString() ?? "";

                string type = row.Cells["type"].Value?.ToString() ?? "Walk_in";
                comboBox1.Text = type;

                if (type == "Regular")
                {
                    txtemail.Text = row.Cells["email"].Value?.ToString() ?? "";
                    txtaddress.Text = row.Cells["address"].Value?.ToString() ?? "";

                    txtemail.Visible = true;
                    lblEmail.Visible = true;

                    txtaddress.Visible = true;
                    lblAddress.Visible = true;
                }
                else // Walk_in
                {
                    txtemail.Text = string.Empty;
                    txtemail.Visible = false;
                    lblEmail.Visible = false;

                    txtaddress.Text = string.Empty;
                    txtaddress.Visible = false;
                    lblAddress.Visible = false;
                }

                RoundPanelCorners(paneledit, 20);
                ShowEditPanel();
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                    bool result = _customerBL.DeleteCustomer(id);

                    if (result)
                    {
                        MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Regular")
            {
                lblEmail.Visible = true;
                txtemail.Visible = true;

                lblAddress.Visible = true;
                txtaddress.Visible = true;
            }
            else if (comboBox1.Text == "Walk_in")
            {
                lblEmail.Visible = false;
                txtemail.Visible = false;
                txtemail.Text = string.Empty;

                lblAddress.Visible = false;
                txtaddress.Visible = false;
                txtaddress.Text = string.Empty;
            }
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string lname = txtlname.Text.Trim();
            string email = txtemail.Text.Trim();
            string phone = txtcontact.Text.Trim();
            string address = txtaddress.Text.Trim();
            string type = comboBox1.Text;

            try
            {
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

                var person = _personFactory.CreatePerson(PersonType.Customer, selectedProductId, email, address, name, phone, lname, type);
                var customer = (Customer)person;

                bool result = _customerBL.UpdateCustomer(customer);
                if (result)
                {
                    MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear();
                    txtlname.Clear();
                    txtcontact.Clear();
                    txtemail.Clear();
                    txtaddress.Clear();
                    comboBox1.SelectedIndex = -1;
                    paneledit.Visible = false;
                    load();
                }
                else
                {
                    MessageBox.Show("Failed to update customer. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                load(); // Reload all customers
            }
            else
            {
                var results = _customerBL.SearchCustomers(searchText);
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = results;

                dataGridView2.Columns["Id"].Visible = false;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.HeaderText = "Edit";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.Name = "Edit";
                dataGridView2.Columns.Add(editButton);

                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                deleteButton.Name = "Delete";
                dataGridView2.Columns.Add(deleteButton);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
