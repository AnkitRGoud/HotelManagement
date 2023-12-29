using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel
{
    public partial class frmPrintBill : Form
    {
        public frmPrintBill()
        {
            InitializeComponent();
        }

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select CustomerId from billing where Name ='" + cmbCustomerName.Text + "'", con());
            Global.CustomerId = Convert.ToString(cmd.ExecuteScalar());
          
            
            frmBill bl = new frmBill();
            bl.ShowDialog();
        }

        private void frmPrintBill_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select Name from Billing", con());

            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbCustomerName.Items.Add(drow[0].ToString());

            }

            
        }
    }
}
