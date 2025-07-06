using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.Interfaces;

namespace TechStore.UI
{
    public partial class HomeContentform : Form
    {
        private Timer fadeInTimer;
        private readonly Idashboard idl;
        public HomeContentform(Idashboard idl)
        {
            SuspendLayout();
            InitializeComponent();
           this.idl = idl;
            ResumeLayout();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Load += HomeContentform_Load;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }
  

     
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }

        private void HomeContentform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            lblbest.Text = idl.GetDashboardSummary().bestproduct.ToString();
            lbltotalp.Text=idl.GetDashboardSummary().totalproducts.ToString();
            lblsales.Text=idl.GetDashboardSummary().salestodays.ToString();
            lblsupp.Text=idl.GetDashboardSummary().totalsuppliers.ToString();
            lblcustomers.Text=idl.GetDashboardSummary().totalcustomers.ToString();
            lblreturn.Text=idl.GetDashboardSummary().returns.ToString();
        }


        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
