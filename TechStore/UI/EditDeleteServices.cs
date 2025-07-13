//using System;
//using System.Data;
//using System.Globalization;
//using System.Windows.Forms;
//using TechStore.BL;
//using TechStore.BL.Models;

//namespace TechStore.UI
//{
//    public partial class EditDeleteServices : Form
//    {
//        private readonly EditDeleteServicesBL _bl;
//        private DataTable _servicesData;
//        private bool _isEditing = false;
//        private DataGridViewRow _editingRow;

//        public EditDeleteServices()
//        {
//            InitializeComponent();
//            _bl = new EditDeleteServicesBL();
//            InitializeData();
//            SetupDataGridView();
//        }

//        private void InitializeData()
//        {
//            _servicesData = _bl.GetAllServices();
//            dvgservices.DataSource = _servicesData;

//            var customers = _bl.GetAllCustomers();
//            cmbsearchcustomer.DataSource = customers;
//            cmbsearchcustomer.DisplayMember = "FullName";
//            cmbsearchcustomer.ValueMember = "CustomerId";
//            cmbsearchcustomer.SelectedIndex = -1;
//        }

//        private void SetupDataGridView()
//        {
//            // Make columns editable
//            dvgservices.Columns["customer_name"].ReadOnly = true; // Can't edit customer name directly
//            dvgservices.Columns["nameofitem"].ReadOnly = false;
//            dvgservices.Columns["problem_description"].ReadOnly = false;
//            dvgservices.Columns["status"].ReadOnly = false;
//            dvgservices.Columns["total_charge"].ReadOnly = false;
//            dvgservices.Columns["amount_paid"].ReadOnly = false;
//            dvgservices.Columns["recievedate"].ReadOnly = false;
//            dvgservices.Columns["deliverydate"].ReadOnly = false;

//            // Add action buttons
//            var saveCancelColumn = new DataGridViewButtonColumn
//            {
//                Name = "SaveCancel",
//                Text = "Edit/Save",
//                UseColumnTextForButtonValue = true
//            };

//            var deleteColumn = new DataGridViewButtonColumn
//            {
//                Name = "Delete",
//                Text = "Delete",
//                UseColumnTextForButtonValue = true
//            };

//            dvgservices.Columns.Add(saveCancelColumn);
//            dvgservices.Columns.Add(deleteColumn);

//            // Formatting
//            dvgservices.Columns["recievedate"].DefaultCellStyle.Format = "dd/MM/yyyy";
//            dvgservices.Columns["deliverydate"].DefaultCellStyle.Format = "dd/MM/yyyy";
//            dvgservices.Columns["total_charge"].DefaultCellStyle.Format = "C2";
//            dvgservices.Columns["amount_paid"].DefaultCellStyle.Format = "C2";
//        }

//        private void dvgservices_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            var column = dvgservices.Columns[e.ColumnIndex];
//            var row = dvgservices.Rows[e.RowIndex];

//            if (column.Name == "SaveCancel")
//            {
//                if (!_isEditing)
//                {
//                    // Start editing
//                    _isEditing = true;
//                    row.Cells["SaveCancel"].Value = "Save";
//                    dvgservices.ReadOnly = false;
//                    _editingRow = row;
//                }
//                else
//                {
//                    // Save changes
//                    if (ValidateRow(row))
//                    {
//                        SaveRowChanges(row);
//                        _isEditing = false;
//                        row.Cells["SaveCancel"].Value = "Edit";
//                        dvgservices.ReadOnly = true;
//                        _editingRow = null;
//                    }
//                }
//            }
//            else if (column.Name == "Delete" && !_isEditing)
//            {
//                DeleteService(row);
//            }
//        }

//        private bool ValidateRow(DataGridViewRow row)
//        {
//            if (string.IsNullOrEmpty(row.Cells["nameofitem"].Value?.ToString()))
//            {
//                MessageBox.Show("Item name cannot be empty!");
//                return false;
//            }

//            decimal totalCharge, amountPaid;
//            if (!decimal.TryParse(row.Cells["total_charge"].Value?.ToString(), out totalCharge) ||
//                !decimal.TryParse(row.Cells["amount_paid"].Value?.ToString(), out amountPaid))
//            {
//                MessageBox.Show("Invalid numeric values!");
//                return false;
//            }

//            if (amountPaid > totalCharge)
//            {
//                MessageBox.Show("Amount paid cannot exceed total charge!");
//                return false;
//            }

//            return true;
//        }

//        private void SaveRowChanges(DataGridViewRow row)
//        {
//            try
//            {
//                var serviceId = Convert.ToInt32(row.Cells["service_request_id"].Value);
//                var service = _bl.GetServiceById(serviceId);

//                if (service == null)
//                {
//                    MessageBox.Show("Service not found!");
//                    return;
//                }

//                // Update service object from grid
//                service.ServiceLine.NameOfItem = row.Cells["nameofitem"].Value?.ToString() ?? "";
//                service.ProblemDescription = row.Cells["problem_description"].Value?.ToString() ?? "";
//                service.Status = row.Cells["status"].Value?.ToString() ?? "Pending";

//                // Handle numeric fields
//                if (!decimal.TryParse(row.Cells["total_charge"].Value?.ToString(),
//                    NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal totalCharge))
//                {
//                    MessageBox.Show("Invalid total charge value!");
//                    return;
//                }

//                service.TotalCharge = totalCharge;

//                if (!decimal.TryParse(row.Cells["amount_paid"].Value?.ToString(),
//                    NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal amountPaid))
//                {
//                    MessageBox.Show("Invalid amount paid value!");
//                    return;
//                }

//                service.AmountPaid = amountPaid;

