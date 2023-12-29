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
using CrystalDecisions.CrystalReports.Engine;

namespace Hotel
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
                string myQuery = string.Format("select * from Billing where CustomerId =" +Convert.ToString(Global.CustomerId)+"" );
                SqlDataAdapter da = new SqlDataAdapter(myQuery, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds);

                ReportDocument rd = new ReportDocument();
                rd.Load(@"D:\Hotel\HotelProject\Hotel\Reports\Bill.rpt");
                rd.SetDataSource(ds.Tables[0]);
                rd.SetDatabaseLogon("sa", "aa");
                crystalReportViewer1.ReportSource = rd;

                crystalReportViewer1.DisplayToolbar = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
