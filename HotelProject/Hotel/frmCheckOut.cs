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
    public partial class frmCheckOut : Form
    {
        DateTime d, t;
        int billNo;
        public frmCheckOut()
        {
            InitializeComponent();
        }

        public void clr()
        {
            foreach (Control t in panel2.Controls)
            {
                if (t is TextBox)
                {
                    t.Text = string.Empty;
                }
            }

            foreach (Control t in panel3.Controls)
            {
                if (t is TextBox)
                {
                    t.Text = string.Empty;
                }
            }
        }

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

     

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select RoomNo from RoomMaster where status = 'Booked'", con());

            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbRoomNo.Items.Add(drow[0].ToString());

            }



        }

        private void cmbRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select RoomType from RoomMaster where RoomNo ="+cmbRoomNo.Text+"",con() );
            txtRoomType.Text = Convert.ToString(cmd.ExecuteScalar());

            cmd = new SqlCommand("select Name from CustomerDetail where CustomerId = (Select CustomerId from RoomChargeDynamic where RoomNo = " + cmbRoomNo.Text + " )", con());
            txtGuestName.Text = Convert.ToString(cmd.ExecuteScalar());


            //Date Calculation ..........................................................................................
            SqlDataAdapter da = new SqlDataAdapter("Select TimeIn, DateIn from RoomChargeDynamic where RoomNo = " + cmbRoomNo.Text + "",con());
            DataTable dt = new DataTable();

            da.Fill(dt);

            d =Convert.ToDateTime(dt.Rows[0][1]);
            t = Convert.ToDateTime(dt.Rows[0][0]);
            
            txtTimeIn.Text = Convert.ToString(t.ToString("HH:mm"));
            txtDateIn.Text = Convert.ToString(d.ToString("dd/MM/yyyy"));

            txtDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTimeOut.Text = DateTime.Now.ToString("HH:mm");

            TimeSpan difference = DateTime.Now - d;

            txtNoofDays.Text = Convert.ToString(difference.Days);

            if (txtNoofDays.Text == "0")
            {
                txtNoofDays.Text = "1";
            }

            

            // Food Charge Calculation ...............................................................................
            cmd = new SqlCommand("select sum(charge) from FoodChargeDynamic where RoomNo ="+cmbRoomNo.Text+"",con());
            txtFoodCharge.Text =Convert.ToString(cmd.ExecuteScalar());

            if (txtFoodCharge.Text == string.Empty)
            {
                txtFoodCharge.Text = "0";
            }

            // Food Charge Calculation ...............................................................................
            cmd = new SqlCommand("select Charge from RoomTypeMaster where RoomType ='" + txtRoomType.Text + "'", con());
            txtRate.Text =  Convert.ToString(cmd.ExecuteScalar());
            txtRoomCharge.Text = Convert.ToString(Convert.ToInt32(txtRate.Text) * Convert.ToInt32(txtNoofDays.Text));
            txtTotal.Text = Convert.ToString(Convert.ToInt32(txtRoomCharge.Text) + Convert.ToInt32(txtFoodCharge.Text));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomNo.Text == string.Empty)
                {
                    MessageBox.Show("Please select Room No.");
                    return;
                }

                SqlDataAdapter da = new SqlDataAdapter("select FoodId, Quantity from FoodChargeDynamic where RoomNo =" + cmbRoomNo.Text + "", con());
                DataTable dt = new DataTable();

                da.Fill(dt);

                SqlCommand cmd = new SqlCommand("select CustomerId from RoomChargeDynamic where RoomNo =" + cmbRoomNo.Text + "", con());
                int Cid = Convert.ToInt32(cmd.ExecuteScalar());

                for (int i = 0; i <= (dt.Rows.Count) - 1; i++)
                {
                    cmd = new SqlCommand("INSERT INTO [ChargeStatic]([CustomerName],[CustomerId],[RoomNo],[Stay],[FoodId],[Quantity],[TimeIn],[TimeOut],[DateIn],[DateOut])VALUES('" + txtGuestName.Text + "'," + Cid + "," + cmbRoomNo.Text + "," + txtNoofDays.Text + "," + dt.Rows[i][0] + "," + dt.Rows[i][1] + ",'" + t + "','" + DateTime.Now + "','" + d + "','" + DateTime.Now + "')", con());
                    cmd.ExecuteNonQuery();
                }

                cmd = new SqlCommand("Update RoomMaster set Status = 'Available' where RoomNo = " + cmbRoomNo.Text + "", con());
                cmd.ExecuteNonQuery();

                //Bill Code ------------------------------------------------------------------------------------
                da = new SqlDataAdapter("select address, ContactNo, city from CustomerDetail where CustomerId =" +Cid+ "" ,con());
                DataTable dt1 = new DataTable();

                da.Fill(dt1);
                
                cmd = new SqlCommand("Select max(BillNo) from Billing", con());
                //if (Convert.ToString(cmd.ExecuteScalar()) == string.Empty)
                //{
                //    billNo = 0;
                //}

                billNo=Convert.ToInt32(cmd.ExecuteScalar());

                SqlDataAdapter da2 = new SqlDataAdapter("Select * from Billing", con());
                DataSet ds = new DataSet();
                DataRow drw;

                da2.Fill(ds);

                drw = ds.Tables[0].NewRow();

                drw["CustomerId"] = Cid;
                drw["Name"] = this.txtGuestName.Text ;
                drw["Address"] = dt1.Rows[0][0];
                drw["TotalFoodCharge"] = this.txtFoodCharge.Text;
                drw["TotalRoomCharge"] = this.txtRoomCharge.Text;
                drw["UserId"] = Global.UserId;
                drw["ContactNo"] = dt1.Rows[0][1];
                drw["DateIn"] = d;
                drw["DateOut"] = DateTime.Now;
                drw["NoOfDays"] = this.txtNoofDays.Text;
                drw["GrandTotal"] = this.txtTotal.Text;
                drw["Rate"] = this.txtRate.Text;
                drw["RoomNo"] = this.cmbRoomNo.Text;
                drw["Roomtype"] = this.txtRoomType.Text;
                drw["City"] = dt1.Rows[0][2];
                drw["BillNo"] = billNo + 1 ;
                drw["BillDate"] = DateTime.Now;


                ds.Tables[0].Rows.Add(drw);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
                da2.Update(ds);
                da2.Dispose();
                ds.Dispose();
                
                //--------------------------------------------------------------------------------------------------

                cmd = new SqlCommand("delete from FoodChargeDynamic where RoomNo =" + cmbRoomNo.Text + "", con());
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("delete from RoomChargeDynamic where RoomNo=" + cmbRoomNo.Text + "", con());
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Check Out done Successfully !!");

                clr();

                cmbRoomNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            frmBill bl = new frmBill();
            bl.ShowDialog();
        }

       

       
    }
}
