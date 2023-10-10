namespace DE02
{
    partial class frmSanPham
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
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.lvSanPham = new System.Windows.Forms.ListView();
            this.MaSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NgayNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btKLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.dtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(106, 75);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(321, 31);
            this.txtFind.TabIndex = 0;
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(456, 75);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(106, 34);
            this.btFind.TabIndex = 1;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // lvSanPham
            // 
            this.lvSanPham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaSP,
            this.TenSP,
            this.NgayNhap,
            this.MaLoai});
            this.lvSanPham.HideSelection = false;
            this.lvSanPham.Location = new System.Drawing.Point(58, 136);
            this.lvSanPham.Name = "lvSanPham";
            this.lvSanPham.Size = new System.Drawing.Size(1081, 661);
            this.lvSanPham.TabIndex = 2;
            this.lvSanPham.UseCompatibleStateImageBehavior = false;
            this.lvSanPham.View = System.Windows.Forms.View.Details;
            this.lvSanPham.SelectedIndexChanged += new System.EventHandler(this.lvSanPham_SelectedIndexChanged);
            // 
            // MaSP
            // 
            this.MaSP.Text = "MaSP";
            // 
            // TenSP
            // 
            this.TenSP.Text = "TenSP";
            this.TenSP.Width = 100;
            // 
            // NgayNhap
            // 
            this.NgayNhap.Text = "NgayNhap";
            this.NgayNhap.Width = 150;
            // 
            // MaLoai
            // 
            this.MaLoai.Text = "MaLoai";
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(58, 815);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(157, 55);
            this.btThem.TabIndex = 3;
            this.btThem.Text = "Them";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(426, 815);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(157, 55);
            this.btXoa.TabIndex = 3;
            this.btXoa.Text = "Xoa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(242, 815);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(157, 55);
            this.btSua.TabIndex = 3;
            this.btSua.Text = "Sua";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btLuu
            // 
            this.btLuu.Enabled = false;
            this.btLuu.Location = new System.Drawing.Point(610, 815);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(157, 55);
            this.btLuu.TabIndex = 3;
            this.btLuu.Text = "Luu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btKLuu
            // 
            this.btKLuu.Enabled = false;
            this.btKLuu.Location = new System.Drawing.Point(794, 815);
            this.btKLuu.Name = "btKLuu";
            this.btKLuu.Size = new System.Drawing.Size(157, 55);
            this.btKLuu.TabIndex = 3;
            this.btKLuu.Text = "K.Luu";
            this.btKLuu.UseVisualStyleBackColor = true;
            this.btKLuu.Click += new System.EventHandler(this.btKLuu_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(978, 815);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(157, 55);
            this.btThoat.TabIndex = 3;
            this.btThoat.Text = "Thoat";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(1184, 187);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(70, 25);
            this.lblMaSP.TabIndex = 4;
            this.lblMaSP.Text = "MaSP";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(1327, 186);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(369, 31);
            this.txtMaSP.TabIndex = 5;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(1184, 268);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(77, 25);
            this.lblTenSP.TabIndex = 4;
            this.lblTenSP.Text = "TenSP";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(1184, 349);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(113, 25);
            this.lblNgayNhap.TabIndex = 4;
            this.lblNgayNhap.Text = "NgayNhap";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(1327, 268);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(369, 31);
            this.txtTenSP.TabIndex = 5;
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(1184, 430);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(81, 25);
            this.lblLoaiSP.TabIndex = 4;
            this.lblLoaiSP.Text = "LoaiSP";
            // 
            // dtNgayNhap
            // 
            this.dtNgayNhap.Location = new System.Drawing.Point(1327, 350);
            this.dtNgayNhap.Name = "dtNgayNhap";
            this.dtNgayNhap.Size = new System.Drawing.Size(369, 31);
            this.dtNgayNhap.TabIndex = 6;
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(1327, 432);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(369, 33);
            this.cboLoaiSP.TabIndex = 7;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 948);
            this.Controls.Add(this.cboLoaiSP);
            this.Controls.Add(this.dtNgayNhap);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblLoaiSP);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btKLuu);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.lvSanPham);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.txtFind);
            this.Name = "frmSanPham";
            this.Text = "Danh Muc San Pham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.ListView lvSanPham;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btKLuu;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.DateTimePicker dtNgayNhap;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.ColumnHeader MaSP;
        private System.Windows.Forms.ColumnHeader TenSP;
        private System.Windows.Forms.ColumnHeader NgayNhap;
        private System.Windows.Forms.ColumnHeader MaLoai;
    }
}