//                // Handle dates
//                if (!DateTime.TryParse(row.Cells["recievedate"].Value?.ToString(), out DateTime receiveDate))
//                {
//                    MessageBox.Show("Invalid receive date!");
//                    return;
//                }
//                service.ServiceLine.RecieveDate = receiveDate;

//                service.ServiceLine.DeliveryDate =
//                    DateTime.TryParse(row.Cells["deliverydate"].Value?.ToString(), out DateTime deliveryDate)
//                    ? deliveryDate
//                    : (DateTime?)null;

//                // Update payment status
//                service.PaymentStatus = service.AmountPaid >= service.TotalCharge ? "Paid" : "Due";

//                // Attempt to save
//                if (_bl.UpdateService(service))
//                {
//                    MessageBox.Show("Service updated successfully!");
//                    RefreshData();
//                }
//                else
//                {
//                    MessageBox.Show("Failed to update service. Check console for details.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error saving service: {ex.Message}");
//                Console.WriteLine($"Full error: {ex}");
//            }
//        }
//        private void RefreshData()
//        {
//            _servicesData = _bl.GetAllServices();
//            dvgservices.DataSource = _servicesData;
//            dvgservices.Refresh();
//        }

//        private void DeleteService(DataGridViewRow row)
//        {
//            if (MessageBox.Show("Delete this service?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
//            {
//                int serviceId = Convert.ToInt32(row.Cells["service_request_id"].Value);
//                if (_bl.DeleteService(serviceId))
//                {
//                    MessageBox.Show("Service deleted!");
//                    _servicesData = _bl.GetAllServices();
//                    dvgservices.DataSource = _servicesData;
//                }
//                else
//                {
//                    MessageBox.Show("Delete failed!");
//                }
//            }
//        }

//        private void cmbsearchcustomer_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbsearchcustomer.SelectedValue != null && !_isEditing)
//            {
//                int customerId = (int)cmbsearchcustomer.SelectedValue;
//                _servicesData = _bl.SearchServicesByCustomer(customerId);
//                dvgservices.DataSource = _servicesData;
//            }
//        }

//        private void dvgservices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
//        {
//            // Commit changes immediately when editing cells
//            if (dvgservices.IsCurrentCellDirty && _isEditing)
//            {
//                dvgservices.CommitEdit(DataGridViewDataErrorContexts.Commit);
//            }
//        }

//    }
//}


using System;
using System.Data;
using System.Windows.Forms;
using TechStore.BL;

namespace TechStore.UI
{
    public partial class EditDeleteServices : Form
    {
        public EditDeleteServices()
        {

            InitializeComponent();
            LoadCustomers();
            AddButtonColumns(); // Add Edit/Delete buttons to DataGridView
        }
        private void LoadCustomers()
        {
            var customers = EditDeleteServicesBL.GetAllCustomerNames();
            customers.Insert(0, "All Customers");
            cmbsearchcustomer.DataSource = customers;
        }

        private void AddButtonColumns()
        {
            if (!dvgservices.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editCol = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dvgservices.Columns.Add(editCol);
            }

            if (!dvgservices.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dvgservices.Columns.Add(deleteCol);
            }
        }


        private void dvgservices_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (editingServiceId == -1) return;

            var row = dvgservices.Rows[e.RowIndex];

            int serviceId = editingServiceId;
            string item = row.Cells["Item"].Value?.ToString();
            string status = row.Cells["Status"].Value?.ToString();
            string paymentStatus = row.Cells["PaymentStatus"].Value?.ToString();
            DateTime.TryParse(row.Cells["Received"].Value?.ToString(), out DateTime received);
            DateTime.TryParse(row.Cells["Delivery"].Value?.ToString(), out DateTime delivery);
            decimal.TryParse(row.Cells["Charge"].Value?.ToString(), out decimal charge);

            // Call BL to update
            bool success = EditDeleteServicesBL.UpdateService(serviceId, item, status, paymentStatus, received, delivery, charge);

            if (success)
                MessageBox.Show("Service updated successfully!");
            else
                MessageBox.Show("Failed to update service.");

            editingServiceId = -1;
        }


        private void cmbsearchcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbsearchcustomer.SelectedItem.ToString();
            // Make editable columns editable
            //dvgservices.ReadOnly = false;
            //dvgservices.Columns["service_id"].ReadOnly = true;
            //if (dvgservices.Columns.Contains("Customer")) dvgservices.Columns["Customer"].ReadOnly = true;
            //if (dvgservices.Columns.Contains("Edit")) dvgservices.Columns["Edit"].ReadOnly = true;
            //if (dvgservices.Columns.Contains("Delete")) dvgservices.Columns["Delete"].ReadOnly = true;


            if (selected == "All Customers")
            {
                dvgservices.DataSource = EditDeleteServicesBL.GetAllServices();
            }
            else
            {
                dvgservices.DataSource = EditDeleteServicesBL.GetServicesByCustomer(selected);
            }
        }
        private int editingServiceId = -1;


        private void dvgservices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dvgservices.Rows[e.RowIndex];
                int serviceId = Convert.ToInt32(row.Cells["service_id"].Value);

                if (dvgservices.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete this service?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        EditDeleteServicesBL.DeleteService(serviceId);
                        cmbsearchcustomer_SelectedIndexChanged(null, null);
                    }
                }
                else if (dvgservices.Columns[e.ColumnIndex].Name == "Edit")
                {
                    editingServiceId = serviceId;
                    MessageBox.Show("You can now edit the fields in this row. Press Enter to save.");
                }
            }
        }
        private void dvgservices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgservices.IsCurrentCellDirty)
            {
                dvgservices.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EditDeleteServices_Load(object sender, EventArgs e)
        {

        }
    }
}
