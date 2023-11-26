namespace Quan_Ly_Dien_Thoai.UI
{
    partial class ChiTiet_PhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTiet_PhieuNhap));
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNCC = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dptNgayNhapHang = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMaDT = new System.Windows.Forms.ComboBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.btn_ViewCTPN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(45, 423);
            this.dgvChiTietPhieuNhap.MultiSelect = false;
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.ReadOnly = true;
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.RowTemplate.Height = 24;
            this.dgvChiTietPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(1009, 251);
            this.dgvChiTietPhieuNhap.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.cbNCC);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.dptNgayNhapHang);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbMaDT);
            this.groupBox1.Controls.Add(this.txtGiaNhap);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(45, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 240);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cbNCC
            // 
            this.cbNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbNCC.FormattingEnabled = true;
            this.cbNCC.Location = new System.Drawing.Point(177, 73);
            this.cbNCC.Name = "cbNCC";
            this.cbNCC.Size = new System.Drawing.Size(356, 28);
            this.cbNCC.TabIndex = 23;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(821, 162);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(161, 45);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu đơn nhập";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dptNgayNhapHang
            // 
            this.dptNgayNhapHang.Enabled = false;
            this.dptNgayNhapHang.Location = new System.Drawing.Point(731, 36);
            this.dptNgayNhapHang.Margin = new System.Windows.Forms.Padding(4);
            this.dptNgayNhapHang.Name = "dptNgayNhapHang";
            this.dptNgayNhapHang.Size = new System.Drawing.Size(251, 22);
            this.dptNgayNhapHang.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(575, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ngày nhập hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Mã NCC:";
            // 
            // cbMaDT
            // 
            this.cbMaDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaDT.FormattingEnabled = true;
            this.cbMaDT.Location = new System.Drawing.Point(177, 114);
            this.cbMaDT.Name = "cbMaDT";
            this.cbMaDT.Size = new System.Drawing.Size(356, 28);
            this.cbMaDT.TabIndex = 14;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhap.Location = new System.Drawing.Point(731, 115);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(251, 27);
            this.txtGiaNhap.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(731, 73);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(251, 27);
            this.txtSoLuong.TabIndex = 5;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPN.Location = new System.Drawing.Point(177, 32);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(356, 27);
            this.txtMaPN.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(575, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giá nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(575, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số lượng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã phiếu nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(100)))), ((int)(((byte)(143)))));
            this.label1.Location = new System.Drawing.Point(421, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 41);
            this.label1.TabIndex = 24;
            this.label1.Text = "THÊM PHIẾU NHẬP";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(953, -1);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 41);
            this.button3.TabIndex = 65;
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
            this.btnClosed.Location = new System.Drawing.Point(1025, -3);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(49, 43);
            this.btnClosed.TabIndex = 64;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // btn_ViewCTPN
            // 
            this.btn_ViewCTPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btn_ViewCTPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ViewCTPN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewCTPN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ViewCTPN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ViewCTPN.Image = ((System.Drawing.Image)(resources.GetObject("btn_ViewCTPN.Image")));
            this.btn_ViewCTPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ViewCTPN.Location = new System.Drawing.Point(749, 112);
            this.btn_ViewCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ViewCTPN.Name = "btn_ViewCTPN";
            this.btn_ViewCTPN.Size = new System.Drawing.Size(278, 35);
            this.btn_ViewCTPN.TabIndex = 106;
            this.btn_ViewCTPN.Text = "Xem Phiếu nhập theo mã";
            this.btn_ViewCTPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ViewCTPN.UseVisualStyleBackColor = false;
            this.btn_ViewCTPN.Click += new System.EventHandler(this.btn_ViewCTPN_Click);
            // 
            // ChiTiet_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 701);
            this.Controls.Add(this.btn_ViewCTPN);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.dgvChiTietPhieuNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChiTiet_PhieuNhap";
            this.Text = "ChiTiet_PhieuNhap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChiTiet_PhieuNhap_FormClosed);
            this.Load += new System.EventHandler(this.ChiTiet_PhieuNhap_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChiTiet_PhieuNhap_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChiTiet_PhieuNhap_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChiTiet_PhieuNhap_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DateTimePicker dptNgayNhapHang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMaDT;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNCC;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.Button btn_ViewCTPN;
    }
}