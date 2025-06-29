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
    public partial class HomeContentform : Form
    {
        private Timer fadeInTimer;

        public HomeContentform()
        {
            SuspendLayout();
            InitializeComponent();
            this.Opacity = 0; // Start fully transparent
            fadeInTimer = new Timer();
            fadeInTimer.Interval = 10; // Milliseconds
            fadeInTimer.Tick += FadeInTimer_Tick;
            ResumeLayout();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Load += HomeContentform_Load;

            // After InitializeComponent or in Form_Load
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }
        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; // Fade speed: smaller = slower
            }
            else
            {
                this.Opacity = 1;
                fadeInTimer.Stop();
            }
        }

        void EnableDoubleBuffering(Control ctrl)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, ctrl, new object[] { true });
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void HomeContentform_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            EnableDoubleBuffering(panel10);
            EnableDoubleBuffering(panel11);
                        //EnableDoubleBuffering(panel13);

                        //EnableDoubleBuffering(panel12);
            EnableDoubleBuffering(tableLayoutPanel1);
            EnableDoubleBuffering(tableLayoutPanel2);
            EnableDoubleBuffering(panel3);
            EnableDoubleBuffering(panel4);
            EnableDoubleBuffering(panel5);        
            EnableDoubleBuffering(panel6);
EnableDoubleBuffering(panel7);

            EnableDoubleBuffering(panel8);
            EnableDoubleBuffering(chart1);
            //EnableDoubleBuffering(chart2);
            //EnableDoubleBuffering(chart3);
            EnableDoubleBuffering(pieChart1);
            this.ResumeLayout();
            fadeInTimer.Start(); // Start the fade-in effect when the form loads
        }
    }
}
