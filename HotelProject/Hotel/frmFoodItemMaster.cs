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
    public partial class frmFoodItemMaster : Form
    {
        int fid;
        string dishName;
        public frmFoodItemMaster()
        {
            InitializeComponent();
        }

        public SqlConnection con()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            conn.Open();
            return conn;

        }

        public void gridload()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from FoodItemMaster", con());
            DataTable dt = new DataTable();

            da1.Fill(dt);

            dataGridView1.DataSource = dt;

            da1.Dispose();
            dt.Dispose();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chk c1 = new Chk();
            c1.checkInt(sender, e, txtCharge);
        }

        private void frmFoodItemMaster_Load(object sender, EventArgs e)
        {
            gridload();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                fid = Convert.ToInt32(row.Cells[0].Value.ToString());
                cmbDishType.Text = row.Cells[1].Value.ToString();
                txtDishName.Text = row.Cells[2].Value.ToString();
                txtCharge.Text = row.Cells[3].Value.ToString();
                dishName = row.Cells[2].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == string.Empty)
            {
                MessageBox.Show("Please fill Dish Name");
                txtDishName.Focus();
                return;
            }

            if (cmbDishType.Text == string.Empty)
            {
                MessageBox.Show("Please Select Dish Type ");
                cmbDishType.Focus();
                return;
            }

            if (txtCharge.Text == string.Empty)
            {
                MessageBox.Show("Please fill Dish Charge ");
                txtCharge.Focus();
                return;
            }

            SqlDataAdapter da = new SqlDataAdapter("select DishName from FoodItemMaster where DishName ='" + txtDishName.Text + "'", con());
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Dish Name Already Taken ");
                txtDishName.Focus();
                dt.Clear();
                return;
            }

            SqlCommand Comm1 = new SqlCommand("select max (FoodId) from FoodItemMaster ", con());
            fid = Convert.ToInt32(Comm1.ExecuteScalar());

            
            int c = fid + 1;
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from FoodItemMaster", con());
            DataSet ds = new DataSet();
            DataRow drw;

            da2.Fill(ds);

            drw = ds.Tables[0].NewRow();

            drw["DishName"] = this.txtDishName.Text;
            drw["DishType"] = this.cmbDishType.Text;
            drw["Charge"] = this.txtCharge.Text;
            drw["UpdateDate"] = DateTime.Now;
            drw["FoodId"] = c;
            
            

            ds.Tables[0].Rows.Add(drw);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da2);
            da2.Update(ds);
            da2.Dispose();
            ds.Dispose();

            MessageBox.Show("Added Successfully");

            txtDishName.Text = string.Empty;
            cmbDishType.Text = string.Empty;
            txtCharge.Text = string.Empty;

            gridload();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == string.Empty)
            {
                MessageBox.Show("Please fill Dish Name");
                txtDishName.Focus();
                return;
            }

            if (cmbDishType.Text == string.Empty)
            {
                MessageBox.Show("Please Select Dish Type ");
                cmbDishType.Focus();
                return;
            }

            if (txtCharge.Text == string.Empty)
            {
                MessageBox.Show("Please fill Dish Charge ");
                txtCharge.Focus();
                return;
            }
            
            
            if (txtDishName.Text != dishName)
            {
                SqlDataAdapter da = new SqlDataAdapter("select DishName from FoodItemMaster where DishName ='" + txtDishName.Text + "'", con());
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Dish Name Already Taken ");
                    txtDishName.Focus();
                    dt.Clear();
                    return;
                }
            }


            SqlCommand cmd = new SqlCommand("update FoodItemMaster SET DishName = '" + txtDishName.Text + "' , DishType = '" + cmbDishType.Text + "', UpdateDate = '" + DateTime.Now + "' , Charge = " + txtCharge.Text + "  where FoodId = " + fid + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully !!");

                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }


            txtDishName.Text = string.Empty;
            cmbDishType.Text = string.Empty;
            txtCharge.Text = string.Empty;

            gridload();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from FoodItemMaster where FoodId = " + fid + "", con());
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully !!");

                gridload();

                //cmbUserId.SelectedIndex = 0;
                //txtNewPass.Text = string.Empty;
                //lblOldPass.Text = string.Empty;
            }
        }



    }
}
