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
    public partial class frmRoomStatus : Form
    {
        int roomCount;
        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        public frmRoomStatus()
        {
            InitializeComponent();
        }

        private void frmRoomStatus_Load(object sender, EventArgs e)
        {
            int xloc = 0;
            int yloc = 0;
            SqlCommand cm = new SqlCommand("Select count(RoomNo) from RoomMaster", con());
            roomCount = Convert.ToInt32(cm.ExecuteScalar());

            SqlDataAdapter da = new SqlDataAdapter("Select RoomNo, status from RoomMaster order by RoomNo", con());
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < roomCount; i++)
            {
                Button button = new Button();
                
                // Button customization here...
                button.Name = "Button" + i.ToString();
                
                button.Text =Convert.ToString(dt.Rows[i][0]) ;

                if (Convert.ToString(dt.Rows[i][1]) == "Available")
                {
                    button.BackColor = Color.Green;
                }

                else
                {
                    button.BackColor = Color.Red;
                }


                if (xloc > 500)
                {

                    yloc += 100;
                    xloc = 0;
                }
                  button.Location = new Point(xloc += 100, yloc);
                
                panel1.Controls.Add(button);
                
            }

            da = new SqlDataAdapter("SELECT CustomerDetail.CustomerId, CustomerDetail.Name, CustomerDetail.ContactNo,CustomerDetail.Address,RoomChargeDynamic.RoomNo FROM CustomerDetail INNER JOIN RoomChargeDynamic on CustomerDetail.CustomerId=RoomChargeDynamic.CustomerId  ", con());
            DataTable dt1 = new DataTable();

            da.Fill(dt1);

            dataGridView1.DataSource = dt1;
            
           

        }
    }
}
