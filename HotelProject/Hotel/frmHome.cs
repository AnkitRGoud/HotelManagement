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
    public partial class frmHome : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update UserLogin SET TimeOut = '" + DateTime.Now + "', Status='closed' where UserId = '" + Global.UserId + "' and Status ='active'", conn);
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Application.Exit();
            }

            
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewUser f = new frmNewUser();
            f.ShowDialog();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblUserId.Text = Global.UserId;
            string UserType = Global.UserType;

            adminToolStripMenuItem.Enabled = false;
            receptionToolStripMenuItem.Enabled = false;
            ordersToolStripMenuItem.Enabled = false;
            reportsToolStripMenuItem.Enabled = false;
            masterToolStripMenuItem.Enabled = false;

            switch (UserType)
            {
                case ("Admin"):
                    {
                        adminToolStripMenuItem.Enabled = true;
                        receptionToolStripMenuItem.Enabled = true;
                        ordersToolStripMenuItem.Enabled = true;
                        reportsToolStripMenuItem.Enabled = true;
                        masterToolStripMenuItem.Enabled = true;
                        break;
                    }

                case ("Reception"):
                    {
                        receptionToolStripMenuItem.Enabled = true;
                        break;
                    }

                case ("Attendent"):
                    {
                        ordersToolStripMenuItem.Enabled = true;
                        break;
                    }
                case ("Service"):
                    {
                        ordersToolStripMenuItem.Enabled = true;
                        break;
                    }


            }





        }

        private void customerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerEntry c = new frmCustomerEntry();
            c.ShowDialog();
        }

        private void checkInCheckOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheckIn ck = new frmCheckIn();
            ck.ShowDialog();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheckOut chk = new frmCheckOut();
            chk.ShowDialog();
        }

        private void userLoginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserLoginDetails u = new frmUserLoginDetails();
            u.ShowDialog();
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword up = new frmUpdatePassword();
            up.ShowDialog();
        }

        private void roomTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomTypeMaster rm = new frmRoomTypeMaster();
            rm.ShowDialog();
        }

        private void roomMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomMaster rm = new frmRoomMaster();
            rm.ShowDialog();
        }

        private void foodItemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFoodItemMaster fim = new frmFoodItemMaster();
            fim.ShowDialog();
        }

        private void roomSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomStatus rs = new frmRoomStatus();
            rs.ShowDialog();
        }

        private void trialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTry t = new frmTry();
            t.ShowDialog();
        }

        private void orderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderEntry oe = new frmOrderEntry();
            oe.ShowDialog();
        }

        private void orderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderStatus os = new frmOrderStatus();
            os.ShowDialog();
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderView ov = new frmOrderView();
            ov.ShowDialog();
        }

        private void billingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPrintBill pb = new frmPrintBill();
            pb.ShowDialog();
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerDetails rp = new frmCustomerDetails();
            rp.ShowDialog();

        }

        private void collectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCollection co = new frmCollection();
            co.ShowDialog();
        }

        

        
    }
}
