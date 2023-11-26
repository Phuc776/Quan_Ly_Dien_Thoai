using Quan_Ly_Dien_Thoai.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class QuanLy : Form
    {
        public static string tenDN = "";
        public static string quyen = "";
        public QuanLy()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool drag = false;
        private Point dragCursor, dragForm;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int wid = SystemInformation.VirtualScreen.Width;
            int hei = SystemInformation.VirtualScreen.Height;
            if (drag)
            {
                // Phải using System.Drawing;
                Point change = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Point newpos = Point.Add(dragForm, new Size(change));
                this.Location = newpos;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất tài khoản?", "Đăng Xuất", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Application.Restart();
            }
            
        }

        private void btnQuantri_Click(object sender, EventArgs e)
        {
            QuantriAdmin frmquantri = new QuantriAdmin();
            frmquantri.Show();
        }

        private void btnDienthoai_Click(object sender, EventArgs e)
        {
            Quanly_DienThoai frmquanlydt = new Quanly_DienThoai();
            frmquanlydt.Show();
        }

        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            Quanly_DanhMuc quanly_DanhMuc = new Quanly_DanhMuc();
            quanly_DanhMuc.Show();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            Quanly_PhieuNhap quanly_PhieuNhap = new Quanly_PhieuNhap();
            quanly_PhieuNhap.Show();
        }

        private void btnSaoluu_Click(object sender, EventArgs e)
        {
            SaoLuu_Phuchoi saoLuu_Phuchoi = new SaoLuu_Phuchoi();
            saoLuu_Phuchoi.Show();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            ktQuyenDangNhap();
        }

        public void ktQuyenDangNhap()
        {
            if (quyen.Equals("0"))
            {
                lblQuyen.Text += "Quản Trị Viên";
            }
            else
            {
                lblQuyen.Text += "Nhân Viên";
                btnQuantri.Visible = false;
            }
            ThongTinDangNhap();
        }

        private void ThongTinDangNhap()
        {
            lblHoTen.Text += tenDN;
        }
    }
}
