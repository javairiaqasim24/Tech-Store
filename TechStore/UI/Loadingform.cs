using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechStore.UI
{
    public partial class Loadingform : Form
    {
        public Loadingform()
        {
            InitializeComponent();

            // panel1 is the outer scrollable container
            //panel1.AutoScroll = true;
            //panel1.Dock = DockStyle.Fill;

            //// panel2 is the scroll area container (DO NOT autosize it)
            //panel2.Dock = DockStyle.Fill;

            //// contentPanel is the actual container that grows vertically
            //var contentPanel = new Panel
            //{
            //    AutoSize = true,
            //    AutoSizeMode = AutoSizeMode.GrowAndShrink,
            //    Dock = DockStyle.Top
            //};

            //// Add growing contentPanel into panel2
            //panel2.Controls.Add(contentPanel);

            //// Now add all your controls to contentPanel
            //contentPanel.Controls.Add(tableLayoutPanel1);
            //contentPanel.Controls.Add(tableLayoutPanel2);
            //contentPanel.Controls.Add(panel16);
            //// etc...

            //// Add panel2 into panel1
            //panel1.Controls.Add(panel2);
        }


        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void combocustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            //TogglePanel(panel, 60, 251);
        }
        private void CollapsePanel(Panel panel, int collapsedHeight)
        {
            panel.Height = collapsedHeight;
        }

        private void ExpandPanel(Panel panel, int expandedHeight)
        {
            panel.Height = expandedHeight;
        }

        private void TogglePanel(Panel panel, int collapsedHeight, int expandedHeight)
        {
            if (panel.Height == expandedHeight)
                CollapsePanel(panel, collapsedHeight);
            else
                ExpandPanel(panel, expandedHeight);
        }


        private void Loadingform_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            //TogglePanel(panel3, 60, 183);

        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            //TogglePanel(panel4, 60, 251);
        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
        {
            //TogglePanel(panel5, 60, 251);

        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            //TogglePanel(panel6, 60, 182);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           //lbltime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
