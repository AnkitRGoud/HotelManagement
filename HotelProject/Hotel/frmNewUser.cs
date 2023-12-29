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
using System.IO;

namespace Hotel
{
    public partial class frmNewUser : Form
    {
        
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                   if(x.Text=="") //((TextBox)x).Text = string.Empty;
                    {
                        MessageBox.Show("Please enter all values");
                        x.Focus();
                        break;
                    }
                }

            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select picture");
                openFileDialog1.ShowDialog();
            }

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
                conn.Open();


                SqlDataAdapter da1 = new SqlDataAdapter("Select UserId from UserMaster", conn);
                DataTable dt = new DataTable();

                da1.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["UserId"].ToString() == txtUserId.Text)
                    {
                        MessageBox.Show("User Name already taken");
                        txtUserId.Focus();
                        break;

                    }

                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from UserMaster", conn);
                        DataSet ds = new DataSet();
                        DataRow drw;

                        da.Fill(ds);

                        drw = ds.Tables[0].NewRow();

                        drw["UserId"] = this.txtUserId.Text;
                        drw["Name"] = this.txtName.Text;
                        drw["Address"] = this.txtAddress.Text;
                        drw["ContactNo"] = this.txtContactNo.Text;
                        drw["EmaiId"] = this.txtEmail.Text;
                        drw["DocId"] = this.txtUserId.Text;
                        drw["Password"] = this.txtPassword.Text;
                        drw["DocIdType"] = this.comboBox1.Text;
                        drw["UserType"] = this.cmbUserType.Text;


                        ds.Tables[0].Rows.Add(drw);
                        SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                        da.Update(ds);
                        da.Dispose();
                        ds.Dispose();
                        conn.Close();


                        try
                        {
                            string fileName = openFileDialog1.SafeFileName;
                            string sourcePath = @openFileDialog1.FileName;

                            string path = System.Environment.CurrentDirectory;
                            string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Images" + "\\User";

                            //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                            string destFile = System.IO.Path.Combine(path2, txtUserId.Text + Path.GetExtension(openFileDialog1.FileName));

                            System.IO.File.Copy(sourcePath, destFile, true);

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        MessageBox.Show("User Registration Successful");
                        break;
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c = new Chk();
            c.checkChar(sender, e, txtName);
        }

        

        
    }
}
