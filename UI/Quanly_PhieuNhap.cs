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
using System.Xml.Linq;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_PhieuNhap : Form
    {
        XulyXML xuly = new XulyXML();
        private bool drag = false;
        private Point dragCursor, dragForm;
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
        private void initdgvCTPN()
        {
            this.dgvChiTietPhieuNhap.ColumnCount = 4;
            this.dgvChiTietPhieuNhap.Columns[0].Name = "MAPN";
            this.dgvChiTietPhieuNhap.Columns[1].Name = "MADT";
            this.dgvChiTietPhieuNhap.Columns[2].Name = "SOLUONGNHAP";
            this.dgvChiTietPhieuNhap.Columns[3].Name = "GIANHAP";
        }
        private void HienThiPhieuNhap()
        {
            DataTable dt = new DataTable();
            dt = xuly.getXMLData("PHIEUNHAP.xml");
            this.dgvPhieuNhap.DataSource = dt;
        }
        private void HienThiCTPN(string maPhieu)
        {
            initdgvCTPN();
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            var list = doc.Descendants("CHITIETPHIEUNHAP");
            string maPN, maDT, SoLuongNhap, GiaNhap;
            this.dgvChiTietPhieuNhap.Rows.Clear();
            foreach (XElement node in list)
            {
                maPN = node.Element("MAPN").Value.ToString();
                if (maPN == maPhieu)
                {
                    maDT = node.Element("MADT").Value;
                    SoLuongNhap = node.Element("SOLUONGNHAP").Value;
                    GiaNhap = node.Element("GIANHAP").Value;
                    this.dgvChiTietPhieuNhap.Rows.Add(maPN, maDT, SoLuongNhap, GiaNhap);
                }
            }
        }
        private void Quanly_PhieuNhap_Load(object sender, EventArgs e)
        {
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HienThiPhieuNhap();
            initdgvCTPN();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String[] colnames = { "MAPN", "NGAYNHAPHANG", "MANCC", "TongTienNhap" };
            xuly.SearchAndDisplayData("PHIEUNHAP.xml", txtTimKiem, colnames, dgvPhieuNhap);
        }

        private void btnPrintXML_Click(object sender, EventArgs e)
        {
            string[] elements = { "MAPN", "MADT", "SOLUONGNHAP", "GIANHAP" };
            xuly.GenerateHTMLFromXML("CHITIETPHIEUNHAP.xml", "CHITIETPHIEUNHAP", elements, "CHITIETPHIEUNHAP.html", "Chi Tiết Phiếu Nhập");
        }

        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null && dgvPhieuNhap.CurrentRow.Index >= 0)
            {
                int d = dgvPhieuNhap.CurrentRow.Index;
                string maPN = dgvPhieuNhap.Rows[d].Cells[0].Value?.ToString() ?? "";
                HienThiCTPN(maPN);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            HienThiPhieuNhap();
        }


    }
}
