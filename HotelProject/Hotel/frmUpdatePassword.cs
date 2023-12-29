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
    public partial class frmUpdatePassword : Form
    {
        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;
           
        }
        
        public frmUpdatePassword()
        {
            InitializeComponent();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select UserId from UserMaster", con());

            DataTable dt = new DataTable();

            da1.Fill(dt);
                                    
            foreach (DataRow drow in dt.Rows)
            {
                cmbUserId.Items.Add(drow[0].ToString());
                
            } 
            
        }

        private void cmbUserId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select Password,UserType from UserMaster where UserId = '" + cmbUserId.Text + "'", con());
            DataTable dt = new DataTable();
            da1.Fill(dt);
            //DataRow drow = new DataRow();

            lblOldPass.Text = Convert.ToString(dt.Rows[0][0]);
            cmbUserType.Text = Convert.ToString(dt.Rows[0][1]);       
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == string.Empty)
            {
                txtNewPass.Text = lblOldPass.Text;
            }
            SqlCommand cmd = new SqlCommand("update UserMaster SET Password = '" + txtNewPass.Text + "', UserType='"+cmbUserType.Text+"' where UserId = '" + cmbUserId.Text + "'", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Updated Successfully !!");

                cmbUserId.SelectedIndex = 0;
                txtNewPass.Text = string.Empty;
                lblOldPass.Text = string.Empty;
                cmbUserType.Text = string.Empty;

                SqlConnection c = con();
                c.Close();
                
            }
        }
    }
}
