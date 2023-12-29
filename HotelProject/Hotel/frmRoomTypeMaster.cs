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
    public partial class frmRoomTypeMaster : Form
    {
        int a;
        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;
        }

       public void gridload()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from RoomTypeMaster", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            GridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();
        }

        public frmRoomTypeMaster()
        {
            InitializeComponent();
        }

        private void frmRoomTypeMaster_Load(object sender, EventArgs e)
        {
            gridload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            


            SqlCommand Comm1 = new SqlCommand("select max (RoomTypeId) from RoomTypeMaster ", con());
            a = Convert.ToInt32(Comm1.ExecuteScalar());


            SqlDataAdapter da = new SqlDataAdapter("Select * from RoomTypeMaster", con());
            DataSet ds = new DataSet();
            DataRow drw;

            da.Fill(ds);

            drw = ds.Tables[0].NewRow();

            drw["RoomType"] = this.txtRoomType.Text;
            drw["Charge"] = this.txtCharge.Text;
            drw["UpdateDate"] = DateTime.Now;
            drw["RoomTypeId"] = a + 1;


            ds.Tables[0].Rows.Add(drw);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds);
            da.Dispose();
            ds.Dispose();

            MessageBox.Show("Added Successfully");

            txtCharge.Text = string.Empty;
            txtRoomType.Text = string.Empty;

            gridload();
        }

        private void GridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridView1.SelectedRows)
            {
                txtRoomType.Text = row.Cells[0].Value.ToString();
                txtCharge.Text = row.Cells[1].Value.ToString();
                a = Convert.ToInt32(row.Cells[3].Value.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("update RoomTypeMaster SET RoomType = '" + txtRoomType.Text + "' , Charge = '" + txtCharge.Text + "', UpdateDate = '" + DateTime.Now + "'  where RoomTypeId = " + a + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully !!");

                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }
        }

        private void txtRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
            {
                e.Handled = true;
                txtRoomType.Focus();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from RoomTypeMaster where RoomTypeId = " + a + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully !!");
                txtCharge.Text = string.Empty;
                txtRoomType.Text = string.Empty;
                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }
        }

        
    }
}
