using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Addsupplierform : Form
    {
        private readonly ISupplierBL supplierBL;
        private readonly IPersonFactory personFactory;
        public Addsupplierform(ISupplierBL supplierBL, IPersonFactory personFactory)
        {
            InitializeComponent();
            this.supplierBL = supplierBL;
            this.personFactory = personFactory;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string address = txtaddress.Text.Trim();
            string contact = txtcontact.Text.Trim();
            string email = txtemail.Text.Trim();
            try
            {
                var person = personFactory.CreatePerson(PersonType.Supplier, 0, email, address, name,contact);
                var supplier = (Supplier)person;
                bool result = supplierBL.addsupplier(supplier);
                if (result)
                {
                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear();
                    txtemail.Clear();
                    txtaddress.Clear();
                    txtcontact.Clear(); // Clear the selected category
                }
                else
                {
                    MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}