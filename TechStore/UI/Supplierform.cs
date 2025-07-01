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
using System.Xml.Linq;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Supplierform : Form
    {
        private int selectedProductId;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private readonly ISupplierBL supplierBL;
        private readonly IPersonFactory ipf;
        public Supplierform(ISupplierBL supplierBL,IPersonFactory ipf)
        {
            InitializeComponent();
            this.supplierBL = supplierBL;
            this.ipf = ipf;
            paneledit.Visible = false;
        }
        public void ShowEditPanel()
        {
            paneledit.Left = (this.ClientSize.Width - paneledit.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneledit.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }
        private void load()
        {
            var list=supplierBL.getsuppliers();
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false; // Hide the ID column
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count>0) {
                var row = dataGridView2.SelectedRows[0];

                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtname1.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtaddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtemail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["phone"].Value?.ToString() ?? "";

                RoundPanelCorners(paneledit, 20);
                ShowEditPanel();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void Supplierform_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            string name = txtname1.Text.Trim();
            string address = txtaddress.Text.Trim();
            string email=txtemail.Text.Trim();
            string phone=txtcontact.Text.Trim();
            try
            {
                var person = ipf.CreatePerson(PersonType.Supplier, selectedProductId, email, address, name, phone);
                var supplier = (Supplier)person;
                bool result = supplierBL.updatesupplier(supplier);
                if (result)
                {
                    MessageBox.Show("supplier Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname1.Clear();
                    txtemail.Clear();
                    txtaddress.Clear();
                    txtcontact.Clear(); // Clear the selected category
                    load();
                }
                else
                {
                    MessageBox.Show("Failed to Update Supplier. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<Addsupplierform>();
            f.ShowDialog(this);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int productId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                    bool result = supplierBL.deletesupplier(productId);

                    if (result)
                    {
                        MessageBox.Show("Supplier deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete Supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text=textBox1.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                load(); // Reload all suppliers if the search text is empty
            }
            else
            {
                var suppliers = supplierBL.searchsuppliers(text);
                dataGridView2.DataSource = suppliers;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.Columns["id"].Visible = false; // Hide the ID column
            }
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            Dashboard.Instance.LoadFormIntoPanel(Program.ServiceProvider.GetRequiredService<orders>());
        }
    }
}
