using Quan_Ly_Dien_Thoai.App_code;
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
    public partial class Quanly_DienThoai : Form
    {
        public Quanly_DienThoai()
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
        private void Quanly_SanPham_Load(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String sql = "select * from DIENTHOAI";
            this.dgvSanPham.DataSource = xuly.getTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String sql = "SELECT * FROM DIENTHOAI";
            List<string> conditions = new List<string>();

            String maDT = txtMaDienThoai.Text.Trim();
            String tenDT = txtTenDienThoai.Text.Trim();
            String soLuong = txtSoLuong.Text.Trim();
            String maDM = cbDanhMuc.Text.Trim();


            if (!String.IsNullOrEmpty(maDT))
            {
                conditions.Add("MADT = '" + maDT + "'");
            }
            if (!String.IsNullOrEmpty(tenDT))
            {
                conditions.Add("TENDT = '" + tenDT + "'");
            }
            if (!String.IsNullOrEmpty(soLuong))
            {
                conditions.Add("SOLUONGHIENCON = '" + soLuong + "'");
            }
            if (!String.IsNullOrEmpty(maDM))
            {
                conditions.Add("MaDM = '" + maDM + "'");
            }

            if (conditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", conditions);
            }

            this.dgvSanPham.DataSource = xuly.getTable(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDT = txtMaDienThoai.Text.Trim();
            String tenDT = txtTenDienThoai.Text.Trim();
            String soLuong = txtSoLuong.Text.Trim();
            String maDM = cbDanhMuc.Text.Trim();

            String sql = "Insert into [DIENTHOAI] ([MADT], [TENDT], [SOLUONGHIENCON], [MaDM]) " +
                "Values ( " + maDT + " , "+ tenDT +" , "+ soLuong + " , "+ maDM +" )";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDT = txtMaDienThoai.Text.Trim();
            String tenDT = txtTenDienThoai.Text.Trim();
            String soLuong = txtSoLuong.Text.Trim();
            String maDM = cbDanhMuc.Text.Trim();

            String sql = "Update [DIENTHOAI] " +
                "SET [MADT] = '" + maDT + "', [TENDT] = '" + tenDT + "' " +
                " [SOLUONGHIENCON] = '" + soLuong + "', [MaDM] = '" + maDM + "' " +
                "WHERE  [MaDM] = '" + maDM + "'";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDT = txtMaDienThoai.Text.Trim();


            String sql = "DELETE [DIENTHOAI] " +
                "WHERE  [MaDT] = '" + maDT + "'";
        }

        private void btnXmlPrinter_Click(object sender, EventArgs e)
        {

        }

        private void btnViewWeb_Click(object sender, EventArgs e)
        {

        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            dgvRowSelected();
        }

        private void dgvRowSelected()
        {
            int d = dgvSanPham.CurrentRow.Index;
            txtMaDienThoai.Text = dgvSanPham.Rows[d].Cells[0].Value.ToString();
            txtTenDienThoai.Text = dgvSanPham.Rows[d].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[d].Cells[2].Value.ToString();
        }
    }
}
