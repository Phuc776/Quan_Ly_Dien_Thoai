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
using Quan_Ly_Dien_Thoai.Controller;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_DienThoai : Form
    {
        XulyXML xuly = new XulyXML();
        DienThoai dt = new DienThoai();
        Danhmuc danhmuc = new Danhmuc();
        string[] colnames_elements = { "MADT", "TENDT", "SOLUONGHIENCON", "MaDM" };
        Dictionary<string, string> columnTitleMap = new Dictionary<string, string>
        {
            { "MADT", "ID" },
            { "TENDT", "Name" },
            { "SOLUONGHIENCON", "Quantity" },
            { "MaDM", "CategoryID" }
        };
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
            cbDanhMuc.DataSource = danhmuc.LoadDanhMuc();
            cbDanhMuc.ValueMember = "MaDM";
            cbDanhMuc.DisplayMember = "CombinedColumn";
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Hienthi();
        }
        private void Hienthi()
        {
            DataTable dt = new DataTable();
            dt = xuly.getXMLData("DIENTHOAI.xml");
            foreach (DataColumn column in dt.Columns)
            {
                string columnName = column.ColumnName;
                if (columnTitleMap.ContainsKey(columnName))
                {
                    column.ColumnName = columnTitleMap[columnName];
                }
            }
            dgvSanPham.DataSource = dt;
            //dgvSanPham.Columns["CombinedColumn"].Visible = false;
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (dt.checkMaDT(txtMaDienThoai.Text) == true)
                MessageBox.Show("Mã điện thoại tồn tại");
            else
            {
                dt.AddDT(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, cbDanhMuc.SelectedValue.ToString());
                MessageBox.Show("Đã thêm");
                Hienthi();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            dt.EditDT(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, cbDanhMuc.SelectedValue.ToString());
            MessageBox.Show("Đã sửa");
            Hienthi();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            dt.DeleteDT(txtMaDienThoai.Text);
            MessageBox.Show("Đã xóa");
            Hienthi();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            xuly.SearchAndDisplayData("DIENTHOAI.xml", txtMaDienThoai, colnames_elements, dgvSanPham, columnTitleMap);
        }

        private void btn_Renew_Click(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void btnXmlViewer_Click(object sender, EventArgs e)
        {
            xuly.GenerateHTMLFromXML("DIENTHOAI.xml", "DIENTHOAI", colnames_elements, "DIENTHOAI.html", "Điện Thoại");
        }

        private void dgvRowSelected()
        {
            if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index >= 0)
            {
                int d = dgvSanPham.CurrentRow.Index;
                txtMaDienThoai.Text = dgvSanPham.Rows[d].Cells[0].Value?.ToString() ?? "";
                txtTenDienThoai.Text = dgvSanPham.Rows[d].Cells[1].Value?.ToString() ?? "";
                txtSoLuong.Text = dgvSanPham.Rows[d].Cells[2].Value?.ToString() ?? "";
                cbDanhMuc.SelectedValue = dgvSanPham.Rows[d].Cells[3].Value?.ToString() ?? "";
            }
        }
    }
}
