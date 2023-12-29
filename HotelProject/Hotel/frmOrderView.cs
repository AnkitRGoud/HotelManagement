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
    public partial class frmOrderView : Form
    {
        public frmOrderView()
        {
            InitializeComponent();
        }

        int check;

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        private void frmOrderView_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from FoodChargeDynamic where Status != 'delivered'", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();

            check = Convert.ToInt32(Global.OrderId);
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            SqlDataAdapter da1 = new SqlDataAdapter("Select * from FoodChargeDynamic where Status != 'delivered'", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();

            if (check != Convert.ToInt32(Global.OrderId))
            {
                System.Media.SystemSounds.Hand.Play();
                check = Convert.ToInt32(Global.OrderId);
            }
        }

        
    }
}
