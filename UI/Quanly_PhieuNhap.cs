using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using Quan_Ly_Dien_Thoai.Controller;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_PhieuNhap : Form
    {
        XulyXML xuly = new XulyXML();
        PhieuNhap phieunhap = new PhieuNhap();
        private bool drag = false;
        private Point dragCursor, dragForm;
        string[] colnames = { "MAPN", "NGAYNHAPHANG", "MANCC", "TONGTIEN" };
        public Quanly_PhieuNhap()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Quanly_PhieuNhap_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void Quanly_PhieuNhap_MouseMove(object sender, MouseEventArgs e)
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

        private void Quanly_PhieuNhap_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            ChiTiet_PhieuNhap frm = new ChiTiet_PhieuNhap();
            frm.Show();
            this.Visible = false;
        }
        private void HienThiPhieuNhap()
        {
            XDocument doc = XDocument.Load("PHIEUNHAP.xml");
            var list = doc.Descendants("PHIEUNHAP");

            DataTable table = new DataTable();
            table.Columns.Add("Mã phiếu nhập", typeof(int));
            table.Columns.Add("Mã nhà cung cấp", typeof(int));
            table.Columns.Add("Ngày nhập", typeof(DateTime));
            table.Columns.Add("Thành tiền", typeof(decimal));

            foreach (XElement node in list)
            {
                int mapn = Convert.ToInt32(node.Element("MAPN")?.Value);
                int mancc = Convert.ToInt32(node.Element("MANCC")?.Value);
                DateTime ngayNhap = Convert.ToDateTime(node.Element("NGAYNHAPHANG")?.Value);
                decimal thanhTien = phieunhap.TinhThanhTien(mapn);
                table.Rows.Add(mapn, mancc, ngayNhap, thanhTien);
            }
            dgvPhieuNhap.DataSource = table;
        }

        
        private void HienThiCTPN(string maPhieu)
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            var list = doc.Descendants("CHITIETPHIEUNHAP");
            DataTable table = new DataTable();
            table.Columns.Add("Mã phiếu nhập", typeof(int));
            table.Columns.Add("Mã điện thoại", typeof(int));
            table.Columns.Add("Số lượng nhập", typeof(int));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Tổng tiền", typeof(decimal));

            foreach (XElement node in list)
            {
                string maPN = node.Element("MAPN").Value.ToString();
                if (maPN == maPhieu)
                {
                    int mapn = Convert.ToInt32(node.Element("MAPN")?.Value);
                    int madt = Convert.ToInt32(node.Element("MADT")?.Value);
                    int soluongnhap = Convert.ToInt32(node.Element("SOLUONGNHAP")?.Value);
                    decimal gianhap = Convert.ToDecimal(node.Element("GIANHAP")?.Value);

                    table.Rows.Add(mapn, madt, soluongnhap, gianhap, soluongnhap * gianhap);
                }
            }
            dgvChiTietPhieuNhap.DataSource = table;
        }
        private void Quanly_PhieuNhap_Load(object sender, EventArgs e)
        {
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HienThiPhieuNhap();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiCTPN(txtTimKiem.Text);
        }

        private void btnPrintXML_Click(object sender, EventArgs e)
        {
            int d = dgvPhieuNhap.CurrentRow.Index;
            string maPN = dgvPhieuNhap.Rows[d].Cells[0].Value?.ToString();
            phieunhap.InPhieuNhap(maPN, "PHIEUNHAP.html");
        }

        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null && dgvPhieuNhap.CurrentRow.Index >= 0)
            {
                int d = dgvPhieuNhap.CurrentRow.Index;
                string maPN = dgvPhieuNhap.Rows[d].Cells[0].Value?.ToString();
                HienThiCTPN(maPN);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            HienThiPhieuNhap();
        }
        
        
    }
}
