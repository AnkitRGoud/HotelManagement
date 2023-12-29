using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class frmCustomerDetails : Form
    {
        public frmCustomerDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Global.fromDate = Convert.ToDateTime(dateTimePicker1.Text);
            Global.toDate = Convert.ToDateTime(dateTimePicker2.Text);

            frmCustomerReport cr = new frmCustomerReport();
            cr.ShowDialog();
        }
    }
}
