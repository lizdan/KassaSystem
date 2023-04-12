namespace KassaSystem
{
    partial class StoreManagementForm
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
            this.StoreTabControl = new System.Windows.Forms.TabControl();
            this.CheckoutTab = new System.Windows.Forms.TabPage();
            this.WarehouseTab = new System.Windows.Forms.TabPage();
            this.StoreTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // StoreTabControl
            // 
            this.StoreTabControl.Controls.Add(this.CheckoutTab);
            this.StoreTabControl.Controls.Add(this.WarehouseTab);
            this.StoreTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StoreTabControl.Location = new System.Drawing.Point(0, 0);
            this.StoreTabControl.Name = "StoreTabControl";
            this.StoreTabControl.SelectedIndex = 0;
            this.StoreTabControl.Size = new System.Drawing.Size(932, 1055);
            this.StoreTabControl.TabIndex = 0;
            this.StoreTabControl.SelectedIndexChanged += new System.EventHandler(this.StoreTabControl_SelectedIndexChanged);
            // 
            // CheckoutTab
            // 
            this.CheckoutTab.Location = new System.Drawing.Point(4, 25);
            this.CheckoutTab.Name = "CheckoutTab";
            this.CheckoutTab.Padding = new System.Windows.Forms.Padding(3);
            this.CheckoutTab.Size = new System.Drawing.Size(924, 1026);
            this.CheckoutTab.TabIndex = 0;
            this.CheckoutTab.Text = "Checkout";
            this.CheckoutTab.UseVisualStyleBackColor = true;
            // 
            // WarehouseTab
            // 
            this.WarehouseTab.Location = new System.Drawing.Point(4, 25);
            this.WarehouseTab.Name = "WarehouseTab";
            this.WarehouseTab.Padding = new System.Windows.Forms.Padding(3);
            this.WarehouseTab.Size = new System.Drawing.Size(924, 1026);
            this.WarehouseTab.TabIndex = 1;
            this.WarehouseTab.Text = "Warehouse";
            this.WarehouseTab.UseVisualStyleBackColor = true;
            // 
            // StoreManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 1055);
            this.Controls.Add(this.StoreTabControl);
            this.MinimumSize = new System.Drawing.Size(950, 1018);
            this.Name = "StoreManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Management System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StoreManagementForm_FormClosed);
            this.Load += new System.EventHandler(this.StoreManagementForm_Load);
            this.Shown += new System.EventHandler(this.StoreManagementForm_Shown);
            this.StoreTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl StoreTabControl;
        private System.Windows.Forms.TabPage CheckoutTab;
        private System.Windows.Forms.TabPage WarehouseTab;
    }
}

