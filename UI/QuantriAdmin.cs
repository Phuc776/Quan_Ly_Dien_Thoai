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
using Quan_Ly_Dien_Thoai.App_code;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class QuantriAdmin : Form
    {
        XulyXML xuly = new XulyXML();
        NhanVien nhanvien = new NhanVien();
        NCC NCC = new NCC();
        String[] colnames_elements_NCC = { "MANCC", "TENNCC", "SDT" };
        String[] colnames_elements_NV = { "maNV", "tenNV", "username", "password", "loainv" };
        Dictionary<string, string> columnTitleMap_NCC = new Dictionary<string, string>
        {
            { "MANCC", "ID" },
            { "TENNCC", "Name" },
            { "SDT", "Phone Number" }
        };
        Dictionary<string, string> columnTitleMap_NV = new Dictionary<string, string>
        {
            { "maNV", "ID" },
            { "tenNV", "Name" },
            { "username", "Username" },
            { "password", "PassWord" },
            { "loainv", "Loại nhân viên" }
        };
        public QuantriAdmin()
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
        private void QuantriAdmin_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HienThiNCC();
            HienThiNhanVien();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void HienThiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = xuly.getXMLData("NHANVIEN.xml");
            foreach (DataColumn column in dt.Columns)
            {
                string columnName = column.ColumnName;
                if (columnTitleMap_NV.ContainsKey(columnName))
                {
                    column.ColumnName = columnTitleMap_NV[columnName];
                }
            }
            this.dgvNhanVien.DataSource = dt;
        }

        public void HienThiNCC()
        {
            DataTable dt = new DataTable();
            dt = xuly.getXMLData("NHACUNGCAP.xml");
            foreach (DataColumn column in dt.Columns)
            {
                string columnName = column.ColumnName;
                if (columnTitleMap_NCC.ContainsKey(columnName))
                {
                    column.ColumnName = columnTitleMap_NCC[columnName];
                }
            }
            this.dgvNCC.DataSource = dt;
        }

        private void btn_Renew_NCC_Click(object sender, EventArgs e)
        {
            HienThiNCC();
        }

        private void btn_Them_NCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (NCC.checkMaNhanVien(txtMaNCC.Text) == true)
                    MessageBox.Show("Mã danh mục đã tồn tại");
                else
                {
                    NCC.AddNCC(txtMaNCC.Text, txtTenNCC.Text, txtSDT_NCC.Text);
                    MessageBox.Show("Đã thêm");
                    HienThiNCC();
                };
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btn_Sua_NCC_Click(object sender, EventArgs e)
        {
            try
            {
                NCC.EditNCC(txtMaNCC.Text, txtTenNCC.Text, txtSDT_NCC.Text);
                MessageBox.Show("Đã sửa");
                HienThiNCC();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btn_Xoa_NCC_Click(object sender, EventArgs e)
        {
            try
            {
                NCC.DeleteNCC(txtMaNCC.Text);
                MessageBox.Show("Đã xóa");
                HienThiNCC();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private String LoaiNV()
        {
            try
            {
                if(rdAdmin.Checked)
                {
                    return "0";
                }
                if(rdNhanVien.Checked)
                {
                    return "1";
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
            return "1";
        }
        private void btnRenewNhanVien_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void btnThemNhanVIen_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhanvien.checkMaNhanVien(txtMaNhanVien.Text) == true)
                    MessageBox.Show("Mã nhân viên đã tồn tại");
                else
                {
                    nhanvien.AddNhanVien(txtMaNhanVien.Text, txtHoTenNV.Text, txtTenDangNhap.Text, txtMatKhauNV.Text, this.LoaiNV());
                    MessageBox.Show("Đã thêm");
                    HienThiNhanVien();
                };
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btnCapNhatNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.EditNhanVien(txtMaNhanVien.Text, txtHoTenNV.Text, txtTenDangNhap.Text, txtMatKhauNV.Text, this.LoaiNV());
                MessageBox.Show("Đã sửa");
                HienThiNhanVien();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.DeleteNhanVien(txtMaNhanVien.Text);
                MessageBox.Show("Đã xóa");
                HienThiNhanVien();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow != null && dgvNCC.CurrentRow.Index >= 0)
            {
                int d = dgvNCC.CurrentRow.Index;
                txtMaNCC.Text = dgvNCC.Rows[d].Cells[0].Value?.ToString() ?? "";
                txtTenNCC.Text = dgvNCC.Rows[d].Cells[1].Value?.ToString() ?? "";
                txtSDT_NCC.Text = dgvNCC.Rows[d].Cells[2].Value?.ToString() ?? "";
            }
        }

        private void btn_Tim_NCC_Click(object sender, EventArgs e)
        {
            xuly.SearchAndDisplayData("NHACUNGCAP.xml", txtMaNCC, colnames_elements_NCC, dgvNCC, columnTitleMap_NCC);
        }

        private void btn_Tim_NV_Click(object sender, EventArgs e)
        {
            xuly.SearchAndDisplayData("NHANVIEN.xml", txtMaNhanVien, colnames_elements_NV, dgvNhanVien, columnTitleMap_NV);
        }

        private void btn_ViewXML_NV_Click(object sender, EventArgs e)
        {
            xuly.GenerateHTMLFromXML("NHANVIEN.xml", "NHANVIEN", colnames_elements_NV, "NHANVIEN.html", "Danh sách nhân viên");
        }

        private void btnXmlViewer_NCC_Click(object sender, EventArgs e)
        {
            xuly.GenerateHTMLFromXML("NHACUNGCAP.xml", "NHACUNGCAP", colnames_elements_NCC, "NHACUNGCAP.html", "Danh sách nhà cung cấp");
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Index >= 0)
            {
                int d = dgvNhanVien.CurrentRow.Index;
                txtMaNhanVien.Text = dgvNhanVien.Rows[d].Cells[0].Value?.ToString() ?? "";
                txtHoTenNV.Text = dgvNhanVien.Rows[d].Cells[1].Value?.ToString() ?? "";
                txtTenDangNhap.Text = dgvNhanVien.Rows[d].Cells[2].Value?.ToString() ?? "";
                txtMatKhauNV.Text = dgvNhanVien.Rows[d].Cells[3].Value?.ToString() ?? "";
                if (dgvNhanVien.Rows[d].Cells[4].Value.ToString() == "0")
                {
                    rdAdmin.Checked = true;
                }
                if (dgvNhanVien.Rows[d].Cells[4].Value.ToString() == "1")
                {
                    rdNhanVien.Checked = true;
                }
                if (dgvNhanVien.Rows[d].Cells[4].Value == null)
                {
                    rdAdmin.Checked = false;
                    rdNhanVien.Checked = false;
                }
            }
        }

    }
}
