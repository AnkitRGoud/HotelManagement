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
    public partial class frmOrderStatus : Form
    {
        public frmOrderStatus()
        {
            InitializeComponent();
        }

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        public void gridload()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from FoodChargeDynamic", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                lblOrderId.Text = row.Cells[0].Value.ToString();
                lblRoomNo.Text = row.Cells[1].Value.ToString();
                lblQuantity.Text = row.Cells[3].Value.ToString();
                lblDishName.Text = row.Cells[4].Value.ToString();
                cmbStatus.Text = row.Cells[5].Value.ToString();
            }

            btnUpdate.Enabled = true;
            cmbStatus.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update FoodChargeDynamic SET Status = '" + cmbStatus.Text + "' where OrderId = " + lblOrderId.Text + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully !!");

                gridload();
                btnUpdate.Enabled = false;
                cmbStatus.Enabled = false;
            }
        }

        private void frmOrderStatus_Load(object sender, EventArgs e)
        {
            gridload();
        }
    }
}
