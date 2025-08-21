using KIMS;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class AddbatchDetailsform : Form
    {
        private readonly IBatchDetailsBL batchDetailsBL;
        private readonly IproductBl ibl;

        private int selectedProductId;
        private string selectedProductName;
        private string selectedProductDescription;
        public string InitialBatchName { get; set; }


        // Keep serials per product here (unique and easy to validate)
        private readonly Dictionary<int, HashSet<string>> serialsByProduct = new Dictionary<int, HashSet<string>>();

        // UI Enhancement properties
        private Label lblStatus;
        private ProgressBar progressBar;
        private Timer statusTimer;
        private ToolTip toolTip;

        public AddbatchDetailsform(IBatchDetailsBL batchDetailsBL, IproductBl ibl)
        {
            InitializeComponent();
            this.batchDetailsBL = batchDetailsBL;
            this.ibl = ibl;

            InitializeEnhancements();
            SetupEventHandlers();
            SetupTabOrder();
        }

        private void InitializeEnhancements()
        {
            // Initialize UI enhancements
            InitializeToolTips();
            InitializeStatusBar();
            InitializeFormAppearance();

            panel1.Visible = checkBox1.Checked;
            this.KeyPreview = true;
        }

        private void InitializeToolTips()
        {
            toolTip = new ToolTip();
            toolTip.SetToolTip(txtBnames, "Enter or select a batch name. Start typing to see suggestions.");
            toolTip.SetToolTip(txtpro, "Search for products by typing the product name");
            toolTip.SetToolTip(txtquantity, "Enter the quantity for this product");
            toolTip.SetToolTip(txtprice, "Enter the cost price for this batch");
            toolTip.SetToolTip(txtSprice, "Enter the selling price for this batch");
            toolTip.SetToolTip(txtserialinput, "Enter serial number for serialized products");
            toolTip.SetToolTip(checkBox1, "Check this if the product requires serial numbers");
            toolTip.SetToolTip(btnAdditem, "Add the selected product to the batch (Insert key)");
            toolTip.SetToolTip(btnsave, "Save the complete batch (Ctrl+S)");
            toolTip.SetToolTip(dataGridView1, "Double-click to edit quantities or serials. Press Delete to remove items.");
        }

        private void InitializeStatusBar()
        {
            // Create status label
            lblStatus = new Label();
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Green;
            lblStatus.Font = new Font(this.Font, FontStyle.Italic);
            lblStatus.AutoSize = true;
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.Location = new Point(10, this.Height - 30);
            this.Controls.Add(lblStatus);

            // Create progress bar (initially hidden)
            progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progressBar.Size = new Size(200, 20);
            progressBar.Location = new Point(this.Width - 220, this.Height - 30);
            progressBar.Visible = false;
            this.Controls.Add(progressBar);

            // Timer for auto-hiding status messages
            statusTimer = new Timer();
            statusTimer.Interval = 3000; // 3 seconds
            statusTimer.Tick += (s, e) => {
                lblStatus.Text = "Ready";
                lblStatus.ForeColor = Color.Green;
                statusTimer.Stop();
            };
        }

        private void InitializeFormAppearance()
        {
            // Improve form appearance
            this.BackColor = Color.FromArgb(240, 248, 255); // Light blue background

            // Style buttons
            StyleButton(btnAdditem, Color.FromArgb(70, 130, 180), "➕ Add Item");
            StyleButton(btnsave, Color.FromArgb(34, 139, 34), "💾 Save Batch");

            // Style the serialization panel
            if (panel1 != null)
            {
                panel1.BackColor = Color.FromArgb(255, 248, 220); // Light yellow
                panel1.BorderStyle = BorderStyle.FixedSingle;
            }

            // Style checkBox1
            if (checkBox1 != null)
            {
                checkBox1.Text = "📋 Product requires serial numbers";
                checkBox1.Font = new Font(this.Font, FontStyle.Bold);
            }
        }

        private void StyleButton(Button button, Color backColor, string text)
        {
            if (button == null) return;

            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            button.Text = text;
            button.Cursor = Cursors.Hand;

            // Hover effects
            button.MouseEnter += (s, e) => {
                button.BackColor = ControlPaint.Light(backColor, 0.2f);
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = backColor;
            };
        }

        private void SetupEventHandlers()
        {
            this.KeyDown += AddbatchDetailsform_KeyDown;

            // Hooks
            txtpro.TextChanged += txtproducts_TextChanged;
            txtBnames.TextChanged += txtBname_TextChanged;
            dataGridView2.CellClick += dataGridView2_CellClick;
            //btnsave.Click += btnsave_Click;
            //btnAdditem.Click += btnAddItem_Click;

            // Enhanced grid edit helpers
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellContextMenuStripNeeded += dataGridView1_CellContextMenuStripNeeded;

            // Form events
            this.FormClosing += AddbatchDetailsform_FormClosing;
            this.Resize += AddbatchDetailsform_Resize;

            // Input validation
            txtquantity.KeyPress += NumericTextBox_KeyPress;
            txtprice.KeyPress += DecimalTextBox_KeyPress;
            txtSprice.KeyPress += DecimalTextBox_KeyPress;
        }

        private void SetupTabOrder()
        {
            txtBnames.TabIndex = 0;
            txtpro.TabIndex = 1;
            dataGridView2.TabIndex = 2;
            txtquantity.TabIndex = 3;
            txtprice.TabIndex = 4;
            txtSprice.TabIndex = 5;
            txtserialinput.TabIndex = 6;
            btnAdditem.TabIndex = 7;
            btnsave.TabIndex = 8;
        }

        private void AddbatchDetailsform_Load(object sender, EventArgs e)
        {
            ShowStatus("Loading form data...", Color.Blue);
            load();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1_CheckedChanged(null, null);
            SetupGrid();
            if (!string.IsNullOrEmpty(InitialBatchName))
                txtBnames.Text = InitialBatchName;

            var dto = BatchFormPersistence.Load();
            if (dto != null)
            {
                RestoreState(dto);
                ShowStatus("Previous session restored", Color.Green);
            }
            else
            {
                ShowStatus("Ready to add batch details", Color.Green);
            }
        }

        private void AddbatchDetailsform_Resize(object sender, EventArgs e)
        {
            // Reposition status controls
            if (lblStatus != null)
                lblStatus.Location = new Point(10, this.Height - 50);
            if (progressBar != null)
                progressBar.Location = new Point(this.Width - 220, this.Height - 50);
        }

        private void ShowStatus(string message, Color color)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = message;
                lblStatus.ForeColor = color;
                statusTimer.Stop();
                statusTimer.Start();
            }
        }

        private void ShowProgress(bool show)
        {
            if (progressBar != null)
                progressBar.Visible = show;
        }

        // Input validation event handlers
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ShowStatus("Please enter numbers only", Color.Red);
            }
        }

        private void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.' || textBox.Text.Contains('.')))
            {
                e.Handled = true;
                ShowStatus("Please enter valid decimal numbers", Color.Red);
            }
        }

        // ===== Enhanced Grid Event Handlers =====

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                // If clicking on serials column for a serialized product, open editor
                if (columnName == "Serials")
                {
                    bool isSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);
                    if (isSerialized)
                    {
                        OpenSerialNumberEditor(e.RowIndex);
                    }
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Prevent direct editing of serials column - use our custom editor instead
            if (columnName == "Serials")
            {
                bool isSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);
                if (isSerialized)
                {
                    e.Cancel = true;
                    OpenSerialNumberEditor(e.RowIndex);
                }
            }
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                bool isSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);

                var contextMenu = new ContextMenuStrip();

                if (isSerialized)
                {
                    var editSerialsItem = new ToolStripMenuItem("✏️ Edit Serial Numbers");
                    editSerialsItem.Click += (s, args) => OpenSerialNumberEditor(e.RowIndex);
                    contextMenu.Items.Add(editSerialsItem);

                    contextMenu.Items.Add(new ToolStripSeparator());
                }

                var deleteItem = new ToolStripMenuItem("🗑️ Delete Item");
                deleteItem.Click += (s, args) => DeleteGridRow(e.RowIndex);
                contextMenu.Items.Add(deleteItem);

                e.ContextMenuStrip = contextMenu;
            }
        }

        private void OpenSerialNumberEditor(int rowIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
            string productName = row.Cells["ProductName"].Value?.ToString();
            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

            var currentSerials = GetSerialsForRow(productId, row).ToList();

            using (var editor = new SerialNumberEditorDialog(productName, quantity, currentSerials))
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                {
                    // Update the serials
                    var newSerials = editor.GetSerialNumbers();

                    // Update our cache
                    if (!serialsByProduct.TryGetValue(productId, out var set))
                    {
                        set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        serialsByProduct[productId] = set;
                    }

                    set.Clear();
                    foreach (var serial in newSerials)
                        set.Add(serial);

                    // Update the grid display
                    row.Cells["Serials"].Value = string.Join(", ", newSerials);

                    // Update quantity if changed
                    if (newSerials.Count != quantity && newSerials.Count > 0)
                    {
                        row.Cells["Quantity"].Value = newSerials.Count;
                        ShowStatus($"Quantity updated to {newSerials.Count} to match serial count", Color.Blue);
                    }

                    ShowStatus($"Updated serials for {productName} ({newSerials.Count}/{quantity})", Color.Green);
                    PersistState();
                }
            }
        }

        private void DeleteGridRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[rowIndex];
                string productName = row.Cells["ProductName"].Value?.ToString();

                if (MessageBox.Show($"Are you sure you want to remove '{productName}' from this batch?",
                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int pid = Convert.ToInt32(row.Cells["ProductID"].Value);
                    serialsByProduct.Remove(pid);
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    ShowStatus($"Removed {productName}", Color.Green);
                    UpdateFormTitle();
                    PersistState();
                }
            }
        }

        private void AddbatchDetailsform_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Auto-save current state when form is closing
            if (HasUnsavedChanges())
            {
                var result = MessageBox.Show(
                    "You have unsaved changes. Do you want to save them before closing?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PersistState();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            PersistState();
        }

        private bool HasUnsavedChanges()
        {
            return !string.IsNullOrWhiteSpace(txtBnames.Text) ||
                   !string.IsNullOrWhiteSpace(txtprice.Text) ||
                   !string.IsNullOrWhiteSpace(txtSprice.Text) ||
                   dataGridView1.Rows.Count > 0;
        }

        private void RestoreState(TempBatchDetailDTO dto)
        {
            if (dto == null) return;

            try
            {
                ShowProgress(true);

                txtBnames.Text = dto.BatchName ?? string.Empty;
                txtprice.Text = dto.CostPrice.ToString();
                txtSprice.Text = dto.SalePrice.ToString();

                dataGridView1.Rows.Clear();
                serialsByProduct.Clear();

                foreach (var line in dto.Products ?? new List<ProductLine>())
                {
                    dataGridView1.Rows.Add(line.ProductID, line.ProductName ?? string.Empty,
                                           line.Description ?? string.Empty,
                                           line.IsSerialized, line.Quantity,
                                           string.Join(", ", line.Serials ?? new List<string>()));

                    if (line.IsSerialized && line.Serials?.Count > 0)
                        serialsByProduct[line.ProductID] = new HashSet<string>(line.Serials, StringComparer.OrdinalIgnoreCase);
                }

                ShowStatus($"Restored {dto.Products?.Count ?? 0} products from previous session", Color.Green);
            }
            catch (Exception ex)
            {
                ShowStatus("Error restoring previous session", Color.Red);
                System.Diagnostics.Debug.WriteLine($"Error restoring state: {ex.Message}");
                ClearFields();
            }
            finally
            {
                ShowProgress(false);
            }
        }

        // ===== UI grids =====

        private void SetupGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

            var colId = new DataGridViewTextBoxColumn { Name = "ProductID", HeaderText = "Product ID", Visible = false, ReadOnly = true };
            var colName = new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "🏷️ Product Name", ReadOnly = true };
            var colDesc = new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "📝 Description", ReadOnly = true };
            var colIsSer = new DataGridViewCheckBoxColumn { Name = "IsSerialized", HeaderText = "Is Serialized", Visible = false, ReadOnly = true };
            var colQty = new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "📦 Quantity" };

            // Enhanced serials column with button for easy editing
            var colSerials = new DataGridViewTextBoxColumn
            {
                Name = "Serials",
                HeaderText = "🔢 Serial Numbers (Click to edit)",
                ReadOnly = true  // We'll handle editing through a custom dialog
            };

            dataGridView1.Columns.AddRange(colId, colName, colDesc, colIsSer, colQty, colSerials);

            // Add alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
        }

        // ===== Add item (serialized-aware) =====

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowProgress(true);

                if (selectedProductId ==-1)
                {
                    ShowStatus("Please select a product first", Color.Red);
                    MessageBox.Show("Please select a product from the search grid first.", "Product Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productId = selectedProductId;
                string productName = selectedProductName;
                string productDesc = selectedProductDescription;
                bool isSerialized = checkBox1.Checked;

                // Ensure there is a row for this product, and mode (serialized vs non) is consistent
                int rowIndex = FindRowByProductId(productId);
                if (rowIndex >= 0)
                {
                    bool rowIsSerialized = Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells["IsSerialized"].Value ?? false);
                    if (rowIsSerialized != isSerialized)
                    {
                        ShowStatus("Serialization mode conflict", Color.Red);
                        MessageBox.Show("You already added this product with a different serialization mode. Remove the row first to change mode.",
                                      "Mode Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (isSerialized)
                {
                    if (!ValidateSerializedProduct(productId, out int totalAllowed, out string serial))
                        return;

                    // Initialize serial bucket
                    if (!serialsByProduct.TryGetValue(productId, out var bucket))
                    {
                        bucket = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        serialsByProduct[productId] = bucket;
                    }

                    // No duplicates
                    if (bucket.Contains(serial))
                    {
                        ShowStatus("Duplicate serial number", Color.Red);
                        MessageBox.Show("This serial is already added for this product.", "Duplicate Serial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Respect quantity cap
                    if (bucket.Count >= totalAllowed)
                    {
                        ShowStatus("Quantity limit reached", Color.Red);
                        MessageBox.Show($"You already added {bucket.Count} serial(s). Cannot exceed quantity {totalAllowed}.",
                                      "Quantity Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Accept and update
                    bucket.Add(serial);

                    if (rowIndex < 0)
                    {
                        rowIndex = dataGridView1.Rows.Add(productId, productName, productDesc, true, totalAllowed, string.Join(", ", bucket));
                    }
                    else
                    {
                        dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = totalAllowed;
                        dataGridView1.Rows[rowIndex].Cells["Serials"].Value = string.Join(", ", bucket);
                    }

                    txtserialinput.Clear();
                    txtserialinput.Focus();
                    ShowStatus($"Serial added ({bucket.Count}/{totalAllowed})", Color.Green);
                }
                else
                {
                    if (!int.TryParse(txtquantity.Text.Trim(), out int qty) || qty <= 0)
                    {
                        ShowStatus("Invalid quantity", Color.Red);
                        MessageBox.Show("Enter a valid Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtquantity.Focus();
                        return;
                    }

                    if (rowIndex >= 0)
                    {
                        int existingQty = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Quantity"].Value);
                        dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = existingQty + qty;
                        ShowStatus($"Quantity updated to {existingQty + qty}", Color.Green);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(productId, productName, productDesc, false, qty, "");
                        ShowStatus("Product added successfully", Color.Green);
                    }

                    txtquantity.Clear();
                    txtpro.Focus();
                }

                // Auto-save after adding item
                PersistState();
                UpdateFormTitle();
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private bool ValidateSerializedProduct(int productId, out int totalAllowed, out string serial)
        {
            totalAllowed = 0;
            serial = string.Empty;

            if (!int.TryParse(txtquantity.Text.Trim(), out totalAllowed) || totalAllowed <= 0)
            {
                ShowStatus("Invalid quantity for serialized product", Color.Red);
                MessageBox.Show("Enter a valid Quantity first for the serialized product.", "Quantity Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtquantity.Focus();
                return false;
            }

            serial = txtserialinput.Text.Trim();
            if (string.IsNullOrWhiteSpace(serial))
            {
                ShowStatus("Serial number required", Color.Red);
                MessageBox.Show("Serial number required for serialized products.", "Serial Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtserialinput.Focus();
                return false;
            }

            return true;
        }

        private void UpdateFormTitle()
        {
            int itemCount = dataGridView1.Rows.Count;
            this.Text = $"Add Batch Details - {itemCount} item{(itemCount != 1 ? "s" : "")} added";
        }

        // ===== Save (strict validation for serialized) =====

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ShowProgress(true);
                ShowStatus("Validating batch data...", Color.Blue);

                if (!ValidateBatchData(out string batchname, out decimal costPrice, out decimal salePrice))
                    return;

                ShowStatus("Saving batch to database...", Color.Blue);

                // Persist to database
                int savedItems = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    string productName = row.Cells["ProductName"].Value?.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    bool isSerializedRow = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);

                    List<string> serialNumbers = isSerializedRow
                        ? GetSerialsForRow(productId, row).ToList()
                        : new List<string>();

                    var batchDetails = new Batchdetails(
                        0, 0, productId, productName, quantity, costPrice, batchname
                    );

                    bool result = batchDetailsBL.AddBatchDetailsWithSerial(
                        batchDetails, serialNumbers, salePrice, isSerializedRow
                    );

                    if (!result)
                    {
                        ShowStatus($"Failed to save {productName}", Color.Red);
                        MessageBox.Show($"Failed to add product {productName}.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    savedItems++;
                }

                // Clear temporary persistence after successful save
                BatchFormPersistence.Clear();

                ShowStatus($"Successfully saved {savedItems} items", Color.Green);
                MessageBox.Show($"Batch '{batchname}' with {savedItems} items added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowStatus("Error saving batch", Color.Red);
                MessageBox.Show("Error while saving batch: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private bool ValidateBatchData(out string batchname, out decimal costPrice, out decimal salePrice)
        {
            batchname = string.Empty;
            costPrice = 0;
            salePrice = 0;

            batchname = txtBnames.Text.Trim();
            if (string.IsNullOrWhiteSpace(batchname))
            {
                ShowStatus("Batch name required", Color.Red);
                MessageBox.Show("Please select or enter a batch name.", "Batch Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBnames.Focus();
                return false;
            }

            if (!decimal.TryParse(txtprice.Text.Trim(), out costPrice))
            {
                ShowStatus("Invalid cost price", Color.Red);
                MessageBox.Show("Enter a valid Cost Price.", "Invalid Cost Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtprice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSprice.Text.Trim(), out salePrice))
            {
                ShowStatus("Invalid sale price", Color.Red);
                MessageBox.Show("Enter a valid Sale Price.", "Invalid Sale Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSprice.Focus();
                return false;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                ShowStatus("No products added", Color.Red);
                MessageBox.Show("Please add at least one product to the batch.", "No Products", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpro.Focus();
                return false;
            }

            // Final validation for serialized lines
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int pid = Convert.ToInt32(row.Cells["ProductID"].Value);
                bool rowIsSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);

                if (rowIsSerialized)
                {
                    var serials = GetSerialsForRow(pid, row);

                    if (serials.Count != qty)
                    {
                        ShowStatus("Serial validation failed", Color.Red);
                        MessageBox.Show($"Serialized product '{row.Cells["ProductName"].Value}' requires exactly {qty} serial(s). You provided {serials.Count}.",
                                        "Serial Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        // ===== Helpers =====

        private int FindRowByProductId(int productId)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                    return row.Index;
            }
            return -1;
        }

        private HashSet<string> GetSerialsForRow(int productId, DataGridViewRow row)
        {
            string serialCell = row.Cells["Serials"].Value?.ToString() ?? string.Empty;
            var parsed = serialCell
                .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));

            if (!serialsByProduct.TryGetValue(productId, out var set))
            {
                set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                serialsByProduct[productId] = set;
            }

            // Sync cache with cell content
            set.Clear();
            foreach (var s in parsed)
                set.Add(s);

            // Re-write cell to normalized, de-duplicated list
            row.Cells["Serials"].Value = string.Join(", ", set);
            return set;
        }

        private void ClearFields()
        {
            
            txtpro.Clear();
            txtquantity.Clear();
            txtprice.Clear();
            txtSprice.Clear();
            txtserialinput.Clear();
            dataGridView1.Rows.Clear();
            serialsByProduct.Clear();
            selectedProductId = -1;

            BatchFormPersistence.Clear();
            UpdateFormTitle();
            ShowStatus("Form cleared", Color.Green);
        }

        private void txtproducts_TextChanged(object sender, EventArgs e)
        {
            string text = txtpro.Text.Trim();

            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    var list = DatabaseHelper.Instance.GetProductsByNames(text);
                    dataGridView2.DataSource = list;
                    dataGridView2.Visible = true;
                    dataGridView2.BringToFront();

                    // Optional: hide extra columns if present
                    if (dataGridView2.Columns.Contains("price")) dataGridView2.Columns["price"].Visible = false;
                    if (dataGridView2.Columns.Contains("quantity")) dataGridView2.Columns["quantity"].Visible = false;

                    ShowStatus($"Found {list?.Count ?? 0} matching products", Color.Blue);
                }
                catch (Exception ex)
                {
                    ShowStatus("Error searching products", Color.Red);
                    System.Diagnostics.Debug.WriteLine($"Error searching products: {ex.Message}");
                }
            }
            else
            {
                dataGridView2.Visible = false;
                ShowStatus("Ready", Color.Green);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView2.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                selectedProductName = row.Cells["name"].Value?.ToString();
                selectedProductDescription = row.Cells["description"].Value?.ToString();


                txtpro.Text = selectedProductName;
                txtSprice.Text = DatabaseHelper.Instance.getsaleprice(selectedProductId).ToString();
                dataGridView2.Visible = false;

                ShowStatus($"Selected: {selectedProductName}", Color.Green);
                txtquantity.Focus();
            }
        }

        private void txtBname_TextChanged(object sender, EventArgs e)
        {
           

            PersistState();
        }

        private void load()
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                ShowStatus("Serialization mode enabled", Color.Blue);
                txtserialinput.Focus();
            }
            else
            {
                ShowStatus("Regular quantity mode enabled", Color.Blue);
                txtquantity.Focus();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            try
            {
                // Quantity edited?
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Quantity")
                {
                    if (!int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int newQty) || newQty <= 0)
                    {
                        ShowStatus("Invalid quantity entered", Color.Red);
                        MessageBox.Show("Quantity must be a positive number.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["Quantity"].Value = 1;
                        return;
                    }

                    int pid = Convert.ToInt32(row.Cells["ProductID"].Value);
                    bool isSer = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);

                    if (isSer)
                    {
                        var set = GetSerialsForRow(pid, row);
                        if (newQty < set.Count)
                        {
                            var result = MessageBox.Show($"Setting quantity to {newQty} will remove {set.Count - newQty} serial numbers. Continue?",
                                                       "Reduce Serial Count", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                // Keep only the first newQty serials
                                var trimmed = set.Take(newQty).ToList();
                                set.Clear();
                                foreach (var s in trimmed) set.Add(s);
                                row.Cells["Serials"].Value = string.Join(", ", set);
                                ShowStatus($"Quantity reduced to {newQty}, excess serials removed", Color.Orange);
                            }
                            else
                            {
                                row.Cells["Quantity"].Value = set.Count;
                                return;
                            }
                        }
                        else
                        {
                            ShowStatus($"Quantity updated to {newQty}", Color.Green);
                        }
                    }
                    else
                    {
                        ShowStatus($"Quantity updated to {newQty}", Color.Green);
                    }
                }

                // Auto-save after editing
                PersistState();
            }
            catch (Exception ex)
            {
                ShowStatus("Error processing edit", Color.Red);
                System.Diagnostics.Debug.WriteLine($"Error in cell edit: {ex.Message}");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "Serials")
                {
                    bool isSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false);
                    if (isSerialized)
                    {
                        OpenSerialNumberEditor(e.RowIndex);
                    }
                    else
                    {
                        ShowStatus("This product is not serialized", Color.Orange);
                    }
                }
                else
                {
                    ShowStatus("Double-click to edit values. Press Enter to confirm.", Color.Blue);
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show($"Are you sure you want to remove {dataGridView1.SelectedRows.Count} item(s)?",
                                  "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int removedCount = 0;
                    foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                    {
                        int pid = Convert.ToInt32(r.Cells["ProductID"].Value);
                        serialsByProduct.Remove(pid);
                        dataGridView1.Rows.Remove(r);
                        removedCount++;
                    }

                    ShowStatus($"Removed {removedCount} item(s)", Color.Green);
                    UpdateFormTitle();
                    PersistState();
                }
                e.SuppressKeyPress = true;
            }
        }

        // ===== Shortcuts =====

        private void AddbatchDetailsform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                ShowStatus("Saving batch...", Color.Blue);
                btnsave.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                ShowStatus("Adding item...", Color.Blue);
                btnAdditem.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (HasUnsavedChanges())
                {
                    var result = MessageBox.Show("You have unsaved changes. Are you sure you want to close?",
                                               "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        e.SuppressKeyPress = true;
                        return;
                    }
                }
                this.Close();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                // Ctrl+N for new/clear
                if (HasUnsavedChanges())
                {
                    var result = MessageBox.Show("You have unsaved changes. Clear form anyway?",
                                               "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        e.SuppressKeyPress = true;
                        return;
                    }
                }
                ClearFields();
                ShowStatus("Form cleared - ready for new batch", Color.Green);
                e.SuppressKeyPress = true;
            }
        }

        private void PersistState()
        {
            try
            {
                var dto = new TempBatchDetailDTO
                {
                    BatchName = txtBnames.Text?.Trim() ?? string.Empty,
                    CostPrice = decimal.TryParse(txtprice.Text, out var cp) ? cp : 0,
                    SalePrice = decimal.TryParse(txtSprice.Text, out var sp) ? sp : 0,
                    Products = new List<ProductLine>()
                };

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ProductID"].Value == null) continue;

                    int pid = Convert.ToInt32(row.Cells["ProductID"].Value);
                    var line = new ProductLine
                    {
                        ProductID = pid,
                        ProductName = row.Cells["ProductName"].Value?.ToString() ?? string.Empty,
                        Description = row.Cells["Description"].Value?.ToString() ?? string.Empty,
                        IsSerialized = Convert.ToBoolean(row.Cells["IsSerialized"].Value ?? false),
                        Quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0),
                        Serials = GetSerialsForRow(pid, row)?.ToList() ?? new List<string>()
                    };
                    dto.Products.Add(line);
                }

                BatchFormPersistence.Save(dto);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error persisting state: {ex.Message}");
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<addproductform>();
            f.ShowDialog(this);
        }
    }

    // Serial Number Editor Dialog for easy editing
    public partial class SerialNumberEditorDialog : Form
    {
        private ListBox lstSerials;
        private TextBox txtNewSerial;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnOK;
        private Button btnCancel;
        private Label lblInfo;
        private Label lblCount;

        private readonly int maxQuantity;
        private readonly List<string> serialNumbers;

        public SerialNumberEditorDialog(string productName, int quantity, List<string> existingSerials)
        {
            maxQuantity = quantity;
            serialNumbers = new List<string>(existingSerials ?? new List<string>());

            InitializeDialog(productName);
            RefreshSerialsList();
            UpdateCountLabel();
        }

        private void InitializeDialog(string productName)
        {
            this.Text = $"Edit Serial Numbers - {productName}";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 248, 255);

            // Info label
            lblInfo = new Label();
            lblInfo.Text = $"Manage serial numbers for: {productName}";
            lblInfo.Font = new Font(this.Font, FontStyle.Bold);
            lblInfo.Location = new Point(10, 10);
            lblInfo.Size = new Size(460, 20);
            this.Controls.Add(lblInfo);

            // Count label
            lblCount = new Label();
            lblCount.Location = new Point(10, 35);
            lblCount.Size = new Size(460, 20);
            lblCount.ForeColor = Color.Blue;
            this.Controls.Add(lblCount);

            // Serial numbers list
            lstSerials = new ListBox();
            lstSerials.Location = new Point(10, 60);
            lstSerials.Size = new Size(350, 200);
            lstSerials.SelectionMode = SelectionMode.MultiExtended;
            lstSerials.Font = new Font("Consolas", 9);
            lstSerials.KeyDown += LstSerials_KeyDown;
            this.Controls.Add(lstSerials);

            // Add new serial input
            var lblNew = new Label();
            lblNew.Text = "Add Serial:";
            lblNew.Location = new Point(10, 270);
            lblNew.Size = new Size(80, 20);
            this.Controls.Add(lblNew);

            txtNewSerial = new TextBox();
            txtNewSerial.Location = new Point(10, 290);
            txtNewSerial.Size = new Size(200, 25);
            txtNewSerial.KeyDown += TxtNewSerial_KeyDown;
            this.Controls.Add(txtNewSerial);

            // Buttons
            btnAdd = new Button();
            btnAdd.Text = "➕ Add";
            btnAdd.Location = new Point(220, 289);
            btnAdd.Size = new Size(60, 27);
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            btnRemove = new Button();
            btnRemove.Text = "🗑️ Remove";
            btnRemove.Location = new Point(290, 289);
            btnRemove.Size = new Size(70, 27);
            btnRemove.Click += BtnRemove_Click;
            this.Controls.Add(btnRemove);

            // Dialog buttons
            btnOK = new Button();
            btnOK.Text = "💾 OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(300, 330);
            btnOK.Size = new Size(80, 30);
            btnOK.BackColor = Color.FromArgb(34, 139, 34);
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnOK);

            btnCancel = new Button();
            btnCancel.Text = "❌ Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(390, 330);
            btnCancel.Size = new Size(80, 30);
            btnCancel.BackColor = Color.FromArgb(220, 20, 60);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;
        }

        private void RefreshSerialsList()
        {
            lstSerials.Items.Clear();
            for (int i = 0; i < serialNumbers.Count; i++)
            {
                lstSerials.Items.Add($"{i + 1:D2}. {serialNumbers[i]}");
            }
        }

        private void UpdateCountLabel()
        {
            lblCount.Text = $"Serial Count: {serialNumbers.Count} / {maxQuantity} " +
                           (serialNumbers.Count == maxQuantity ? "✅ Complete" :
                            serialNumbers.Count > maxQuantity ? "⚠️ Too many" : "📝 Need more");

            lblCount.ForeColor = serialNumbers.Count == maxQuantity ? Color.Green :
                               serialNumbers.Count > maxQuantity ? Color.Red : Color.Blue;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddSerial();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedSerials();
        }

        private void TxtNewSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddSerial();
                e.SuppressKeyPress = true;
            }
        }

        private void LstSerials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedSerials();
                e.SuppressKeyPress = true;
            }
        }

        private void AddSerial()
        {
            string serial = txtNewSerial.Text.Trim();

            if (string.IsNullOrWhiteSpace(serial))
            {
                MessageBox.Show("Please enter a serial number.", "Serial Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewSerial.Focus();
                return;
            }

            if (serialNumbers.Any(s => s.Equals(serial, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("This serial number already exists.", "Duplicate Serial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewSerial.SelectAll();
                txtNewSerial.Focus();
                return;
            }

            if (serialNumbers.Count >= maxQuantity)
            {
                var result = MessageBox.Show($"You already have {maxQuantity} serial numbers. Add anyway?",
                                           "Quantity Exceeded", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            serialNumbers.Add(serial);
            RefreshSerialsList();
            UpdateCountLabel();
            txtNewSerial.Clear();
            txtNewSerial.Focus();

            // Auto-scroll to the new item
            if (lstSerials.Items.Count > 0)
            {
                lstSerials.SelectedIndex = lstSerials.Items.Count - 1;
                lstSerials.TopIndex = Math.Max(0, lstSerials.Items.Count - lstSerials.ClientSize.Height / lstSerials.ItemHeight);
            }
        }

        private void RemoveSelectedSerials()
        {
            if (lstSerials.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select serial number(s) to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var indicesToRemove = new List<int>();
            foreach (int index in lstSerials.SelectedIndices)
            {
                indicesToRemove.Add(index);
            }

            // Remove in reverse order to maintain indices
            indicesToRemove.Sort((a, b) => b.CompareTo(a));

            foreach (int index in indicesToRemove)
            {
                if (index >= 0 && index < serialNumbers.Count)
                {
                    serialNumbers.RemoveAt(index);
                }
            }

            RefreshSerialsList();
            UpdateCountLabel();

            // Restore selection to a nearby item
            if (lstSerials.Items.Count > 0 && indicesToRemove.Count > 0)
            {
                int newIndex = Math.Min(indicesToRemove[0], lstSerials.Items.Count - 1);
                lstSerials.SelectedIndex = newIndex;
            }
        }

        public List<string> GetSerialNumbers()
        {
            return new List<string>(serialNumbers);
        }
    }

    // Data Transfer Objects
    public class TempBatchDetailDTO
    {
        [JsonProperty("batchName")]
        public string BatchName { get; set; } = string.Empty;

        [JsonProperty("costPrice")]
        public decimal CostPrice { get; set; }

        [JsonProperty("salePrice")]
        public decimal SalePrice { get; set; }

        [JsonProperty("products")]
        public List<ProductLine> Products { get; set; } = new List<ProductLine>();
    }

    public class ProductLine
    {
        [JsonProperty("productId")]
        public int ProductID { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("isSerialized")]
        public bool IsSerialized { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("serials")]
        public List<string> Serials { get; set; } = new List<string>();
    }

    // Enhanced Persistence with better error handling
    public static class BatchFormPersistence
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TechStore",
            "temp_batch_details.json"
        );

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        };

        public static void Save(TempBatchDetailDTO dto)
        {
            try
            {
                if (dto == null) return;

                // Ensure directory exists
                var directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Add timestamp for debugging
                var wrapper = new
                {
                    SavedAt = DateTime.Now,
                    Data = dto
                };

                // Serialize to JSON using Newtonsoft.Json
                string jsonString = JsonConvert.SerializeObject(wrapper, JsonSettings);

                // Write to file with backup
                string backupPath = FilePath + ".backup";
                if (File.Exists(FilePath))
                {
                    File.Copy(FilePath, backupPath, true);
                }

                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving batch details: {ex.Message}");

                // Try to restore backup if main file is corrupted
                string backupPath = FilePath + ".backup";
                if (File.Exists(backupPath))
                {
                    try
                    {
                        File.Copy(backupPath, FilePath, true);
                    }
                    catch (Exception backupEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error restoring backup: {backupEx.Message}");
                    }
                }
            }
        }

        public static TempBatchDetailDTO Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return null;

                string jsonString = File.ReadAllText(FilePath);

                if (string.IsNullOrWhiteSpace(jsonString))
                    return null;

                // Try to deserialize with wrapper first (new format)
                try
                {
                    var wrapper = JsonConvert.DeserializeAnonymousType(jsonString, new { SavedAt = DateTime.Now, Data = (TempBatchDetailDTO)null }, JsonSettings);
                    return wrapper?.Data;
                }
                catch
                {
                    // Fall back to direct deserialization (old format)
                    return JsonConvert.DeserializeObject<TempBatchDetailDTO>(jsonString, JsonSettings);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading batch details: {ex.Message}");

                // Try backup file
                string backupPath = FilePath + ".backup";
                if (File.Exists(backupPath))
                {
                    try
                    {
                        string backupJson = File.ReadAllText(backupPath);
                        return JsonConvert.DeserializeObject<TempBatchDetailDTO>(backupJson, JsonSettings);
                    }
                    catch (Exception backupEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error loading backup: {backupEx.Message}");
                    }
                }

                return null;
            }
        }

        public static void Clear()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }

                string backupPath = FilePath + ".backup";
                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error clearing batch details: {ex.Message}");
            }
        }
    }
}