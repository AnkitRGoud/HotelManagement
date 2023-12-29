using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Hotel
{
    public partial class frmCustomerEntry : Form
    {
        string rad;
        int Cid;
        public frmCustomerEntry()
        {
            InitializeComponent();
        }

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        public bool Email(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(this.txtEmail.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkChar(sender, e, txtFirstName);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkChar(sender, e, txtLastName);
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkInt(sender, e, txtContactNo);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (x.Text == "") //((TextBox)x).Text = string.Empty;
                    {
                        MessageBox.Show("Please enter all values");
                        x.Focus();
                        return;
                    }
                }

            }

            foreach (Control rb in groupBox1.Controls)
            {
                if (rb is RadioButton)
                {
                    RadioButton r = rb as RadioButton;
                    if (r.Checked == true)
                    {
                        rad = r.Text;
                        break;
                    }
                }
            }

            if (txtEmail.Text != "")
            {
                bool b1 = Email(txtEmail.Text);

                if (b1 != true)
                {
                    MessageBox.Show("Invalid Email Address");
                    txtEmail.Focus();
                    return;
                }
            }

            if (rad == string.Empty)
            {
                MessageBox.Show("Please select options for ID");
                groupBox1.Focus();
                return;
            }

            SqlCommand Comm1 = new SqlCommand("select max (CustomerId) from CustomerDetail ", con());
            

            if (Convert.ToString(Comm1.ExecuteScalar()) == string.Empty)
            {
                Cid = 0;
            }
            else
            {
                Cid = Convert.ToInt32(Comm1.ExecuteScalar());
            }

            SqlDataAdapter da2 = new SqlDataAdapter("Select * from CustomerDetail", con());
            DataSet ds = new DataSet();
            DataRow drw;

            da2.Fill(ds);

            drw = ds.Tables[0].NewRow();

            drw["CustomerId"] = Cid + 1;
            drw["Name"] = this.txtFirstName.Text + " " + txtLastName.Text;
            drw["Address"] = this.txtAddress.Text;
            drw["ContactNo"] = this.txtContactNo.Text;
            drw["EmailId"] = this.txtEmail.Text;
            drw["City"] = this.txtCity.Text;
            drw["IdType"] = rad ;
            drw["IdNo"] = Cid + 1;
            drw["Gender"] = cmbGender.Text;
            drw["UpdateDate"] = DateTime.Now;

                                 

            ds.Tables[0].Rows.Add(drw);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
            da2.Update(ds);
            da2.Dispose();
            ds.Dispose();


            Global.CustomerId = Convert.ToString(Cid + 1);
            
                MessageBox.Show("Added Successfully");

            /* File copy Code */
             
            //-------------------------------------------------
          
            try
            {
                string fileName = ofdImage.SafeFileName;
                string sourcePath = @ofdImage.FileName;

                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Images" + "\\Customer";

                //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(path2, (Cid+1) + Path.GetExtension(ofdImage.FileName));

                System.IO.File.Copy(sourcePath, destFile, true);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //--------------------------------------------------

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = string.Empty;
                }

            }
           

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            ofdImage.ShowDialog();
        }

        private void ofdImage_FileOk(object sender, CancelEventArgs e)
        {
            txtIDNumber.Text = ofdImage.FileName;          
        }

        private void frmCustomerEntry_Load(object sender, EventArgs e)
        {
            cmbGender.Text = "Male";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


       

    }
}
