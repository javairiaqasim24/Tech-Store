using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
         
        }


        private void btninventory_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 212, 255));
            LoadFormIntoPanel(new Inventoryform());
        }


       public async void LoadFormIntoPanel(Form newForm)
        {
            if (activeForm != null)
            {
                // Step 1: Fade out old form
                await FadeOutFormAsync(activeForm);

                // Step 2: Remove old form
                panel2.Controls.Remove(activeForm);
                activeForm.Dispose();
            }

            // Step 3: Load and fade in new form
            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            newForm.Opacity = 0; // Start invisible
            panel2.Controls.Add(newForm);
            newForm.Show();

            // Step 4: Fade in the new form
            await FadeInFormAsync(newForm);
        }

        private async Task FadeOutFormAsync(Form form)
        {
            while (form.Opacity > 0)
            {
                form.Opacity -= 0.05;
                await Task.Delay(10);
            }
            form.Opacity = 0;
        }

        private async Task FadeInFormAsync(Form form)
        {
            while (form.Opacity < 1)
            {
                form.Opacity += 0.05;
                await Task.Delay(10);
            }
            form.Opacity = 1;
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(0, 126, 249));

            LoadFormIntoPanel(new HomeContentform());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            activebutton(btndashboard, Color.FromArgb(0, 126, 249));
            LoadFormIntoPanel(new HomeContentform());

        }
        private void activebutton(object senderbtn, System.Drawing.Color color)
        {
            // Reset previous button
            disablebutton();

            // Set the new button as current
            currentBtn = (IconButton)senderbtn;
            currentBtn.BackColor = System.Drawing.Color.FromArgb(5, 51, 69);
            currentBtn.ForeColor = color;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;
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

        }

        private void btnrepair_Click(object sender, EventArgs e)
        {
            activebutton(sender, System.Drawing.Color.FromArgb(231, 76, 60));

        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[2]);

        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[3]);

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

    }
}
