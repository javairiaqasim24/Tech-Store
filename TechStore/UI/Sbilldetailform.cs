using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.DL;

namespace TechStore.UI
{
    public partial class Sbilldetailform : Form
    {
        private int billid;
        private readonly SbilldetailsDl sbillDetailsDl = new SbilldetailsDl();
        private readonly SupplierbillDl billDl = new SupplierbillDl();
        public Sbilldetailform(int billid)
        {
            InitializeComponent();
            this.billid = billid;
        }

        private void Sbilldetailform_Load(object sender, EventArgs e)
        {
            LoadDetails();
            LoadHeaderInfo();
        }
        private void LoadDetails()
        {
            var details = sbillDetailsDl.getdetails (billid);
            dataGridView2.DataSource = details;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["bill_detail_id"].Visible = false;
            dataGridView2.Columns["Supplierbill"].Visible = false;

        }
        private void LoadHeaderInfo()
        {
            var billList = billDl.getbills(billid);
            if (billList != null && billList.Count > 0)
            {
                var bill = billList.First();
                lblname.Text = " " + bill.supplier_name;

                lbltotal.Text = " Rs. " + bill.total_price.ToString("N2");
                lblpaid. Text = " Rs. " + bill.paid_price.ToString("N2");
              lblpending .Text = " Rs. " + bill.pending.ToString("N2");
            }
        }
    }
}
