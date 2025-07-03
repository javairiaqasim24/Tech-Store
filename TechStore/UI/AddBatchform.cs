using MySql.Data.MySqlClient;
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
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class AddBatchform : Form
    {
        private readonly IBatchesBl _batchesBl;
        public AddBatchform(IBatchesBl _batchesBl)
        {
            InitializeComponent();
            this._batchesBl = _batchesBl;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string batchname = txtname.Text.Trim();
            string suppliername = comboBox1.Text.Trim();
            DateTime date = dateTimePicker1.Value;
            try
            {
               var batches=new Batches(0, batchname, suppliername, date);
                // Assuming you have a method to save the batch
                bool result =_batchesBl.AddBatches (batches); // Replace with actual save logic
                if (result)
                {
                    MessageBox.Show("Batch added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear();
                    comboBox1.SelectedIndex = -1; // Clear the selected supplier
                    dateTimePicker1.Value = DateTime.Now; // Reset to current date
                }
                else
                {
                    MessageBox.Show("Failed to add batch. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Database error occurred while adding batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
