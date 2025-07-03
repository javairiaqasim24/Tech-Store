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

namespace TechStore.UI
{
    public partial class BatchDetailsform : Form
    {
        public BatchDetailsform()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<AddbatchDetailsform>();
            f.ShowDialog(this);
        }
    }
}
