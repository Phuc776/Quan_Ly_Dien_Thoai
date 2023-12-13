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
using System.Xml;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_DienThoai : Form
    {
        XulyXML xuly = new XulyXML();
        DienThoai dienthoai = new DienThoai();
        Danhmuc danhmuc = new Danhmuc();
        string[] colnames_elements = { "MADT", "TENDT", "SOLUONGHIENCON", "MADM" };
        string[] displays_elements = { "Mã điện thoại", "Tên điện thoại", "Số lượng hiện còn", "Mã danh mục" };
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
            cbDanhMuc.ValueMember = "MADM";
            cbDanhMuc.DisplayMember = "CombinedColumn";
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Hienthi();
        }
        private void Hienthi()
        {
            DataTable dtDienThoai = xuly.getXMLData("DIENTHOAI.xml");
            DataTable dtDanhMuc = xuly.getXMLData("DANHMUC.xml");

            // Kết hợp dữ liệu từ hai DataTable dựa trên cột chung (MADM)
            var query = from dienThoai in dtDienThoai.AsEnumerable()
                        join danhMuc in dtDanhMuc.AsEnumerable()
                        on dienThoai.Field<int>("MADM") equals danhMuc.Field<int>("MADM")
                        select new
                        {
                            MADT = dienThoai.Field<int>("MADT"),
                            TENDT = dienThoai.Field<string>("TENDT"),
                            SOLUONGHIENCON = dienThoai.Field<int>("SOLUONGHIENCON"),
                            MADM = dienThoai.Field<int>("MADM"),
                            TENDM = danhMuc.Field<string>("TENDM")
                        };

            // Tạo DataTable mới
            DataTable dtCombined = new DataTable();
            dtCombined.Columns.Add("MADT", typeof(int));
            dtCombined.Columns.Add("TENDT", typeof(string));
            dtCombined.Columns.Add("SOLUONGHIENCON", typeof(int));
            dtCombined.Columns.Add("MADM", typeof(int));
            dtCombined.Columns.Add("TENDM", typeof(string));

            // Thêm từng dòng vào DataTable mới
            foreach (var item in query)
            {
                dtCombined.Rows.Add(item.MADT, item.TENDT, item.SOLUONGHIENCON, item.MADM, item.TENDM);
            }
            dienthoai.ChangeColumnDienThoai(dtCombined);
            // Hiển thị dữ liệu trong DataGridView
            dgvSanPham.DataSource = dtCombined;
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
            if (dienthoai.checkMaDT(txtMaDienThoai.Text) == true)
                MessageBox.Show("Mã điện thoại tồn tại");
            else
            {
                dienthoai.AddDT(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, cbDanhMuc.SelectedValue.ToString());
                MessageBox.Show("Đã thêm");
                Hienthi();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            dienthoai.EditDT(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, cbDanhMuc.SelectedValue.ToString());
            MessageBox.Show("Đã sửa");
            Hienthi();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (timCTPNtheoDT(txtMaDienThoai.Text))
            {
                MessageBox.Show("Bạn đã nhập mặt hàng này rồi. Không thể xoá!");
                return;
            } 
            dienthoai.DeleteDT(txtMaDienThoai.Text);
            MessageBox.Show("Đã xóa");
            Hienthi();
        }
        private bool timCTPNtheoDT(string maDT)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\CHITIETPHIEUNHAP.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/CHITIETPHIEUNHAP[MADT = '" + maDT + "']");
            if (node != null)
            {
                return true;
            }
            return false;
        }
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            dienthoai.TimDienThoaiTheoMa(txtMaDienThoai.Text, dgvSanPham);
        }

        private void btn_Renew_Click(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void btnXmlViewer_Click(object sender, EventArgs e)
        {
            xuly.GenerateHTMLFromXML1("DIENTHOAI.xml", "DIENTHOAI", colnames_elements,displays_elements, "DIENTHOAI.html", "Điện Thoại");
        }

        private void dgvRowSelected()
        {
            if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index >= 0)
            {
                int d = dgvSanPham.CurrentRow.Index;
                txtMaDienThoai.Text = dgvSanPham.Rows[d].Cells[0].Value?.ToString() ;
                txtTenDienThoai.Text = dgvSanPham.Rows[d].Cells[1].Value?.ToString() ;
                txtSoLuong.Text = dgvSanPham.Rows[d].Cells[2].Value?.ToString() ;
                cbDanhMuc.SelectedValue = dgvSanPham.Rows[d].Cells[3].Value?.ToString() ;
            }
        }
    }
}
