using Quan_Ly_Dien_Thoai.App_code;
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
using System.Xml.Linq;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class ChiTiet_PhieuNhap : Form
    {
        XulyXML xuly = new XulyXML();
        private bool drag = false;
        private Point dragCursor, dragForm;
        NCC ncc = new NCC();
        DienThoai dienThoai = new DienThoai();
        public ChiTiet_PhieuNhap()
        {
            InitializeComponent();
        }

        private void ChiTiet_PhieuNhap_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void ChiTiet_PhieuNhap_MouseMove(object sender, MouseEventArgs e)
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

        private void ChiTiet_PhieuNhap_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTiet_PhieuNhap_Load(object sender, EventArgs e)
        {
            cbNCC.DataSource = ncc.LoadNCC();
            cbNCC.ValueMember = "MANCC";
            cbNCC.DisplayMember = "CombinedColumn";
            cbMaDT.DataSource = dienThoai.LoadDT();
            cbMaDT.ValueMember = "MADT";
            cbMaDT.DisplayMember = "CombinedColumn";
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            viewCTPN();
        }
        private void viewCTPN()
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");

            DataTable table = new DataTable();
            table.Columns.Add("MAPN", typeof(int));
            table.Columns.Add("MADT", typeof(int));
            table.Columns.Add("SOLUONGNHAP", typeof(int));
            table.Columns.Add("GIANHAP", typeof(decimal));

            foreach (XElement element in doc.Descendants("CHITIETPHIEUNHAP"))
            {
                int mapn = Convert.ToInt32(element.Element("MAPN")?.Value ?? "0");
                int madt = Convert.ToInt32(element.Element("MADT")?.Value ?? "0");
                int soluongnhap = Convert.ToInt32(element.Element("SOLUONGNHAP")?.Value ?? "0");
                decimal gianhap = Convert.ToDecimal(element.Element("GIANHAP")?.Value ?? "0");

                table.Rows.Add(mapn, madt, soluongnhap, gianhap);
            }

            dgvChiTietPhieuNhap.DataSource = table;
        }
        private void btn_ViewCTPN_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            

            DataTable table = new DataTable();
            table.Columns.Add("MAPN", typeof(int));
            table.Columns.Add("MADT", typeof(int));
            table.Columns.Add("SOLUONGNHAP", typeof(int));
            table.Columns.Add("GIANHAP", typeof(decimal));

            bool applyFilter = !string.IsNullOrWhiteSpace(txtMaPN.Text);
            int filterMaPN = applyFilter ? int.Parse(txtMaPN.Text) : 0;

            foreach (XElement element in doc.Descendants("CHITIETPHIEUNHAP"))
            {
                int mapn = Convert.ToInt32(element.Element("MAPN")?.Value ?? "0");
                int madt = Convert.ToInt32(element.Element("MADT")?.Value ?? "0");
                int soluongnhap = Convert.ToInt32(element.Element("SOLUONGNHAP")?.Value ?? "0");
                decimal gianhap = Convert.ToDecimal(element.Element("GIANHAP")?.Value ?? "0");

                // Check if txtMaPN has data and apply filter, or load all data
                if (!applyFilter || mapn == filterMaPN)
                {
                    table.Rows.Add(mapn, madt, soluongnhap, gianhap);
                }
            }

            dgvChiTietPhieuNhap.DataSource = table;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            XDocument phieuNhapDoc = XDocument.Load("PHIEUNHAP.xml");
            XDocument chiTietPhieuNhapDoc = XDocument.Load("CHITIETPHIEUNHAP.xml");

            int mapn = int.Parse(txtMaPN.Text);
            DateTime ngayNhapHang = dptNgayNhapHang.Value;
            string mancc = cbNCC.SelectedValue.ToString();
            int soluongNhap = int.Parse(txtSoLuong.Text);
            string madt = cbMaDT.SelectedValue.ToString();
            decimal gianhap = decimal.Parse(txtGiaNhap.Text);
            decimal tongTienNhap = soluongNhap * gianhap;

            bool mapnExists = phieuNhapDoc.Descendants("MAPN")
            .Any(m => int.Parse(m.Value) == mapn);

            if (mapnExists)
            {
                MessageBox.Show("MAPN already exists in PHIEUNHAP.xml!");
                return;
            }

            bool madtExists = chiTietPhieuNhapDoc.Descendants("MADT")
                .Any(m => m.Value == madt);

            if (madtExists)
            {
                MessageBox.Show("MADT already exists in CHITIETPHIEUNHAP.xml!");
                return;
            }

            XElement phieuNhapElement = new XElement("PHIEUNHAP",
            new XElement("MAPN", mapn),
            new XElement("NGAYNHAPHANG", ngayNhapHang.ToString("yyyy-MM-ddTHH:mm:sszzz")),
            new XElement("MANCC", mancc),
            new XElement("TongTienNhap", tongTienNhap.ToString("F2"))
        );

            // Append the new PHIEUNHAP element to the PHIEUNHAP.xml file
            phieuNhapDoc.Element("NewDataSet").Add(phieuNhapElement);
            phieuNhapDoc.Save("PHIEUNHAP.xml");

            // Create CHITIETPHIEUNHAP element
            XElement chiTietPhieuNhapElement = new XElement("CHITIETPHIEUNHAP",
                new XElement("MAPN", mapn),
                new XElement("MADT", madt),
                new XElement("SOLUONGNHAP", soluongNhap),
                new XElement("GIANHAP", gianhap)
            );

            // Append the new CHITIETPHIEUNHAP element to the CHITIETPHIEUNHAP.xml file
            chiTietPhieuNhapDoc.Element("NewDataSet").Add(chiTietPhieuNhapElement);
            chiTietPhieuNhapDoc.Save("CHITIETPHIEUNHAP.xml");

            MessageBox.Show("Phieu nhap da duoc them thanh cong!");
        }

        

        private void ChiTiet_PhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Quanly_PhieuNhap frm = new Quanly_PhieuNhap();
            frm.Visible = true;
            this.Visible = false;
        }

    }
}
