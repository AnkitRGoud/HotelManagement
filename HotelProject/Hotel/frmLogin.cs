using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel
{
    public partial class frmLogin : Form
    {
      
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
        
        public frmLogin()
        {
            InitializeComponent();
        }

       

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {


                string myQuery = string.Format("select UserId, Password, UserType from UserMaster where UserId = '{0}' and Password = '{1}'", txtLogin.Text, txtPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(myQuery, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    Global.UserId = txtLogin.Text;
                    Global.UserType =Convert.ToString(ds.Tables[0].Rows[0][2]);

                    SqlCommand cmd = new SqlCommand("Insert into UserLogin (UserId,TimeIn,Status) values ('" + txtLogin.Text + "','" + DateTime.Now +  "', 'active')", conn);
                    {
                        cmd.ExecuteNonQuery();
                    }
                         
                    da.Dispose();
                    ds.Dispose();
                    this.Visible = false;
                    frmHome h = new frmHome();
                    h.Show();

                }
                else
                {
                    MessageBox.Show("Invalid UserId or Password !!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != conn && conn.State == ConnectionState.Open)
                    conn.Close();
                
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hiii");
        }
    }
}
