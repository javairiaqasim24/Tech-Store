using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Markup;
using TechStore.BL.Models;
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
            panel2.Height = 2000;
            UIHelper.StyleGridView(dataGridView1);
            UIHelper.StyleGridView(dataGridView2);
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
            loadgrid();
            timer1.Start();

        }
        private void load()
        {
            lblbest.Text = idl.GetDashboardSummary().bestproduct.ToString();
            lbltotalp.Text = idl.GetDashboardSummary().totalproducts.ToString();
            lblsales.Text = idl.GetDashboardSummary().salestodays.ToString();
            lblsupp.Text = idl.GetDashboardSummary().totalsuppliers.ToString();
            lblcustomers.Text = idl.GetDashboardSummary().totalcustomers.ToString();
            lblreturn.Text = idl.GetDashboardSummary().returns.ToString();
            lblbills.Text = idl.GetDashboardSummary().pendingbills.ToString();
            LoadChartData();
            LoadCategoryPieChart();
            LoadSupplierChart();
            LoadCompareChart();
        }

        private void loadgrid()
        {
            var list = idl.recentlogs();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["log_date"].Visible = false;
            dataGridView1.Columns["remark"].Visible = false;

            var lists = idl.outofstock();
            dataGridView2.DataSource = lists;
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["category"].Visible = false;


        }
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadChartData()
        {
            // Clear previous data
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Add chart area
            var area = new ChartArea("SalesArea")
            {
                BackColor = Color.FromArgb(21, 61, 147) // Match dark background
            };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.White;
            area.AxisY.LineColor = Color.White;
            area.AxisX.Title = "Date";
            area.AxisY.Title = "Total Sales (Rs)";
            area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Interval = 1;
            chart1.ChartAreas.Add(area);

            // Add legend
            var legend = new Legend("SalesLegend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            chart1.Legends.Add(legend);

            // Add series
            var series = new Series("Daily Sales")
            {
                ChartType = SeriesChartType.Spline, // smoother line
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                Color = Color.FromArgb(255, 191, 0), // Bright Gold Line
                MarkerColor = Color.FromArgb(255, 191, 0),

                XValueType = ChartValueType.String,
                IsValueShownAsLabel = false,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            chart1.Series.Add(series);

            // Add title
            chart1.Titles.Add("Sales Trend - Current Month");
            chart1.Titles[0].Font = new Font("Segoe UI", 13, FontStyle.Bold);
            chart1.Titles[0].ForeColor = Color.White;

            // Load data
            var salesData = idl.GetMonthlySalesTrend();
            foreach (var entry in salesData)
            {
                int pointIndex = series.Points.AddXY(entry.Day.ToString("dd MMM"), entry.TotalSales);
                series.Points[pointIndex].ToolTip = $"{entry.Day:dd MMM}: Rs {entry.TotalSales:N0}";
            }
        }

        private void LoadCompareChart()
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Titles.Clear();
            chart2.Legends.Clear();

            // Chart Area
            var area = new ChartArea("CompareArea")
            {
                BackColor = Color.FromArgb(21, 61, 147),
            };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.White;
            area.AxisY.LineColor = Color.White;
            area.AxisX.Title = "Month";
            area.AxisY.Title = "Sales (Rs)";
            area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Interval = 1;
            chart2.ChartAreas.Add(area);

            // Legend
            var legend = new Legend("CompareLegend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            chart2.Legends.Add(legend);

            // Series
            var series = new Series("Monthly Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(255, 191, 0),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                IsValueShownAsLabel = true,
                XValueType = ChartValueType.String,
                LabelForeColor = Color.White
            };
            chart2.Series.Add(series);

            // Title
            chart2.Titles.Add("Monthly Sales - Current Year");
            chart2.Titles[0].Font = new Font("Segoe UI", 13, FontStyle.Bold);
            chart2.Titles[0].ForeColor = Color.White;

            // Data
            var data = idl.GetMonthlySalesComparison();
            foreach (var entry in data)
            {
                var point = series.Points.AddXY(entry.MonthName, entry.TotalSales);
                series.Points[point].ToolTip = $"{entry.MonthName}: Rs {entry.TotalSales:N0}";
            }
        }

        private void LoadSupplierChart()
        {
            chart3.Series.Clear();
            chart3.ChartAreas.Clear();
            chart3.Titles.Clear();
            chart3.Legends.Clear();

            // Chart Area
            var area = new ChartArea("SupplierArea")
            {
                BackColor = Color.FromArgb(21, 61, 147)
            };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.White;
            area.AxisY.LineColor = Color.White;
            area.AxisX.Title = "Supplier";
            area.AxisY.Title = "Batches Supplied";
            area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;
            area.AxisX.LabelStyle.Angle = -45;
            chart3.ChartAreas.Add(area);

            // Legend
            var legend = new Legend("SupplierLegend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            chart3.Legends.Add(legend);

            // Series
            var series = new Series("Top Suppliers")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(255, 191, 0), // Bright gold
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                IsValueShownAsLabel = true,
                XValueType = ChartValueType.String,
                LabelForeColor = Color.White
            };
            chart3.Series.Add(series);

            // Title
            chart3.Titles.Add("Top Supplier Contributions");
            chart3.Titles[0].Font = new Font("Segoe UI", 13, FontStyle.Bold);
            chart3.Titles[0].ForeColor = Color.White;

            // Data
            var data = idl.GetTopSupplierContributions();
            foreach (var entry in data)
            {
                var point = series.Points.AddXY(entry.SupplierName, entry.TotalBatches);
                series.Points[point].ToolTip = $"{entry.SupplierName}: {entry.TotalBatches} batches";
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void coparechart_Click(object sender, EventArgs e)
        {

        }
        private void LoadCategoryPieChart()
        {
            piechart.Series.Clear();
            piechart.ChartAreas.Clear();
            piechart.Titles.Clear();
            piechart.Legends.Clear();

            // Chart Area (not visible in Pie, but added for consistency)
            ChartArea area = new ChartArea("CategoryArea");
            area.BackColor = Color.FromArgb(21, 61, 147); // Dark blue background
            piechart.ChartAreas.Add(area);

            // Legend
            Legend legend = new Legend("CategoryLegend");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Near;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            legend.ForeColor = Color.Black;
            piechart.Legends.Add(legend);

            // Series
            Series series = new Series("Product Categories")
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 9),
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White, // Label inside pie
                LegendText = "#VALX",
                Label = "#PERCENT{P0}"
            };
            piechart.Series.Add(series);

            // Title
            Title title = new Title("Product Category Distribution");
            title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            title.ForeColor = Color.White;
            piechart.Titles.Add(title);

            // Fetch Data
            var categoryData = idl.GetProductCategoryDistribution(); // <-- make sure this line exists

            // Add Data Points
            foreach (var (category, count) in categoryData)
            {
                int pointIndex = series.Points.AddXY(category, count);
                series.Points[pointIndex].ToolTip = $"{category}: {count} products";
            }

            // Pie Styling
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
        }


        private void supplierchart_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("hh:mm:ss tt");

            // Determine greeting based on time
            var hour = DateTime.Now.Hour;
            string greeting;

            if (hour >= 5 && hour < 12)
                greeting = "Good Morning";
            else if (hour >= 12 && hour < 17)
                greeting = "Good Afternoon";
            else if (hour >= 17 && hour < 21)
                greeting = "Good Evening";
            else
                greeting = "Good Night";

            // Get user's name from session
            string name = Usersession.FullName ?? "Nadir Jamal";

            label10.Text = $"{greeting}, {name}";
        }
    }
}