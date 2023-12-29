using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Hotel
{
    public partial class frmTry : Form
    {
        public frmTry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofdImage.ShowDialog();
        }

        private void ofdImage_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string fileName = ofdImage.SafeFileName;
                string sourcePath = @ofdImage.FileName;
                
                string path = System.Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + "Images" + "\\Customer";

                //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(path2, "sdsd" + Path.GetExtension(ofdImage.FileName));

                System.IO.File.Copy(sourcePath, destFile, true);
                MessageBox.Show("success");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
