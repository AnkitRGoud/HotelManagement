namespace Hotel
{
    partial class frmCheckIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRoomNo = new System.Windows.Forms.Label();
            this.textRate = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblRoomtype = new System.Windows.Forms.Label();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.cmbRoomNo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 59);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 28;
            this.lblName.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.AutoSize = true;
            this.lblRoomNo.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomNo.ForeColor = System.Drawing.Color.White;
            this.lblRoomNo.Location = new System.Drawing.Point(302, 59);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(55, 13);
            this.lblRoomNo.TabIndex = 25;
            this.lblRoomNo.Text = "Room No.";
            // 
            // textRate
            // 
            this.textRate.Location = new System.Drawing.Point(397, 19);
            this.textRate.Name = "textRate";
            this.textRate.Size = new System.Drawing.Size(150, 20);
            this.textRate.TabIndex = 2;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.BackColor = System.Drawing.Color.Transparent;
            this.lblRate.ForeColor = System.Drawing.Color.White;
            this.lblRate.Location = new System.Drawing.Point(302, 26);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(54, 13);
            this.lblRate.TabIndex = 21;
            this.lblRate.Text = "Rate/Day";
            // 
            // lblRoomtype
            // 
            this.lblRoomtype.AutoSize = true;
            this.lblRoomtype.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomtype.ForeColor = System.Drawing.Color.White;
            this.lblRoomtype.Location = new System.Drawing.Point(12, 26);
            this.lblRoomtype.Name = "lblRoomtype";
            this.lblRoomtype.Size = new System.Drawing.Size(62, 13);
            this.lblRoomtype.TabIndex = 16;
            this.lblRoomtype.Text = "Room Type";
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(101, 18);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(149, 21);
            this.cmbRoomType.TabIndex = 1;
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(102, 51);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(149, 21);
            this.cmbName.Sorted = true;
            this.cmbName.TabIndex = 4;
            // 
            // cmbRoomNo
            // 
            this.cmbRoomNo.FormattingEnabled = true;
            this.cmbRoomNo.Location = new System.Drawing.Point(397, 51);
            this.cmbRoomNo.Name = "cmbRoomNo";
            this.cmbRoomNo.Size = new System.Drawing.Size(150, 21);
            this.cmbRoomNo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(13, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(617, 181);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbRoomNo);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblRoomNo);
            this.Controls.Add(this.textRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblRoomtype);
            this.Controls.Add(this.cmbRoomType);
            this.Name = "frmCheckIn";
            this.Text = "Check In";
            this.Load += new System.EventHandler(this.frmCheckIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRoomNo;
        private System.Windows.Forms.TextBox textRate;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblRoomtype;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.ComboBox cmbRoomNo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}