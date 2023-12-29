namespace Hotel
{
    partial class frmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userLoginDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomTypeMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodItemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInCheckOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.roomSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUserId = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.receptionToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.updatePasswordToolStripMenuItem,
            this.userLoginDetailsToolStripMenuItem});
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newUserToolStripMenuItem.Text = "New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // updatePasswordToolStripMenuItem
            // 
            this.updatePasswordToolStripMenuItem.Name = "updatePasswordToolStripMenuItem";
            this.updatePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.updatePasswordToolStripMenuItem.Text = "Update Password";
            this.updatePasswordToolStripMenuItem.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // userLoginDetailsToolStripMenuItem
            // 
            this.userLoginDetailsToolStripMenuItem.Name = "userLoginDetailsToolStripMenuItem";
            this.userLoginDetailsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.userLoginDetailsToolStripMenuItem.Text = "User Login Details";
            this.userLoginDetailsToolStripMenuItem.Click += new System.EventHandler(this.userLoginDetailsToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomTypeMasterToolStripMenuItem,
            this.roomMasterToolStripMenuItem,
            this.foodItemMasterToolStripMenuItem,
            this.miscMasterToolStripMenuItem});
            this.masterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // roomTypeMasterToolStripMenuItem
            // 
            this.roomTypeMasterToolStripMenuItem.Name = "roomTypeMasterToolStripMenuItem";
            this.roomTypeMasterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.roomTypeMasterToolStripMenuItem.Text = "Room Type Master";
            this.roomTypeMasterToolStripMenuItem.Click += new System.EventHandler(this.roomTypeMasterToolStripMenuItem_Click);
            // 
            // roomMasterToolStripMenuItem
            // 
            this.roomMasterToolStripMenuItem.Name = "roomMasterToolStripMenuItem";
            this.roomMasterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.roomMasterToolStripMenuItem.Text = "Room Master";
            this.roomMasterToolStripMenuItem.Click += new System.EventHandler(this.roomMasterToolStripMenuItem_Click);
            // 
            // foodItemMasterToolStripMenuItem
            // 
            this.foodItemMasterToolStripMenuItem.Name = "foodItemMasterToolStripMenuItem";
            this.foodItemMasterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.foodItemMasterToolStripMenuItem.Text = "Food Item Master";
            this.foodItemMasterToolStripMenuItem.Click += new System.EventHandler(this.foodItemMasterToolStripMenuItem_Click);
            // 
            // miscMasterToolStripMenuItem
            // 
            this.miscMasterToolStripMenuItem.Name = "miscMasterToolStripMenuItem";
            this.miscMasterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.miscMasterToolStripMenuItem.Text = "Misc. Master";
            // 
            // receptionToolStripMenuItem
            // 
            this.receptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerEntryToolStripMenuItem,
            this.checkInCheckOutToolStripMenuItem,
            this.checkOutToolStripMenuItem,
            this.billingToolStripMenuItem1,
            this.roomSearchToolStripMenuItem});
            this.receptionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.receptionToolStripMenuItem.Name = "receptionToolStripMenuItem";
            this.receptionToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.receptionToolStripMenuItem.Text = "Reception";
            // 
            // customerEntryToolStripMenuItem
            // 
            this.customerEntryToolStripMenuItem.Name = "customerEntryToolStripMenuItem";
            this.customerEntryToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.customerEntryToolStripMenuItem.Text = "Customer Entry";
            this.customerEntryToolStripMenuItem.Click += new System.EventHandler(this.customerEntryToolStripMenuItem_Click);
            // 
            // checkInCheckOutToolStripMenuItem
            // 
            this.checkInCheckOutToolStripMenuItem.Name = "checkInCheckOutToolStripMenuItem";
            this.checkInCheckOutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.checkInCheckOutToolStripMenuItem.Text = "Check In";
            this.checkInCheckOutToolStripMenuItem.Click += new System.EventHandler(this.checkInCheckOutToolStripMenuItem_Click);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.checkOutToolStripMenuItem.Text = "Check Out";
            this.checkOutToolStripMenuItem.Click += new System.EventHandler(this.checkOutToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem1
            // 
            this.billingToolStripMenuItem1.Name = "billingToolStripMenuItem1";
            this.billingToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.billingToolStripMenuItem1.Text = "Billing";
            this.billingToolStripMenuItem1.Click += new System.EventHandler(this.billingToolStripMenuItem1_Click);
            // 
            // roomSearchToolStripMenuItem
            // 
            this.roomSearchToolStripMenuItem.Name = "roomSearchToolStripMenuItem";
            this.roomSearchToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.roomSearchToolStripMenuItem.Text = "Room Search";
            this.roomSearchToolStripMenuItem.Click += new System.EventHandler(this.roomSearchToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderEntryToolStripMenuItem,
            this.orderStatusToolStripMenuItem,
            this.viewOrderToolStripMenuItem});
            this.ordersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // orderEntryToolStripMenuItem
            // 
            this.orderEntryToolStripMenuItem.Name = "orderEntryToolStripMenuItem";
            this.orderEntryToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.orderEntryToolStripMenuItem.Text = "Order Entry";
            this.orderEntryToolStripMenuItem.Click += new System.EventHandler(this.orderEntryToolStripMenuItem_Click);
            // 
            // orderStatusToolStripMenuItem
            // 
            this.orderStatusToolStripMenuItem.Name = "orderStatusToolStripMenuItem";
            this.orderStatusToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.orderStatusToolStripMenuItem.Text = "Order Status";
            this.orderStatusToolStripMenuItem.Click += new System.EventHandler(this.orderStatusToolStripMenuItem_Click);
            // 
            // viewOrderToolStripMenuItem
            // 
            this.viewOrderToolStripMenuItem.Name = "viewOrderToolStripMenuItem";
            this.viewOrderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.viewOrderToolStripMenuItem.Text = "View Order";
            this.viewOrderToolStripMenuItem.Click += new System.EventHandler(this.viewOrderToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerDetailsToolStripMenuItem,
            this.collectionReportToolStripMenuItem});
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // customerDetailsToolStripMenuItem
            // 
            this.customerDetailsToolStripMenuItem.Name = "customerDetailsToolStripMenuItem";
            this.customerDetailsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.customerDetailsToolStripMenuItem.Text = "Customer Details ";
            this.customerDetailsToolStripMenuItem.Click += new System.EventHandler(this.customerDetailsToolStripMenuItem_Click);
            // 
            // collectionReportToolStripMenuItem
            // 
            this.collectionReportToolStripMenuItem.Name = "collectionReportToolStripMenuItem";
            this.collectionReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.collectionReportToolStripMenuItem.Text = "Collection Report";
            this.collectionReportToolStripMenuItem.Click += new System.EventHandler(this.collectionReportToolStripMenuItem_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(12, 35);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(0, 13);
            this.lblUserId.TabIndex = 1;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Hotel.Resource1.wallpaper2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 386);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userLoginDetailsToolStripMenuItem;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomTypeMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodItemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkInCheckOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem roomSearchToolStripMenuItem;
    }
}