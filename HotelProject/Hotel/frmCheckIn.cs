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
    public partial class frmCheckIn : Form
    {
        int Cid; 
        
        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        string date =  Convert.ToString(DateTime.Now.Day +"/"+DateTime.Now.Month +"/"+ DateTime.Now.Year);

        public frmCheckIn()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from RoomChargeDynamic", con());
            DataSet ds = new DataSet();
            DataRow drw;

            SqlCommand cmd = new SqlCommand("select CustomerId from CustomerDetail where Name= '"+ cmbName.Text +"'",con());
            Cid = Convert.ToInt32(cmd.ExecuteScalar());


            da2.Fill(ds);

            drw = ds.Tables[0].NewRow();

            drw["CustomerId"] = Cid;
            drw["RoomNo"] = Convert.ToInt32(cmbRoomNo.Text);
            drw["TimeIn"] = DateTime.Now ;
            drw["DateIn"] = DateTime.Now;
            drw["UserId"] = Global.UserId;
           


            ds.Tables[0].Rows.Add(drw);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
            da2.Update(ds);
            da2.Dispose();
            ds.Dispose();

            cmd = new SqlCommand("Update RoomMaster set Status = 'Booked' where RoomNo = " + cmbRoomNo.Text + "", con());
            cmd.ExecuteNonQuery();

            MessageBox.Show("check in successfull");
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da1 = new SqlDataAdapter("Select RoomType from RoomTypeMaster", con());

            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbRoomType.Items.Add(drow[0].ToString());

            }

            dt.Reset();
            da1.Dispose();
            da1 = new SqlDataAdapter("Select Name from CustomerDetail", con());
           

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbName.Items.Add(drow[0].ToString());

            }
            
          

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbRoomNo.Items.Clear();
            cmbRoomNo.Text = string.Empty;

            SqlDataAdapter da1 = new SqlDataAdapter("Select RoomNo from RoomMaster where Status = '" + "available" + "' and RoomType='" + cmbRoomType.Text + "'", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                cmbRoomNo.Items.Add(drow[0].ToString());
                
            }


            SqlCommand cmd = new SqlCommand("select Charge from RoomTypeMaster where RoomType='" + cmbRoomType.Text + "'", con());
            textRate.Text = Convert.ToString( cmd.ExecuteScalar());
        }

        

       
       
       
    }
}
