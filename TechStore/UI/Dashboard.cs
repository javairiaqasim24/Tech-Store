using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.UI;

namespace TechStore
{
    public partial class Dashboard : Form
    {
        private Form activeForm = null;
        private IconButton currentBtn;

        public static Dashboard Instance { get; private set; }

        public Dashboard()
        {
            InitializeComponent();
            Instance = this;
            this.Activated += Dashboard_Activated;
           panel10.Dock = DockStyle.Fill;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);


        }


        private void btninventory_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));
            var f =Program.ServiceProvider.GetRequiredService<Inventoryform>();
            LoadFormIntoPanel(f);
        }


        public async void LoadFormIntoPanel(Form newForm)
        {
            if (newForm == null || newForm == activeForm) return;

            if (activeForm != null)
            {
                await FadeOutFormAsync(activeForm);
                panel10.Controls.Remove(activeForm); // <- fix: match the one used below
                activeForm.Dispose();
            }

            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            newForm.Opacity = 0;
            panel10.Controls.Add(newForm); // Use same panel here
            newForm.Show();

            await FadeInFormAsync(newForm);
        }



        private async Task FadeOutFormAsync(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                while (form.Opacity > 0)
                {
                    if (form.IsDisposed) return;

                    form.Opacity -= 0.05;
                    await Task.Delay(10);
                }
                form.Opacity = 0;
            }
            catch (ObjectDisposedException)
            {
                // Safe exit
            }
        }
        private async Task FadeInFormAsync(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                while (form.Opacity < 1)
                {
                    if (form.IsDisposed) return;

                    form.Opacity += 0.05;
                    await Task.Delay(10);
                }
                form.Opacity = 1;
            }
            catch (ObjectDisposedException)
            {
                // Safe exit
            }
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            this.TopMost = true;   // Push to front
            this.TopMost = false;  // Reset
            this.BringToFront();
        }


        private void btndashboard_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 126, 249));

            var f = Program.ServiceProvider.GetRequiredService<HomeContentform>();
            LoadFormIntoPanel(f);
        }
        private void CollapsePanel(Panel panel, int collapsedHeight)
        {
            panel.Height = collapsedHeight;
        }

        private void ExpandPanel(Panel panel, int expandedHeight)
        {
            panel.Height = expandedHeight;
        }
        private void CollapseAllTogglePanels()
        {
            CollapsePanel(panelbatch, 60);
            CollapsePanel(panelcust, 60);
            CollapsePanel(panelsupp, 60);
            CollapsePanel(panelreturn, 60);
            CollapsePanel(panelinventory, 60);
        }

        private void TogglePanel(Panel panel, int collapsedHeight, int expandedHeight)
        {
            if (panel.Height == expandedHeight)
                CollapsePanel(panel, collapsedHeight);
            else
                ExpandPanel(panel, expandedHeight);
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            activebutton(btndashboard, Color.FromArgb(0, 126, 249));
            var f = Program.ServiceProvider.GetRequiredService<HomeContentform>();
            LoadFormIntoPanel(f);
            this.WindowState = FormWindowState.Maximized;
            this.PerformLayout();
            this.Refresh();

        }
        private void activebutton(object senderbtn, System.Drawing.Color color)
        {
            // Reset previous button
            disablebutton();

            // Set the new button as current
            currentBtn = (IconButton)senderbtn;
            currentBtn.BackColor = System.Drawing.Color.FromArgb(5, 51, 69);
            currentBtn.ForeColor = color;
            //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
        }
        private void disablebutton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.Transparent;
                currentBtn.ForeColor = System.Drawing.Color.White; // Fixed: Assigning a valid color value  
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.White; // Fixed: Assigning a valid color value  
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[4]);
            var f = Program.ServiceProvider.GetRequiredService<Customersale>();
            LoadFormIntoPanel(f);

        }

        private void btnrepair_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(231, 76, 60));
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[2]);
            var f = Program.ServiceProvider.GetRequiredService<Customerform>();
            LoadFormIntoPanel(f);
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[3]);
            var f = Program.ServiceProvider.GetRequiredService<Supplierform>();
            LoadFormIntoPanel(f);
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[5]);
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[6]);

        }
        private readonly Color[] sidebarColors = new Color[]
{
    Color.FromArgb(0, 126, 250),   // Tech Blue
    Color.FromArgb(0, 207, 255),   // Sky Cyan
    Color.FromArgb(26, 188, 156),  // Lime Mint
    Color.FromArgb(255, 140, 66),  // Coral Orange
    Color.FromArgb(155, 89, 182),  // Soft Purple
    Color.FromArgb(46, 204, 113),  // Leaf Green
    Color.FromArgb(231, 76, 60)    // Rose Red
};

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnrecord_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f =Program.ServiceProvider.GetRequiredService<Inventorylogform>();
            LoadFormIntoPanel(f);
        }

        private void btninventory_Click_1(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Inventoryform>();
            LoadFormIntoPanel(f);
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<productsform>();
            LoadFormIntoPanel(f);
        }

        private void btncategories_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Addcategoryform>();
            f.ShowDialog(this);
        }

        private void btnbatches_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Batchesform>();
            LoadFormIntoPanel(f);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<BatchDetailsform>();
            LoadFormIntoPanel(f);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<Inventoryform>();
            f.ShowDialog(this);
        }

        private void btnsale_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Customersale>();
            LoadFormIntoPanel(f);
        }
        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            if (panelbatch.Height == 183)
                CollapsePanel(panelbatch, 60);
            else
            {
                CollapseAllTogglePanels();
                ExpandPanel(panelbatch, 183);
            }
        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
        {
            if (panelsupp.Height == 132)
                CollapsePanel(panelsupp, 60);
            else
            {
                CollapseAllTogglePanels();
                ExpandPanel(panelsupp, 132);
            }
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            if (panelreturn.Height == 195)
                CollapsePanel(panelreturn, 60);
            else
            {
                CollapseAllTogglePanels();
                ExpandPanel(panelreturn, 195);
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (panelinventory.Height == 251)
                CollapsePanel(panelinventory, 60);
            else
            {
                CollapseAllTogglePanels();
                ExpandPanel(panelinventory, 251);
            }
        }


        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            if (panelcust.Height == 130)
            {
                CollapsePanel(panelcust, 60); // collapse if already expanded
            }
            else
            {
                CollapseAllTogglePanels();    // collapse all first
                ExpandPanel(panelcust, 130);  // then expand this one
            }
        }


     

        private void btnbatches_Click_1(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Batchesform>();
            LoadFormIntoPanel(f);
        }

        private void btnbatchdetails_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<BatchDetailsform>();
            LoadFormIntoPanel(f);
        }

        private void btnadddetails_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<AddbatchDetailsform>();
            f.ShowDialog(this);
        }

        private void btnSreturn_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Supplier_eturnsform>();
            LoadFormIntoPanel(f);
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<PurchaseInvoice>();
            LoadFormIntoPanel(f);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncustomerbill_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<BillingRecordsOverview>();
            LoadFormIntoPanel(f);
        }

        private void btnSbills_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Supplierbillsform>();
            LoadFormIntoPanel(f);
        }

        private void bntcustomerreturn_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Customerreturns>();
            LoadFormIntoPanel(f);
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<reportform>();
            f.ShowDialog(this);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            if (panel1.Height == 195)
                CollapsePanel(panel1, 67);
            else
            {
                CollapseAllTogglePanels();
                ExpandPanel(panel1, 195);
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<Services>();
            LoadFormIntoPanel(f);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));

            var f = Program.ServiceProvider.GetRequiredService<serviceform>();
            LoadFormIntoPanel(f);
        }
    }
}
