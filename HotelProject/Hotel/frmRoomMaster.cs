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
    public partial class frmRoomMaster : Form
    {
        int a,b,c,val;

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }
        public frmRoomMaster()
        {
            InitializeComponent();
        }

        private void frmRoomMaster_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select RoomType from RoomTypeMaster", con());

            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbRoomType.Items.Add(drow[0].ToString());

            }

            gridload();
        }

        public void gridload()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from RoomMaster", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           if (txtRoomNo.Text == string.Empty)
           {
               MessageBox.Show("Please fill Romm No.");
               txtRoomNo.Focus();
               return;
           }

           if (cmbRoomType.Text == string.Empty)
           {
               MessageBox.Show("Please Select Romm Type ");
               cmbRoomType.Focus();
               return;
           }

           SqlDataAdapter da = new SqlDataAdapter("select RoomNo from RoomMaster where RoomNo =" + txtRoomNo.Text + "", con());
           DataTable dt = new DataTable();

           da.Fill(dt);

           if (dt.Rows.Count >= 1)
           {
               MessageBox.Show("Room No. Already Taken ");
               txtRoomNo.Focus();
               dt.Clear();
               return;
           }


           SqlCommand Comm1 = new SqlCommand("select max (RoomId) from RoomMaster ", con());
           a = Convert.ToInt32(Comm1.ExecuteScalar());

           SqlCommand Comm2 = new SqlCommand("select RoomTypeId from RoomTypeMaster where RoomType = '" + cmbRoomType.Text + "'", con());
           b = Convert.ToInt32(Comm2.ExecuteScalar());


           int c = a + 1;
           SqlDataAdapter da2 = new SqlDataAdapter("Select * from RoomMaster", con());
           DataSet ds = new DataSet();
           DataRow drw;

           da2.Fill(ds);

           drw = ds.Tables[0].NewRow();

           drw["RoomNo"] = this.txtRoomNo.Text;
           drw["RoomType"] = this.cmbRoomType.Text;
           drw["UpdateDate"] = DateTime.Now;
           drw["RoomId"] = c;
           drw["RoomTypeId"] = b;
           drw["Status"] = "Available";


           ds.Tables[0].Rows.Add(drw);
           SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
           da2.Update(ds);
           da2.Dispose();
           ds.Dispose();

           MessageBox.Show("Added Successfully");

           txtRoomNo.Text = string.Empty;
           cmbRoomType.Text = string.Empty;

           gridload();

           


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                txtRoomNo.Text = row.Cells[0].Value.ToString();
                cmbRoomType.Text = row.Cells[1].Value.ToString();
                c = Convert.ToInt32(row.Cells[3].Value.ToString());
                val = Convert.ToInt32(row.Cells[0].Value.ToString()); 
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text == string.Empty)
            {
                MessageBox.Show("Please fill Romm No.");
                txtRoomNo.Focus();
                return;
            }

            if (cmbRoomType.Text == string.Empty)
            {
                MessageBox.Show("Please Select Romm Type ");
                cmbRoomType.Focus();
                return;
            }

            if (Convert.ToInt32(txtRoomNo.Text) != val)
            {
                SqlDataAdapter da = new SqlDataAdapter("select RoomNo from RoomMaster where RoomNo =" + txtRoomNo.Text + "", con());
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Room No. Already Taken ");
                    txtRoomNo.Focus();
                    dt.Clear();
                    return;
                }
            }


            SqlCommand Comm2 = new SqlCommand("select RoomTypeId from RoomTypeMaster where RoomType = '" + cmbRoomType.Text + "'", con());
            b = Convert.ToInt32(Comm2.ExecuteScalar());

            SqlCommand cmd = new SqlCommand("update RoomMaster SET RoomNo = " + txtRoomNo.Text + " , RoomType = '" + cmbRoomType.Text + "', UpdateDate = '" + DateTime.Now + "' , RoomTypeId = " + b + "  where RoomId = " + c + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully !!");

                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }
            

            txtRoomNo.Text = string.Empty;
            cmbRoomType.Text = string.Empty;

            gridload();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from RoomMaster where RoomId = " + c + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully !!");

                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }
        }

        private void txtRoomNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkInt(sender,e,txtRoomNo);
        }
    }
}
