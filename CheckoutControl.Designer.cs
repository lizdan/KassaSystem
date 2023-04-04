namespace KassaSystem
{
    partial class CheckoutControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartGroupBx = new System.Windows.Forms.GroupBox();
            this.CartListBox = new System.Windows.Forms.ListBox();
            this.InstructionsCartLbl = new System.Windows.Forms.Label();
            this.AddCartBtn = new System.Windows.Forms.Button();
            this.SellCartBtn = new System.Windows.Forms.Button();
            this.RemoveCartBtn = new System.Windows.Forms.Button();
            this.CartAmountTxBx = new System.Windows.Forms.TextBox();
            this.CartCostLbl = new System.Windows.Forms.Label();
            this.radioBtnMovie = new System.Windows.Forms.RadioButton();
            this.radioBtnGame = new System.Windows.Forms.RadioButton();
            this.radioBtnBook = new System.Windows.Forms.RadioButton();
            this.OverviewLbl = new System.Windows.Forms.Label();
            this.groupBoxManagement = new System.Windows.Forms.GroupBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SaveStoreBtn = new System.Windows.Forms.Button();
            this.RemoveStoreBtn = new System.Windows.Forms.Button();
            this.LengthTxBx = new System.Windows.Forms.TextBox();
            this.AddStoreBtn = new System.Windows.Forms.Button();
            this.VaruNrTxBx = new System.Windows.Forms.TextBox();
            this.NameTxBx = new System.Windows.Forms.TextBox();
            this.PlatformTxBx = new System.Windows.Forms.TextBox();
            this.InfoManagementLbl = new System.Windows.Forms.Label();
            this.VaruNrLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.LanguageTxBx = new System.Windows.Forms.TextBox();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.FormatTxBx = new System.Windows.Forms.TextBox();
            this.AuthorLbl = new System.Windows.Forms.Label();
            this.GenreTxBx = new System.Windows.Forms.TextBox();
            this.GenreLbl = new System.Windows.Forms.Label();
            this.AuthorTxBx = new System.Windows.Forms.TextBox();
            this.FormatLbl = new System.Windows.Forms.Label();
            this.PriceTxBx = new System.Windows.Forms.TextBox();
            this.LanguageLbl = new System.Windows.Forms.Label();
            this.PlatformLbl = new System.Windows.Forms.Label();
            this.LengthLbl = new System.Windows.Forms.Label();
            this.dataGridViewCheckout = new System.Windows.Forms.DataGridView();
            this.splitContGeneral = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cartGroupBx.SuspendLayout();
            this.groupBoxManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContGeneral)).BeginInit();
            this.splitContGeneral.Panel1.SuspendLayout();
            this.splitContGeneral.Panel2.SuspendLayout();
            this.splitContGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartGroupBx
            // 
            this.cartGroupBx.Controls.Add(this.CartListBox);
            this.cartGroupBx.Controls.Add(this.InstructionsCartLbl);
            this.cartGroupBx.Controls.Add(this.AddCartBtn);
            this.cartGroupBx.Controls.Add(this.SellCartBtn);
            this.cartGroupBx.Controls.Add(this.RemoveCartBtn);
            this.cartGroupBx.Controls.Add(this.CartAmountTxBx);
            this.cartGroupBx.Controls.Add(this.CartCostLbl);
            this.cartGroupBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartGroupBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartGroupBx.Location = new System.Drawing.Point(0, 0);
            this.cartGroupBx.Name = "cartGroupBx";
            this.cartGroupBx.Size = new System.Drawing.Size(544, 405);
            this.cartGroupBx.TabIndex = 4;
            this.cartGroupBx.TabStop = false;
            this.cartGroupBx.Text = "Cart:";
            // 
            // CartListBox
            // 
            this.CartListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartListBox.FormattingEnabled = true;
            this.CartListBox.ItemHeight = 18;
            this.CartListBox.Location = new System.Drawing.Point(6, 175);
            this.CartListBox.Name = "CartListBox";
            this.CartListBox.Size = new System.Drawing.Size(532, 130);
            this.CartListBox.TabIndex = 7;
            // 
            // InstructionsCartLbl
            // 
            this.InstructionsCartLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InstructionsCartLbl.AutoSize = true;
            this.InstructionsCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsCartLbl.Location = new System.Drawing.Point(6, 26);
            this.InstructionsCartLbl.Name = "InstructionsCartLbl";
            this.InstructionsCartLbl.Size = new System.Drawing.Size(328, 32);
            this.InstructionsCartLbl.TabIndex = 3;
            this.InstructionsCartLbl.Text = "Select a product from overview before adding it to cart.\r\nSelect a product below " +
    "before removing it from cart.";
            // 
            // AddCartBtn
            // 
            this.AddCartBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddCartBtn.Enabled = false;
            this.AddCartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCartBtn.Location = new System.Drawing.Point(136, 118);
            this.AddCartBtn.Name = "AddCartBtn";
            this.AddCartBtn.Size = new System.Drawing.Size(138, 34);
            this.AddCartBtn.TabIndex = 6;
            this.AddCartBtn.Text = "Add to cart";
            this.AddCartBtn.UseVisualStyleBackColor = true;
            this.AddCartBtn.Click += new System.EventHandler(this.AddCartBtn_Click);
            // 
            // SellCartBtn
            // 
            this.SellCartBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SellCartBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SellCartBtn.Enabled = false;
            this.SellCartBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SellCartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellCartBtn.Location = new System.Drawing.Point(3, 352);
            this.SellCartBtn.Name = "SellCartBtn";
            this.SellCartBtn.Size = new System.Drawing.Size(538, 50);
            this.SellCartBtn.TabIndex = 1;
            this.SellCartBtn.Text = "Sell products";
            this.SellCartBtn.UseVisualStyleBackColor = false;
            this.SellCartBtn.Click += new System.EventHandler(this.SellCartBtn_Click);
            // 
            // RemoveCartBtn
            // 
            this.RemoveCartBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RemoveCartBtn.Enabled = false;
            this.RemoveCartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCartBtn.Location = new System.Drawing.Point(280, 118);
            this.RemoveCartBtn.Name = "RemoveCartBtn";
            this.RemoveCartBtn.Size = new System.Drawing.Size(138, 34);
            this.RemoveCartBtn.TabIndex = 1;
            this.RemoveCartBtn.Text = "Remove from cart";
            this.RemoveCartBtn.UseVisualStyleBackColor = true;
            this.RemoveCartBtn.Click += new System.EventHandler(this.RemoveCartBtn_Click);
            // 
            // CartAmountTxBx
            // 
            this.CartAmountTxBx.Enabled = false;
            this.CartAmountTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartAmountTxBx.Location = new System.Drawing.Point(115, 309);
            this.CartAmountTxBx.Name = "CartAmountTxBx";
            this.CartAmountTxBx.ReadOnly = true;
            this.CartAmountTxBx.Size = new System.Drawing.Size(95, 24);
            this.CartAmountTxBx.TabIndex = 5;
            this.CartAmountTxBx.TextChanged += new System.EventHandler(this.NameTxBx_TextChanged);
            // 
            // CartCostLbl
            // 
            this.CartCostLbl.AutoSize = true;
            this.CartCostLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartCostLbl.Location = new System.Drawing.Point(21, 314);
            this.CartCostLbl.Name = "CartCostLbl";
            this.CartCostLbl.Size = new System.Drawing.Size(88, 16);
            this.CartCostLbl.TabIndex = 2;
            this.CartCostLbl.Text = "Total amount:";
            // 
            // radioBtnMovie
            // 
            this.radioBtnMovie.AutoSize = true;
            this.radioBtnMovie.Location = new System.Drawing.Point(763, 315);
            this.radioBtnMovie.Name = "radioBtnMovie";
            this.radioBtnMovie.Size = new System.Drawing.Size(72, 20);
            this.radioBtnMovie.TabIndex = 3;
            this.radioBtnMovie.TabStop = true;
            this.radioBtnMovie.Text = "Movies";
            this.radioBtnMovie.UseVisualStyleBackColor = true;
            this.radioBtnMovie.CheckedChanged += new System.EventHandler(this.radioBtnMovie_CheckedChanged);
            // 
            // radioBtnGame
            // 
            this.radioBtnGame.AutoSize = true;
            this.radioBtnGame.Location = new System.Drawing.Point(403, 315);
            this.radioBtnGame.Name = "radioBtnGame";
            this.radioBtnGame.Size = new System.Drawing.Size(72, 20);
            this.radioBtnGame.TabIndex = 3;
            this.radioBtnGame.TabStop = true;
            this.radioBtnGame.Text = "Games";
            this.radioBtnGame.UseVisualStyleBackColor = true;
            this.radioBtnGame.CheckedChanged += new System.EventHandler(this.radioBtnGame_CheckedChanged);
            // 
            // radioBtnBook
            // 
            this.radioBtnBook.AutoSize = true;
            this.radioBtnBook.Location = new System.Drawing.Point(43, 315);
            this.radioBtnBook.Name = "radioBtnBook";
            this.radioBtnBook.Size = new System.Drawing.Size(67, 20);
            this.radioBtnBook.TabIndex = 3;
            this.radioBtnBook.TabStop = true;
            this.radioBtnBook.Text = "Books";
            this.radioBtnBook.UseVisualStyleBackColor = true;
            this.radioBtnBook.CheckedChanged += new System.EventHandler(this.radioBtnBook_CheckedChanged);
            // 
            // OverviewLbl
            // 
            this.OverviewLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OverviewLbl.AutoSize = true;
            this.OverviewLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverviewLbl.Location = new System.Drawing.Point(410, 18);
            this.OverviewLbl.Name = "OverviewLbl";
            this.OverviewLbl.Size = new System.Drawing.Size(89, 20);
            this.OverviewLbl.TabIndex = 2;
            this.OverviewLbl.Text = "OverView";
            // 
            // groupBoxManagement
            // 
            this.groupBoxManagement.Controls.Add(this.ClearBtn);
            this.groupBoxManagement.Controls.Add(this.SaveStoreBtn);
            this.groupBoxManagement.Controls.Add(this.RemoveStoreBtn);
            this.groupBoxManagement.Controls.Add(this.LengthTxBx);
            this.groupBoxManagement.Controls.Add(this.AddStoreBtn);
            this.groupBoxManagement.Controls.Add(this.VaruNrTxBx);
            this.groupBoxManagement.Controls.Add(this.NameTxBx);
            this.groupBoxManagement.Controls.Add(this.PlatformTxBx);
            this.groupBoxManagement.Controls.Add(this.InfoManagementLbl);
            this.groupBoxManagement.Controls.Add(this.VaruNrLbl);
            this.groupBoxManagement.Controls.Add(this.NameLbl);
            this.groupBoxManagement.Controls.Add(this.LanguageTxBx);
            this.groupBoxManagement.Controls.Add(this.PriceLbl);
            this.groupBoxManagement.Controls.Add(this.FormatTxBx);
            this.groupBoxManagement.Controls.Add(this.AuthorLbl);
            this.groupBoxManagement.Controls.Add(this.GenreTxBx);
            this.groupBoxManagement.Controls.Add(this.GenreLbl);
            this.groupBoxManagement.Controls.Add(this.AuthorTxBx);
            this.groupBoxManagement.Controls.Add(this.FormatLbl);
            this.groupBoxManagement.Controls.Add(this.PriceTxBx);
            this.groupBoxManagement.Controls.Add(this.LanguageLbl);
            this.groupBoxManagement.Controls.Add(this.PlatformLbl);
            this.groupBoxManagement.Controls.Add(this.LengthLbl);
            this.groupBoxManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxManagement.Location = new System.Drawing.Point(0, 0);
            this.groupBoxManagement.Name = "groupBoxManagement";
            this.groupBoxManagement.Size = new System.Drawing.Size(350, 405);
            this.groupBoxManagement.TabIndex = 6;
            this.groupBoxManagement.TabStop = false;
            this.groupBoxManagement.Text = "Product management:";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearBtn.Enabled = false;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(307, 266);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(85, 45);
            this.ClearBtn.TabIndex = 6;
            this.ClearBtn.Text = "Clear ";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // SaveStoreBtn
            // 
            this.SaveStoreBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveStoreBtn.Enabled = false;
            this.SaveStoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveStoreBtn.Location = new System.Drawing.Point(307, 215);
            this.SaveStoreBtn.Name = "SaveStoreBtn";
            this.SaveStoreBtn.Size = new System.Drawing.Size(85, 45);
            this.SaveStoreBtn.TabIndex = 6;
            this.SaveStoreBtn.Text = "Save changes";
            this.SaveStoreBtn.UseVisualStyleBackColor = true;
            this.SaveStoreBtn.Click += new System.EventHandler(this.SaveStoreBtn_Click);
            // 
            // RemoveStoreBtn
            // 
            this.RemoveStoreBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RemoveStoreBtn.Enabled = false;
            this.RemoveStoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveStoreBtn.Location = new System.Drawing.Point(307, 164);
            this.RemoveStoreBtn.Name = "RemoveStoreBtn";
            this.RemoveStoreBtn.Size = new System.Drawing.Size(85, 45);
            this.RemoveStoreBtn.TabIndex = 6;
            this.RemoveStoreBtn.Text = "Remove from store";
            this.RemoveStoreBtn.UseVisualStyleBackColor = true;
            this.RemoveStoreBtn.Click += new System.EventHandler(this.RemoveStoreBtn_Click);
            // 
            // LengthTxBx
            // 
            this.LengthTxBx.Enabled = false;
            this.LengthTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LengthTxBx.Location = new System.Drawing.Point(109, 314);
            this.LengthTxBx.Name = "LengthTxBx";
            this.LengthTxBx.Size = new System.Drawing.Size(95, 24);
            this.LengthTxBx.TabIndex = 5;
            this.LengthTxBx.TextChanged += new System.EventHandler(this.LengthTxBx_TextChanged);
            // 
            // AddStoreBtn
            // 
            this.AddStoreBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddStoreBtn.Enabled = false;
            this.AddStoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStoreBtn.Location = new System.Drawing.Point(307, 113);
            this.AddStoreBtn.Name = "AddStoreBtn";
            this.AddStoreBtn.Size = new System.Drawing.Size(85, 45);
            this.AddStoreBtn.TabIndex = 6;
            this.AddStoreBtn.Text = "Add to store";
            this.AddStoreBtn.UseVisualStyleBackColor = true;
            this.AddStoreBtn.Click += new System.EventHandler(this.AddStoreBtn_Click);
            // 
            // VaruNrTxBx
            // 
            this.VaruNrTxBx.Enabled = false;
            this.VaruNrTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VaruNrTxBx.Location = new System.Drawing.Point(109, 88);
            this.VaruNrTxBx.Name = "VaruNrTxBx";
            this.VaruNrTxBx.Size = new System.Drawing.Size(95, 24);
            this.VaruNrTxBx.TabIndex = 5;
            this.VaruNrTxBx.TextChanged += new System.EventHandler(this.NameTxBx_TextChanged);
            // 
            // NameTxBx
            // 
            this.NameTxBx.Enabled = false;
            this.NameTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTxBx.Location = new System.Drawing.Point(109, 118);
            this.NameTxBx.Name = "NameTxBx";
            this.NameTxBx.Size = new System.Drawing.Size(250, 24);
            this.NameTxBx.TabIndex = 5;
            this.NameTxBx.TextChanged += new System.EventHandler(this.NameTxBx_TextChanged);
            // 
            // PlatformTxBx
            // 
            this.PlatformTxBx.Enabled = false;
            this.PlatformTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatformTxBx.Location = new System.Drawing.Point(109, 286);
            this.PlatformTxBx.Name = "PlatformTxBx";
            this.PlatformTxBx.Size = new System.Drawing.Size(163, 24);
            this.PlatformTxBx.TabIndex = 5;
            // 
            // InfoManagementLbl
            // 
            this.InfoManagementLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoManagementLbl.AutoSize = true;
            this.InfoManagementLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoManagementLbl.Location = new System.Drawing.Point(16, 26);
            this.InfoManagementLbl.Name = "InfoManagementLbl";
            this.InfoManagementLbl.Size = new System.Drawing.Size(309, 32);
            this.InfoManagementLbl.TabIndex = 2;
            this.InfoManagementLbl.Text = "Select a product from overview or enter information.\r\n* = obligatoriskt.\r\n";
            // 
            // VaruNrLbl
            // 
            this.VaruNrLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VaruNrLbl.AutoSize = true;
            this.VaruNrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VaruNrLbl.Location = new System.Drawing.Point(17, 93);
            this.VaruNrLbl.Name = "VaruNrLbl";
            this.VaruNrLbl.Size = new System.Drawing.Size(82, 16);
            this.VaruNrLbl.TabIndex = 2;
            this.VaruNrLbl.Text = "ProdNr(123):";
            // 
            // NameLbl
            // 
            this.NameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(17, 121);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(52, 16);
            this.NameLbl.TabIndex = 2;
            this.NameLbl.Text = "*Name:";
            // 
            // LanguageTxBx
            // 
            this.LanguageTxBx.Enabled = false;
            this.LanguageTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageTxBx.Location = new System.Drawing.Point(109, 258);
            this.LanguageTxBx.Name = "LanguageTxBx";
            this.LanguageTxBx.Size = new System.Drawing.Size(163, 24);
            this.LanguageTxBx.TabIndex = 5;
            // 
            // PriceLbl
            // 
            this.PriceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PriceLbl.AutoSize = true;
            this.PriceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLbl.Location = new System.Drawing.Point(17, 149);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(46, 16);
            this.PriceLbl.TabIndex = 2;
            this.PriceLbl.Text = "*Price:";
            // 
            // FormatTxBx
            // 
            this.FormatTxBx.Enabled = false;
            this.FormatTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatTxBx.Location = new System.Drawing.Point(109, 230);
            this.FormatTxBx.Name = "FormatTxBx";
            this.FormatTxBx.Size = new System.Drawing.Size(95, 24);
            this.FormatTxBx.TabIndex = 5;
            // 
            // AuthorLbl
            // 
            this.AuthorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AuthorLbl.AutoSize = true;
            this.AuthorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLbl.Location = new System.Drawing.Point(17, 177);
            this.AuthorLbl.Name = "AuthorLbl";
            this.AuthorLbl.Size = new System.Drawing.Size(48, 16);
            this.AuthorLbl.TabIndex = 2;
            this.AuthorLbl.Text = "Author:";
            // 
            // GenreTxBx
            // 
            this.GenreTxBx.Enabled = false;
            this.GenreTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreTxBx.Location = new System.Drawing.Point(109, 202);
            this.GenreTxBx.Name = "GenreTxBx";
            this.GenreTxBx.Size = new System.Drawing.Size(163, 24);
            this.GenreTxBx.TabIndex = 5;
            // 
            // GenreLbl
            // 
            this.GenreLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GenreLbl.AutoSize = true;
            this.GenreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLbl.Location = new System.Drawing.Point(17, 205);
            this.GenreLbl.Name = "GenreLbl";
            this.GenreLbl.Size = new System.Drawing.Size(47, 16);
            this.GenreLbl.TabIndex = 2;
            this.GenreLbl.Text = "Genre:";
            // 
            // AuthorTxBx
            // 
            this.AuthorTxBx.Enabled = false;
            this.AuthorTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorTxBx.Location = new System.Drawing.Point(109, 174);
            this.AuthorTxBx.Name = "AuthorTxBx";
            this.AuthorTxBx.Size = new System.Drawing.Size(250, 24);
            this.AuthorTxBx.TabIndex = 5;
            // 
            // FormatLbl
            // 
            this.FormatLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FormatLbl.AutoSize = true;
            this.FormatLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatLbl.Location = new System.Drawing.Point(17, 233);
            this.FormatLbl.Name = "FormatLbl";
            this.FormatLbl.Size = new System.Drawing.Size(52, 16);
            this.FormatLbl.TabIndex = 2;
            this.FormatLbl.Text = "Format:";
            // 
            // PriceTxBx
            // 
            this.PriceTxBx.Enabled = false;
            this.PriceTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceTxBx.Location = new System.Drawing.Point(109, 146);
            this.PriceTxBx.Name = "PriceTxBx";
            this.PriceTxBx.Size = new System.Drawing.Size(95, 24);
            this.PriceTxBx.TabIndex = 5;
            this.PriceTxBx.TextChanged += new System.EventHandler(this.PriceTxBx_TextChanged);
            // 
            // LanguageLbl
            // 
            this.LanguageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LanguageLbl.AutoSize = true;
            this.LanguageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageLbl.Location = new System.Drawing.Point(17, 261);
            this.LanguageLbl.Name = "LanguageLbl";
            this.LanguageLbl.Size = new System.Drawing.Size(71, 16);
            this.LanguageLbl.TabIndex = 2;
            this.LanguageLbl.Text = "Language:";
            // 
            // PlatformLbl
            // 
            this.PlatformLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlatformLbl.AutoSize = true;
            this.PlatformLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatformLbl.Location = new System.Drawing.Point(17, 289);
            this.PlatformLbl.Name = "PlatformLbl";
            this.PlatformLbl.Size = new System.Drawing.Size(59, 16);
            this.PlatformLbl.TabIndex = 2;
            this.PlatformLbl.Text = "Platform:";
            // 
            // LengthLbl
            // 
            this.LengthLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LengthLbl.AutoSize = true;
            this.LengthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LengthLbl.Location = new System.Drawing.Point(17, 317);
            this.LengthLbl.Name = "LengthLbl";
            this.LengthLbl.Size = new System.Drawing.Size(50, 16);
            this.LengthLbl.TabIndex = 2;
            this.LengthLbl.Text = "Length:";
            // 
            // dataGridViewCheckout
            // 
            this.dataGridViewCheckout.AllowUserToAddRows = false;
            this.dataGridViewCheckout.AllowUserToDeleteRows = false;
            this.dataGridViewCheckout.AllowUserToResizeColumns = false;
            this.dataGridViewCheckout.AllowUserToResizeRows = false;
            this.dataGridViewCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCheckout.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewCheckout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheckout.EnableHeadersVisualStyles = false;
            this.dataGridViewCheckout.Location = new System.Drawing.Point(13, 41);
            this.dataGridViewCheckout.MultiSelect = false;
            this.dataGridViewCheckout.Name = "dataGridViewCheckout";
            this.dataGridViewCheckout.ReadOnly = true;
            this.dataGridViewCheckout.RowHeadersWidth = 51;
            this.dataGridViewCheckout.RowTemplate.Height = 24;
            this.dataGridViewCheckout.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCheckout.Size = new System.Drawing.Size(873, 268);
            this.dataGridViewCheckout.TabIndex = 10;
            this.dataGridViewCheckout.TabStop = false;
            this.dataGridViewCheckout.SelectionChanged += new System.EventHandler(this.dataGridViewCheckout_SelectionChanged);
            // 
            // splitContGeneral
            // 
            this.splitContGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContGeneral.Location = new System.Drawing.Point(0, 0);
            this.splitContGeneral.Name = "splitContGeneral";
            this.splitContGeneral.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContGeneral.Panel1
            // 
            this.splitContGeneral.Panel1.Controls.Add(this.radioBtnMovie);
            this.splitContGeneral.Panel1.Controls.Add(this.OverviewLbl);
            this.splitContGeneral.Panel1.Controls.Add(this.dataGridViewCheckout);
            this.splitContGeneral.Panel1.Controls.Add(this.radioBtnBook);
            this.splitContGeneral.Panel1.Controls.Add(this.radioBtnGame);
            // 
            // splitContGeneral.Panel2
            // 
            this.splitContGeneral.Panel2.Controls.Add(this.splitContainer1);
            this.splitContGeneral.Size = new System.Drawing.Size(898, 829);
            this.splitContGeneral.SplitterDistance = 420;
            this.splitContGeneral.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxManagement);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cartGroupBx);
            this.splitContainer1.Size = new System.Drawing.Size(898, 405);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // CheckoutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContGeneral);
            this.Name = "CheckoutControl";
            this.Size = new System.Drawing.Size(898, 829);
            this.cartGroupBx.ResumeLayout(false);
            this.cartGroupBx.PerformLayout();
            this.groupBoxManagement.ResumeLayout(false);
            this.groupBoxManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckout)).EndInit();
            this.splitContGeneral.Panel1.ResumeLayout(false);
            this.splitContGeneral.Panel1.PerformLayout();
            this.splitContGeneral.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContGeneral)).EndInit();
            this.splitContGeneral.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cartGroupBx;
        private System.Windows.Forms.Label InstructionsCartLbl;
        private System.Windows.Forms.Button AddCartBtn;
        private System.Windows.Forms.Button SellCartBtn;
        private System.Windows.Forms.Button RemoveCartBtn;
        private System.Windows.Forms.RadioButton radioBtnMovie;
        private System.Windows.Forms.RadioButton radioBtnGame;
        private System.Windows.Forms.RadioButton radioBtnBook;
        private System.Windows.Forms.Label OverviewLbl;
        private System.Windows.Forms.GroupBox groupBoxManagement;
        private System.Windows.Forms.Button SaveStoreBtn;
        private System.Windows.Forms.Button RemoveStoreBtn;
        private System.Windows.Forms.TextBox LengthTxBx;
        private System.Windows.Forms.Button AddStoreBtn;
        private System.Windows.Forms.TextBox NameTxBx;
        private System.Windows.Forms.TextBox PlatformTxBx;
        private System.Windows.Forms.Label InfoManagementLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox LanguageTxBx;
        private System.Windows.Forms.Label PriceLbl;
        private System.Windows.Forms.TextBox FormatTxBx;
        private System.Windows.Forms.Label AuthorLbl;
        private System.Windows.Forms.TextBox GenreTxBx;
        private System.Windows.Forms.Label GenreLbl;
        private System.Windows.Forms.TextBox AuthorTxBx;
        private System.Windows.Forms.Label FormatLbl;
        private System.Windows.Forms.TextBox PriceTxBx;
        private System.Windows.Forms.Label LanguageLbl;
        private System.Windows.Forms.Label PlatformLbl;
        private System.Windows.Forms.Label LengthLbl;
        private System.Windows.Forms.DataGridView dataGridViewCheckout;
        private System.Windows.Forms.SplitContainer splitContGeneral;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.TextBox VaruNrTxBx;
        private System.Windows.Forms.Label VaruNrLbl;
        private System.Windows.Forms.ListBox CartListBox;
        private System.Windows.Forms.TextBox CartAmountTxBx;
        private System.Windows.Forms.Label CartCostLbl;
    }
}
