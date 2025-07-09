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
            lbltotalp.Text = idl.GetDashboardSummary().totalproducts.ToString();
            lblsales.Text = idl.GetDashboardSummary().salestodays.ToString();
            lblsupp.Text = idl.GetDashboardSummary().totalsuppliers.ToString();
            lblcustomers.Text = idl.GetDashboardSummary().totalcustomers.ToString();
            lblreturn.Text = idl.GetDashboardSummary().returns.ToString();
            lblbills.Text = idl.GetDashboardSummary().pendingbills.ToString();
            LoadChartData();
            LoadCategoryPieChart();
            //LoadSupplierChart();
            //LoadCompareChart();
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

        //private void LoadCompareChart()
        //{
        //    coparechart.Series.Clear();
        //    coparechart.ChartAreas.Clear();
        //    coparechart.Titles.Clear();
        //    coparechart.Legends.Clear();

        //    // Chart Area
        //    var area = new ChartArea("CompareArea");
        //    area.AxisX.MajorGrid.LineColor = Color.LightGray;
        //    area.AxisY.MajorGrid.LineColor = Color.LightGray;
        //    area.AxisX.Title = "Month";
        //    area.AxisY.Title = "Sales (Rs)";
        //    area.AxisX.Interval = 1;
        //    area.AxisX.LabelStyle.Angle = -45;
        //    area.BackColor = Color.White;
        //    coparechart.ChartAreas.Add(area);

        //    // Legend
        //    var legend = new Legend("CompareLegend");
        //    legend.Docking = Docking.Top;
        //    legend.Alignment = StringAlignment.Center;
        //    legend.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    coparechart.Legends.Add(legend);

        //    // Series
        //    var series = new Series("Monthly Sales")
        //    {
        //        ChartType = SeriesChartType.Column,
        //        Color = Color.FromArgb(0, 153, 76), // Green
        //        Font = new Font("Segoe UI", 8),
        //        IsValueShownAsLabel = true,
        //        XValueType = ChartValueType.String
        //    };
        //    coparechart.Series.Add(series);

        //    // Title
        //    coparechart.Titles.Add("Monthly Sales - Current Year");
        //    coparechart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
        //    coparechart.Titles[0].ForeColor = Color.FromArgb(45, 45, 48);

        //    // Data
        //    var data = idl.GetMonthlySalesComparison();
        //    foreach (var entry in data)
        //    {
        //        var point = series.Points.AddXY(entry.MonthName, entry.TotalSales);
        //        series.Points[point].ToolTip = $"{entry.MonthName}: Rs {entry.TotalSales:N0}";
        //    }

        //}
        //private void LoadSupplierChart()
        //{
        //    supplierchart.Series.Clear();
        //    supplierchart.ChartAreas.Clear();
        //    supplierchart.Titles.Clear();
        //    supplierchart.Legends.Clear();

        //    // Chart Area
        //    var area = new ChartArea("SupplierArea");
        //    area.AxisX.MajorGrid.LineColor = Color.LightGray;
        //    area.AxisY.MajorGrid.LineColor = Color.LightGray;
        //    area.AxisX.Title = "Supplier";
        //    area.AxisY.Title = "Batches Supplied";
        //    area.AxisX.LabelStyle.Angle = -45;
        //    area.BackColor = Color.White;
        //    supplierchart.ChartAreas.Add(area);

        //    // Legend
        //    var legend = new Legend("SupplierLegend");
        //    legend.Docking = Docking.Top;
        //    legend.Alignment = StringAlignment.Center;
        //    legend.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    supplierchart.Legends.Add(legend);

        //    // Series
        //    var series = new Series("Top Suppliers")
        //    {
        //        ChartType = SeriesChartType.Bar,
        //        Color = Color.FromArgb(20, 107, 252), // Orange-brown
        //        Font = new Font("Segoe UI", 8),
        //        IsValueShownAsLabel = true,
        //        XValueType = ChartValueType.String
        //    };
        //    supplierchart.Series.Add(series);

        //    // Title
        //    supplierchart.Titles.Add("Top Supplier Contributions");
        //    supplierchart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
        //    supplierchart.Titles[0].ForeColor = Color.FromArgb(45, 45, 48);

        //    // Data
        //    var data = idl.GetTopSupplierContributions();
        //    foreach (var entry in data)
        //    {
        //        var point = series.Points.AddXY(entry.SupplierName, entry.TotalBatches);
        //        series.Points[point].ToolTip = $"{entry.SupplierName}: {entry.TotalBatches} batches";
        //    }

        //}

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

    }
}