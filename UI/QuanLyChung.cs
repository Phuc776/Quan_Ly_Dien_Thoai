using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class QuanLyChung : Form
    {

        public QuanLyChung()
        {
            InitializeComponent();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NHÓM 7 \n\n Nguyễn Đỗ Hoàng Phúc 21115053120234 \n Phan Đình Yên 21115053120360 ");
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void ThongTinDangNhap()
        {

            lblHoTen.Text = "Họ tên: "; 
        }
        private void pnDanhMuc_Click(object sender, EventArgs e)
        {
            Quanly_DanhMuc nv = new Quanly_DanhMuc();
            nv.Show();
        }

        private void pnTaiKhoan_Click(object sender, EventArgs e)
        {
            Quanly_TaiKhoan nv = new Quanly_TaiKhoan();
            nv.Show();
        }

        private void pnPhieuNhap_Click(object sender, EventArgs e)
        {
            Quanly_PhieuNhap nv = new Quanly_PhieuNhap();
            nv.Show();
        }

        private void pnSanPham_Click(object sender, EventArgs e)
        {
            Quanly_DienThoai nv = new Quanly_DienThoai();
            nv.Show();
        }

    }
}
