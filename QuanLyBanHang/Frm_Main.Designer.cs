namespace QuanLyBanHang
{
    partial class Frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Customer = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ProductCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_Product = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_ListProduct = new System.Windows.Forms.Button();
            this.bt_danhthu = new System.Windows.Forms.Button();
            this.bt_nhaphang = new System.Windows.Forms.Button();
            this.btSellProducts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.traCứuToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Login,
            this.mn_Logout,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mn_Login
            // 
            this.mn_Login.Name = "mn_Login";
            this.mn_Login.Size = new System.Drawing.Size(165, 26);
            this.mn_Login.Text = "Đăng nhập";
            this.mn_Login.Click += new System.EventHandler(this.mn_Login_Click);
            // 
            // mn_Logout
            // 
            this.mn_Logout.Name = "mn_Logout";
            this.mn_Logout.Size = new System.Drawing.Size(165, 26);
            this.mn_Logout.Text = "Đăng xuất";
            this.mn_Logout.Visible = false;
            this.mn_Logout.Click += new System.EventHandler(this.mn_Logout_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_Customer,
            this.mn_Employee,
            this.mn_ProductCategory,
            this.mn_Product});
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lí";
            // 
            // mn_Customer
            // 
            this.mn_Customer.Name = "mn_Customer";
            this.mn_Customer.Size = new System.Drawing.Size(227, 26);
            this.mn_Customer.Text = "Khách hàng";
            this.mn_Customer.Click += new System.EventHandler(this.mn_Customer_Click);
            // 
            // mn_Employee
            // 
            this.mn_Employee.Name = "mn_Employee";
            this.mn_Employee.Size = new System.Drawing.Size(227, 26);
            this.mn_Employee.Text = "Nhân viên";
            this.mn_Employee.Click += new System.EventHandler(this.mn_Employee_Click);
            // 
            // mn_ProductCategory
            // 
            this.mn_ProductCategory.Name = "mn_ProductCategory";
            this.mn_ProductCategory.Size = new System.Drawing.Size(227, 26);
            this.mn_ProductCategory.Text = "Danh mục sản phẩm";
            this.mn_ProductCategory.Click += new System.EventHandler(this.mn_ProductCategory_Click);
            // 
            // mn_Product
            // 
            this.mn_Product.Name = "mn_Product";
            this.mn_Product.Size = new System.Drawing.Size(227, 26);
            this.mn_Product.Text = "Sản phẩm";
            this.mn_Product.Click += new System.EventHandler(this.mn_Product_Click);
            // 
            // traCứuToolStripMenuItem
            // 
            this.traCứuToolStripMenuItem.Name = "traCứuToolStripMenuItem";
            this.traCứuToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.traCứuToolStripMenuItem.Text = "Tra cứu";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // bt_ListProduct
            // 
            this.bt_ListProduct.BackColor = System.Drawing.Color.Transparent;
            this.bt_ListProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ListProduct.FlatAppearance.BorderSize = 0;
            this.bt_ListProduct.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.bt_ListProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_ListProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_ListProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ListProduct.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ListProduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_ListProduct.Image = ((System.Drawing.Image)(resources.GetObject("bt_ListProduct.Image")));
            this.bt_ListProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_ListProduct.Location = new System.Drawing.Point(663, 355);
            this.bt_ListProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_ListProduct.Name = "bt_ListProduct";
            this.bt_ListProduct.Size = new System.Drawing.Size(264, 213);
            this.bt_ListProduct.TabIndex = 19;
            this.bt_ListProduct.Text = "HÀNG HÓA";
            this.bt_ListProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_ListProduct.UseVisualStyleBackColor = false;
            this.bt_ListProduct.Click += new System.EventHandler(this.bt_ListProduct_Click);
            // 
            // bt_danhthu
            // 
            this.bt_danhthu.BackColor = System.Drawing.Color.Transparent;
            this.bt_danhthu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_danhthu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_danhthu.FlatAppearance.BorderSize = 0;
            this.bt_danhthu.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.bt_danhthu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_danhthu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_danhthu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_danhthu.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_danhthu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_danhthu.Image = ((System.Drawing.Image)(resources.GetObject("bt_danhthu.Image")));
            this.bt_danhthu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_danhthu.Location = new System.Drawing.Point(963, 355);
            this.bt_danhthu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_danhthu.Name = "bt_danhthu";
            this.bt_danhthu.Size = new System.Drawing.Size(264, 213);
            this.bt_danhthu.TabIndex = 18;
            this.bt_danhthu.Text = "DOANH THU";
            this.bt_danhthu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_danhthu.UseVisualStyleBackColor = false;
            // 
            // bt_nhaphang
            // 
            this.bt_nhaphang.BackColor = System.Drawing.Color.Transparent;
            this.bt_nhaphang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_nhaphang.FlatAppearance.BorderSize = 0;
            this.bt_nhaphang.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.bt_nhaphang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_nhaphang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_nhaphang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_nhaphang.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_nhaphang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_nhaphang.Image = ((System.Drawing.Image)(resources.GetObject("bt_nhaphang.Image")));
            this.bt_nhaphang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_nhaphang.Location = new System.Drawing.Point(363, 355);
            this.bt_nhaphang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_nhaphang.Name = "bt_nhaphang";
            this.bt_nhaphang.Size = new System.Drawing.Size(264, 213);
            this.bt_nhaphang.TabIndex = 17;
            this.bt_nhaphang.Text = "NHẬP HÀNG";
            this.bt_nhaphang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_nhaphang.UseVisualStyleBackColor = false;
            // 
            // btSellProducts
            // 
            this.btSellProducts.BackColor = System.Drawing.Color.Transparent;
            this.btSellProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSellProducts.FlatAppearance.BorderSize = 0;
            this.btSellProducts.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btSellProducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btSellProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btSellProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSellProducts.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSellProducts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btSellProducts.Image = ((System.Drawing.Image)(resources.GetObject("btSellProducts.Image")));
            this.btSellProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSellProducts.Location = new System.Drawing.Point(63, 355);
            this.btSellProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSellProducts.Name = "btSellProducts";
            this.btSellProducts.Size = new System.Drawing.Size(264, 213);
            this.btSellProducts.TabIndex = 16;
            this.btSellProducts.Text = "BÁN HÀNG";
            this.btSellProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSellProducts.UseVisualStyleBackColor = false;
            this.btSellProducts.Click += new System.EventHandler(this.btSellProducts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(399, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 53);
            this.label1.TabIndex = 20;
            this.label1.Text = "CỬA HÀNG ĐIỆN TỬ";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_ListProduct);
            this.Controls.Add(this.bt_danhthu);
            this.Controls.Add(this.bt_nhaphang);
            this.Controls.Add(this.btSellProducts);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng điện tử";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_Customer;
        private System.Windows.Forms.ToolStripMenuItem mn_Employee;
        private System.Windows.Forms.ToolStripMenuItem mn_ProductCategory;
        private System.Windows.Forms.ToolStripMenuItem mn_Product;
        private System.Windows.Forms.ToolStripMenuItem mn_Login;
        private System.Windows.Forms.ToolStripMenuItem mn_Logout;
        private System.Windows.Forms.ToolStripMenuItem traCứuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Button bt_ListProduct;
        private System.Windows.Forms.Button bt_danhthu;
        private System.Windows.Forms.Button bt_nhaphang;
        private System.Windows.Forms.Button btSellProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}