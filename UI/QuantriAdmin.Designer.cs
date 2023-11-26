namespace Quan_Ly_Dien_Thoai.UI
{
    partial class QuantriAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantriAdmin));
            this.button3 = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.tbcQuanTriAdmin = new System.Windows.Forms.TabControl();
            this.tbcAdmin_Nhacungcap = new System.Windows.Forms.TabPage();
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.dgvLoaiDocGia = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnXmlViewer_NCC = new System.Windows.Forms.Button();
            this.btn_Tim_NCC = new System.Windows.Forms.Button();
            this.btn_Renew_NCC = new System.Windows.Forms.Button();
            this.btn_Xoa_NCC = new System.Windows.Forms.Button();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.btn_Sua_NCC = new System.Windows.Forms.Button();
            this.btn_Them_NCC = new System.Windows.Forms.Button();
            this.txtSDT_NCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbcAdmin_NhanVien = new System.Windows.Forms.TabPage();
            this.btn_ViewXML_NV = new System.Windows.Forms.Button();
            this.btn_Tim_NV = new System.Windows.Forms.Button();
            this.gbNhanVien = new System.Windows.Forms.GroupBox();
            this.rdNhanVien = new System.Windows.Forms.RadioButton();
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.btnRenewNhanVien = new System.Windows.Forms.Button();
            this.btnThemNhanVIen = new System.Windows.Forms.Button();
            this.txtMatKhauNV = new System.Windows.Forms.TextBox();
            this.txtHoTenNV = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCapNhatNhanVien = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnXoaNhanVien = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.tbcQuanTriAdmin.SuspendLayout();
            this.tbcAdmin_Nhacungcap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDocGia)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tbcAdmin_NhanVien.SuspendLayout();
            this.gbNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(948, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 41);
            this.button3.TabIndex = 56;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.SystemColors.Control;
            this.btnClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClosed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClosed.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClosed.FlatAppearance.BorderSize = 0;
            this.btnClosed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.Image = ((System.Drawing.Image)(resources.GetObject("btnClosed.Image")));
            this.btnClosed.Location = new System.Drawing.Point(1013, 4);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(49, 43);
            this.btnClosed.TabIndex = 55;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // tbcQuanTriAdmin
            // 
            this.tbcQuanTriAdmin.Controls.Add(this.tbcAdmin_Nhacungcap);
            this.tbcQuanTriAdmin.Controls.Add(this.tbcAdmin_NhanVien);
            this.tbcQuanTriAdmin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbcQuanTriAdmin.ItemSize = new System.Drawing.Size(88, 28);
            this.tbcQuanTriAdmin.Location = new System.Drawing.Point(32, 72);
            this.tbcQuanTriAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.tbcQuanTriAdmin.Name = "tbcQuanTriAdmin";
            this.tbcQuanTriAdmin.SelectedIndex = 0;
            this.tbcQuanTriAdmin.Size = new System.Drawing.Size(1000, 541);
            this.tbcQuanTriAdmin.TabIndex = 57;
            // 
            // tbcAdmin_Nhacungcap
            // 
            this.tbcAdmin_Nhacungcap.BackColor = System.Drawing.SystemColors.Control;
            this.tbcAdmin_Nhacungcap.Controls.Add(this.dgvNCC);
            this.tbcAdmin_Nhacungcap.Controls.Add(this.dgvLoaiDocGia);
            this.tbcAdmin_Nhacungcap.Controls.Add(this.groupBox6);
            this.tbcAdmin_Nhacungcap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcAdmin_Nhacungcap.Location = new System.Drawing.Point(4, 32);
            this.tbcAdmin_Nhacungcap.Margin = new System.Windows.Forms.Padding(4);
            this.tbcAdmin_Nhacungcap.Name = "tbcAdmin_Nhacungcap";
            this.tbcAdmin_Nhacungcap.Padding = new System.Windows.Forms.Padding(4);
            this.tbcAdmin_Nhacungcap.Size = new System.Drawing.Size(992, 505);
            this.tbcAdmin_Nhacungcap.TabIndex = 0;
            this.tbcAdmin_Nhacungcap.Text = "Nhà cung cấp";
            // 
            // dgvNCC
            // 
            this.dgvNCC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvNCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNCC.Location = new System.Drawing.Point(32, 273);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.RowHeadersWidth = 51;
            this.dgvNCC.RowTemplate.Height = 24;
            this.dgvNCC.Size = new System.Drawing.Size(937, 229);
            this.dgvNCC.TabIndex = 5;
            this.dgvNCC.SelectionChanged += new System.EventHandler(this.dgvNCC_SelectionChanged);
            // 
            // dgvLoaiDocGia
            // 
            this.dgvLoaiDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiDocGia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLoaiDocGia.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLoaiDocGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoaiDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiDocGia.Location = new System.Drawing.Point(28, 273);
            this.dgvLoaiDocGia.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLoaiDocGia.Name = "dgvLoaiDocGia";
            this.dgvLoaiDocGia.RowHeadersWidth = 51;
            this.dgvLoaiDocGia.Size = new System.Drawing.Size(941, 172);
            this.dgvLoaiDocGia.TabIndex = 4;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnXmlViewer_NCC);
            this.groupBox6.Controls.Add(this.btn_Tim_NCC);
            this.groupBox6.Controls.Add(this.btn_Renew_NCC);
            this.groupBox6.Controls.Add(this.btn_Xoa_NCC);
            this.groupBox6.Controls.Add(this.txtMaNCC);
            this.groupBox6.Controls.Add(this.btn_Sua_NCC);
            this.groupBox6.Controls.Add(this.btn_Them_NCC);
            this.groupBox6.Controls.Add(this.txtSDT_NCC);
            this.groupBox6.Controls.Add(this.txtTenNCC);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Location = new System.Drawing.Point(32, 25);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(937, 226);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nhà cung cấp";
            // 
            // btnXmlViewer_NCC
            // 
            this.btnXmlViewer_NCC.BackColor = System.Drawing.Color.DarkGray;
            this.btnXmlViewer_NCC.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXmlViewer_NCC.ForeColor = System.Drawing.Color.White;
            this.btnXmlViewer_NCC.Location = new System.Drawing.Point(758, 98);
            this.btnXmlViewer_NCC.Name = "btnXmlViewer_NCC";
            this.btnXmlViewer_NCC.Size = new System.Drawing.Size(125, 37);
            this.btnXmlViewer_NCC.TabIndex = 108;
            this.btnXmlViewer_NCC.Text = "In File Xml";
            this.btnXmlViewer_NCC.UseVisualStyleBackColor = false;
            this.btnXmlViewer_NCC.Click += new System.EventHandler(this.btnXmlViewer_NCC_Click);
            // 
            // btn_Tim_NCC
            // 
            this.btn_Tim_NCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btn_Tim_NCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim_NCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim_NCC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Tim_NCC.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tim_NCC.Image")));
            this.btn_Tim_NCC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Tim_NCC.Location = new System.Drawing.Point(65, 160);
            this.btn_Tim_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Tim_NCC.Name = "btn_Tim_NCC";
            this.btn_Tim_NCC.Size = new System.Drawing.Size(159, 35);
            this.btn_Tim_NCC.TabIndex = 107;
            this.btn_Tim_NCC.Text = "Tìm theo mã";
            this.btn_Tim_NCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Tim_NCC.UseVisualStyleBackColor = false;
            this.btn_Tim_NCC.Click += new System.EventHandler(this.btn_Tim_NCC_Click);
            // 
            // btn_Renew_NCC
            // 
            this.btn_Renew_NCC.BackColor = System.Drawing.Color.Green;
            this.btn_Renew_NCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Renew_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Renew_NCC.ForeColor = System.Drawing.Color.White;
            this.btn_Renew_NCC.Location = new System.Drawing.Point(317, 158);
            this.btn_Renew_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Renew_NCC.Name = "btn_Renew_NCC";
            this.btn_Renew_NCC.Size = new System.Drawing.Size(121, 37);
            this.btn_Renew_NCC.TabIndex = 16;
            this.btn_Renew_NCC.Text = "Làm mới";
            this.btn_Renew_NCC.UseVisualStyleBackColor = false;
            this.btn_Renew_NCC.Click += new System.EventHandler(this.btn_Renew_NCC_Click);
            // 
            // btn_Xoa_NCC
            // 
            this.btn_Xoa_NCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Xoa_NCC.FlatAppearance.BorderSize = 0;
            this.btn_Xoa_NCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Xoa_NCC.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa_NCC.Location = new System.Drawing.Point(758, 158);
            this.btn_Xoa_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa_NCC.Name = "btn_Xoa_NCC";
            this.btn_Xoa_NCC.Size = new System.Drawing.Size(125, 37);
            this.btn_Xoa_NCC.TabIndex = 15;
            this.btn_Xoa_NCC.Text = "Xoá";
            this.btn_Xoa_NCC.UseVisualStyleBackColor = false;
            this.btn_Xoa_NCC.Click += new System.EventHandler(this.btn_Xoa_NCC_Click);
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaNCC.Location = new System.Drawing.Point(188, 43);
            this.txtMaNCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(161, 30);
            this.txtMaNCC.TabIndex = 14;
            // 
            // btn_Sua_NCC
            // 
            this.btn_Sua_NCC.BackColor = System.Drawing.Color.Teal;
            this.btn_Sua_NCC.FlatAppearance.BorderSize = 0;
            this.btn_Sua_NCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sua_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Sua_NCC.ForeColor = System.Drawing.Color.White;
            this.btn_Sua_NCC.Location = new System.Drawing.Point(615, 158);
            this.btn_Sua_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sua_NCC.Name = "btn_Sua_NCC";
            this.btn_Sua_NCC.Size = new System.Drawing.Size(125, 37);
            this.btn_Sua_NCC.TabIndex = 13;
            this.btn_Sua_NCC.Text = "Cập nhật";
            this.btn_Sua_NCC.UseVisualStyleBackColor = false;
            this.btn_Sua_NCC.Click += new System.EventHandler(this.btn_Sua_NCC_Click);
            // 
            // btn_Them_NCC
            // 
            this.btn_Them_NCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.btn_Them_NCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Them_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Them_NCC.ForeColor = System.Drawing.Color.White;
            this.btn_Them_NCC.Location = new System.Drawing.Point(464, 158);
            this.btn_Them_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Them_NCC.Name = "btn_Them_NCC";
            this.btn_Them_NCC.Size = new System.Drawing.Size(121, 37);
            this.btn_Them_NCC.TabIndex = 12;
            this.btn_Them_NCC.Text = "Thêm";
            this.btn_Them_NCC.UseVisualStyleBackColor = false;
            this.btn_Them_NCC.Click += new System.EventHandler(this.btn_Them_NCC_Click);
            // 
            // txtSDT_NCC
            // 
            this.txtSDT_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSDT_NCC.Location = new System.Drawing.Point(155, 95);
            this.txtSDT_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT_NCC.Name = "txtSDT_NCC";
            this.txtSDT_NCC.Size = new System.Drawing.Size(220, 30);
            this.txtSDT_NCC.TabIndex = 8;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenNCC.Location = new System.Drawing.Point(677, 38);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(220, 30);
            this.txtTenNCC.TabIndex = 7;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label25.Location = new System.Drawing.Point(17, 98);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(114, 22);
            this.label25.TabIndex = 2;
            this.label25.Text = "Số điện thoại";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label24.Location = new System.Drawing.Point(475, 43);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(146, 22);
            this.label24.TabIndex = 1;
            this.label24.Text = "Tên nhà cung cấp";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label23.Location = new System.Drawing.Point(17, 43);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(142, 22);
            this.label23.TabIndex = 0;
            this.label23.Text = "Mã nhà cung cấp";
            // 
            // tbcAdmin_NhanVien
            // 
            this.tbcAdmin_NhanVien.BackColor = System.Drawing.SystemColors.Control;
            this.tbcAdmin_NhanVien.Controls.Add(this.btn_ViewXML_NV);
            this.tbcAdmin_NhanVien.Controls.Add(this.btn_Tim_NV);
            this.tbcAdmin_NhanVien.Controls.Add(this.gbNhanVien);
            this.tbcAdmin_NhanVien.Controls.Add(this.btnRenewNhanVien);
            this.tbcAdmin_NhanVien.Controls.Add(this.btnThemNhanVIen);
            this.tbcAdmin_NhanVien.Controls.Add(this.txtMatKhauNV);
            this.tbcAdmin_NhanVien.Controls.Add(this.txtHoTenNV);
            this.tbcAdmin_NhanVien.Controls.Add(this.txtTenDangNhap);
            this.tbcAdmin_NhanVien.Controls.Add(this.txtMaNhanVien);
            this.tbcAdmin_NhanVien.Controls.Add(this.label21);
            this.tbcAdmin_NhanVien.Controls.Add(this.label20);
            this.tbcAdmin_NhanVien.Controls.Add(this.btnCapNhatNhanVien);
            this.tbcAdmin_NhanVien.Controls.Add(this.label19);
            this.tbcAdmin_NhanVien.Controls.Add(this.label18);
            this.tbcAdmin_NhanVien.Controls.Add(this.label8);
            this.tbcAdmin_NhanVien.Controls.Add(this.btnXoaNhanVien);
            this.tbcAdmin_NhanVien.Controls.Add(this.dgvNhanVien);
            this.tbcAdmin_NhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbcAdmin_NhanVien.Location = new System.Drawing.Point(4, 32);
            this.tbcAdmin_NhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.tbcAdmin_NhanVien.Name = "tbcAdmin_NhanVien";
            this.tbcAdmin_NhanVien.Padding = new System.Windows.Forms.Padding(4);
            this.tbcAdmin_NhanVien.Size = new System.Drawing.Size(992, 505);
            this.tbcAdmin_NhanVien.TabIndex = 1;
            this.tbcAdmin_NhanVien.Text = "Nhân Viên";
            // 
            // btn_ViewXML_NV
            // 
            this.btn_ViewXML_NV.BackColor = System.Drawing.Color.DarkGray;
            this.btn_ViewXML_NV.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_ViewXML_NV.ForeColor = System.Drawing.Color.White;
            this.btn_ViewXML_NV.Location = new System.Drawing.Point(775, 169);
            this.btn_ViewXML_NV.Name = "btn_ViewXML_NV";
            this.btn_ViewXML_NV.Size = new System.Drawing.Size(167, 37);
            this.btn_ViewXML_NV.TabIndex = 109;
            this.btn_ViewXML_NV.Text = "In File Xml";
            this.btn_ViewXML_NV.UseVisualStyleBackColor = false;
            this.btn_ViewXML_NV.Click += new System.EventHandler(this.btn_ViewXML_NV_Click);
            // 
            // btn_Tim_NV
            // 
            this.btn_Tim_NV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btn_Tim_NV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim_NV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim_NV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim_NV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Tim_NV.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tim_NV.Image")));
            this.btn_Tim_NV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Tim_NV.Location = new System.Drawing.Point(20, 240);
            this.btn_Tim_NV.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Tim_NV.Name = "btn_Tim_NV";
            this.btn_Tim_NV.Size = new System.Drawing.Size(159, 39);
            this.btn_Tim_NV.TabIndex = 108;
            this.btn_Tim_NV.Text = "Tìm theo mã";
            this.btn_Tim_NV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Tim_NV.UseVisualStyleBackColor = false;
            this.btn_Tim_NV.Click += new System.EventHandler(this.btn_Tim_NV_Click);
            // 
            // gbNhanVien
            // 
            this.gbNhanVien.Controls.Add(this.rdNhanVien);
            this.gbNhanVien.Controls.Add(this.rdAdmin);
            this.gbNhanVien.Location = new System.Drawing.Point(182, 126);
            this.gbNhanVien.Name = "gbNhanVien";
            this.gbNhanVien.Size = new System.Drawing.Size(274, 104);
            this.gbNhanVien.TabIndex = 61;
            this.gbNhanVien.TabStop = false;
            // 
            // rdNhanVien
            // 
            this.rdNhanVien.AutoSize = true;
            this.rdNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdNhanVien.Location = new System.Drawing.Point(17, 21);
            this.rdNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.rdNhanVien.Name = "rdNhanVien";
            this.rdNhanVien.Size = new System.Drawing.Size(194, 26);
            this.rdNhanVien.TabIndex = 55;
            this.rdNhanVien.TabStop = true;
            this.rdNhanVien.Text = "Nhân viên nhập hàng";
            this.rdNhanVien.UseVisualStyleBackColor = true;
            // 
            // rdAdmin
            // 
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdAdmin.Location = new System.Drawing.Point(17, 71);
            this.rdAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(84, 26);
            this.rdAdmin.TabIndex = 56;
            this.rdAdmin.TabStop = true;
            this.rdAdmin.Text = "Admin";
            this.rdAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRenewNhanVien
            // 
            this.btnRenewNhanVien.BackColor = System.Drawing.Color.Green;
            this.btnRenewNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenewNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenewNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenewNhanVien.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRenewNhanVien.Location = new System.Drawing.Point(211, 240);
            this.btnRenewNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnRenewNhanVien.Name = "btnRenewNhanVien";
            this.btnRenewNhanVien.Size = new System.Drawing.Size(156, 39);
            this.btnRenewNhanVien.TabIndex = 60;
            this.btnRenewNhanVien.Text = "Làm mới";
            this.btnRenewNhanVien.UseVisualStyleBackColor = false;
            this.btnRenewNhanVien.Click += new System.EventHandler(this.btnRenewNhanVien_Click);
            // 
            // btnThemNhanVIen
            // 
            this.btnThemNhanVIen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnThemNhanVIen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhanVIen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNhanVIen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhanVIen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThemNhanVIen.Location = new System.Drawing.Point(390, 240);
            this.btnThemNhanVIen.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemNhanVIen.Name = "btnThemNhanVIen";
            this.btnThemNhanVIen.Size = new System.Drawing.Size(193, 39);
            this.btnThemNhanVIen.TabIndex = 59;
            this.btnThemNhanVIen.Text = "Thêm nhân viên";
            this.btnThemNhanVIen.UseVisualStyleBackColor = false;
            this.btnThemNhanVIen.Click += new System.EventHandler(this.btnThemNhanVIen_Click);
            // 
            // txtMatKhauNV
            // 
            this.txtMatKhauNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMatKhauNV.Location = new System.Drawing.Point(671, 92);
            this.txtMatKhauNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhauNV.Name = "txtMatKhauNV";
            this.txtMatKhauNV.Size = new System.Drawing.Size(271, 30);
            this.txtMatKhauNV.TabIndex = 58;
            // 
            // txtHoTenNV
            // 
            this.txtHoTenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHoTenNV.Location = new System.Drawing.Point(671, 36);
            this.txtHoTenNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTenNV.Name = "txtHoTenNV";
            this.txtHoTenNV.Size = new System.Drawing.Size(271, 30);
            this.txtHoTenNV.TabIndex = 52;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(185, 89);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(271, 30);
            this.txtTenDangNhap.TabIndex = 50;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(185, 33);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(275, 30);
            this.txtMaNhanVien.TabIndex = 46;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label21.Location = new System.Drawing.Point(573, 96);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 22);
            this.label21.TabIndex = 57;
            this.label21.Text = "Mật Khẩu :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.Location = new System.Drawing.Point(35, 169);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 22);
            this.label20.TabIndex = 54;
            this.label20.Text = "Loại Nhân Viên :";
            // 
            // btnCapNhatNhanVien
            // 
            this.btnCapNhatNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.btnCapNhatNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatNhanVien.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCapNhatNhanVien.Location = new System.Drawing.Point(619, 240);
            this.btnCapNhatNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhatNhanVien.Name = "btnCapNhatNhanVien";
            this.btnCapNhatNhanVien.Size = new System.Drawing.Size(133, 39);
            this.btnCapNhatNhanVien.TabIndex = 53;
            this.btnCapNhatNhanVien.Text = "Cập nhật";
            this.btnCapNhatNhanVien.UseVisualStyleBackColor = false;
            this.btnCapNhatNhanVien.Click += new System.EventHandler(this.btnCapNhatNhanVien_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label19.Location = new System.Drawing.Point(573, 39);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 22);
            this.label19.TabIndex = 51;
            this.label19.Text = "Họ Tên :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label18.Location = new System.Drawing.Point(35, 98);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 22);
            this.label18.TabIndex = 49;
            this.label18.Text = "Tên Đăng Nhập :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(35, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 22);
            this.label8.TabIndex = 45;
            this.label8.Text = "Mã Nhân Viên : ";
            // 
            // btnXoaNhanVien
            // 
            this.btnXoaNhanVien.BackColor = System.Drawing.Color.Teal;
            this.btnXoaNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNhanVien.FlatAppearance.BorderSize = 0;
            this.btnXoaNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaNhanVien.Location = new System.Drawing.Point(775, 240);
            this.btnXoaNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaNhanVien.Name = "btnXoaNhanVien";
            this.btnXoaNhanVien.Size = new System.Drawing.Size(167, 39);
            this.btnXoaNhanVien.TabIndex = 44;
            this.btnXoaNhanVien.Text = "Xóa Nhân Viên";
            this.btnXoaNhanVien.UseVisualStyleBackColor = false;
            this.btnXoaNhanVien.Click += new System.EventHandler(this.btnXoaNhanVien_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvNhanVien.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(39, 309);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.Size = new System.Drawing.Size(903, 164);
            this.dgvNhanVien.TabIndex = 3;
            this.dgvNhanVien.SelectionChanged += new System.EventHandler(this.dgvNhanVien_SelectionChanged);
            // 
            // QuantriAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1062, 638);
            this.Controls.Add(this.tbcQuanTriAdmin);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClosed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuantriAdmin";
            this.Text = "Quanly_TaiKhoan";
            this.Load += new System.EventHandler(this.QuantriAdmin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.tbcQuanTriAdmin.ResumeLayout(false);
            this.tbcAdmin_Nhacungcap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDocGia)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tbcAdmin_NhanVien.ResumeLayout(false);
            this.tbcAdmin_NhanVien.PerformLayout();
            this.gbNhanVien.ResumeLayout(false);
            this.gbNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.TabControl tbcQuanTriAdmin;
        private System.Windows.Forms.TabPage tbcAdmin_Nhacungcap;
        private System.Windows.Forms.DataGridView dgvLoaiDocGia;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Button btn_Sua_NCC;
        private System.Windows.Forms.Button btn_Them_NCC;
        private System.Windows.Forms.TextBox txtSDT_NCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tbcAdmin_NhanVien;
        private System.Windows.Forms.TextBox txtMatKhauNV;
        private System.Windows.Forms.TextBox txtHoTenNV;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.RadioButton rdNhanVien;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCapNhatNhanVien;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXoaNhanVien;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btn_Xoa_NCC;
        private System.Windows.Forms.Button btnThemNhanVIen;
        private System.Windows.Forms.Button btn_Renew_NCC;
        private System.Windows.Forms.GroupBox gbNhanVien;
        private System.Windows.Forms.Button btnRenewNhanVien;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.Button btn_Tim_NCC;
        private System.Windows.Forms.Button btn_Tim_NV;
        private System.Windows.Forms.Button btnXmlViewer_NCC;
        private System.Windows.Forms.Button btn_ViewXML_NV;
    }
}