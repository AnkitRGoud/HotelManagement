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
    public partial class frmOrderEntry : Form
    {
        public frmOrderEntry()
        {
            InitializeComponent();
        }

        int Oid, Fid;
        

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        public void gridload()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from FoodChargeDynamic where Status != 'delivered'"  , con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkInt(sender,e,txtQuantity);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                lblOrderId.Text = row.Cells[0].Value.ToString();
                cmbRoomNo.Text = row.Cells[1].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();
                cmbDishName.Text = row.Cells[4].Value.ToString();
                cnbStatus1.Text = row.Cells[5].Value.ToString();
            }

            btnUpdate.Enabled = true;
        }

        private void frmOrderEntry_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select RoomNo from RoomMaster where status = 'Booked'" , con());

            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbRoomNo.Items.Add(drow[0].ToString());

            }

            da1 = new SqlDataAdapter("Select DishName from FoodItemMaster",con());
            dt.Reset();
            da1.Fill(dt);

            

            foreach (DataRow drow in dt.Rows)
            {
                cmbDishName.Items.Add(drow[0].ToString());

            }

            gridload();

            lblOrderId.Text = string.Empty;
            cnbStatus.Text = string.Empty;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Please select Quantity");
                txtQuantity.Focus();
                return;
            }
            
            
            SqlCommand Comm1 = new SqlCommand("select max (OrderId) from FoodChargeDynamic ", con());

            if (Convert.ToString(Comm1.ExecuteScalar()) == string.Empty)
            {
                Oid = 0;
            }
            else
            {
                Oid = Convert.ToInt32(Comm1.ExecuteScalar());
            }

            SqlDataAdapter da  = new SqlDataAdapter("select FoodId, Charge from FoodItemMaster where DishName = '" + cmbDishName.Text + "'", con());
            DataTable dt = new DataTable();
            da.Fill(dt);

            Fid = Convert.ToInt32(dt.Rows[0][0]);

            int charge = Convert.ToInt32(dt.Rows[0][1]) * Convert.ToInt32(txtQuantity.Text);


            SqlDataAdapter da2 = new SqlDataAdapter("Select * from FoodChargeDynamic", con());
            DataSet ds = new DataSet();
            DataRow drw;

            da2.Fill(ds);

            drw = ds.Tables[0].NewRow();

            drw["OrderId"] = Oid + 1;
            drw["RoomNo"] = this.cmbRoomNo.Text ;
            drw["FoodId"] = Fid;
            drw["DishName"] = this.cmbDishName.Text;
            drw["Quantity"] = this.txtQuantity.Text;
            drw["Status"] = "working";
            drw["Charge"] = charge;
            

            ds.Tables[0].Rows.Add(drw);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
            da2.Update(ds);
            da2.Dispose();
            ds.Dispose();


            Global.OrderId = Convert.ToString(Oid + 1);

            MessageBox.Show("Added Successfully");

            gridload();

            foreach (Control x in this.Controls)
            {
                if (x is ComboBox)
                {
                    x.Text = string.Empty;
                }
            }

            txtQuantity.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Please select Quantity");
                txtQuantity.Focus();
                return;
            }


            SqlCommand cmd = new SqlCommand("update FoodChargeDynamic SET DishName = '" + cmbDishName.Text + "', Quantity = " + txtQuantity.Text + ", Status = '" + cnbStatus1.Text + "'  where OrderId = " + lblOrderId.Text + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully !!");

                gridload();


                foreach (Control x in this.Controls)
                {
                    if (x is ComboBox)
                    {
                        x.Text = string.Empty;
                    }
                }

                txtQuantity.Text = string.Empty;

                btnUpdate.Enabled = false;

                
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
