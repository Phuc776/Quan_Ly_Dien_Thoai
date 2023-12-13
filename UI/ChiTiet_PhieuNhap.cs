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
using System.Xml;
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
        #region Hiển thị Chi tiết phiếu nhập
        private void viewCTPN()
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");

            DataTable table = new DataTable();
            table.Columns.Add("Mã phiếu nhập", typeof(int));
            table.Columns.Add("Mã điện thoại", typeof(int));
            table.Columns.Add("Số lượng nhập", typeof(int));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Tổng tiền", typeof(decimal));

            foreach (XElement element in doc.Descendants("CHITIETPHIEUNHAP"))
            {
                int mapn = Convert.ToInt32(element.Element("MAPN")?.Value);
                int madt = Convert.ToInt32(element.Element("MADT")?.Value);
                int soluongnhap = Convert.ToInt32(element.Element("SOLUONGNHAP")?.Value);
                decimal gianhap = Convert.ToDecimal(element.Element("GIANHAP")?.Value);

                table.Rows.Add(mapn, madt, soluongnhap, gianhap, soluongnhap * gianhap);
            }

            dgvChiTietPhieuNhap.DataSource = table;
        }
        #endregion
        #region  Tìm kiếm phiếu nhập theo mã
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


        private void btn_ViewCTPN_Click(object sender, EventArgs e)
        {
            HienThiCTPN(txtMaPN.Text);
        }
        #endregion
        #region Lưu phiếu nhập
        private void btnLuu_Click(object sender, EventArgs e)
        {
            XDocument chiTietPhieuNhapDoc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            XDocument phieuNhapDoc = XDocument.Load("PHIEUNHAP.xml");

            int mapn = int.Parse(txtMaPN.Text);
            string madt = cbMaDT.SelectedValue.ToString();
            // Kiểm tra xem có mã phiếu nhập và mã điện thoại nào trùng nhau không
            bool exists = chiTietPhieuNhapDoc.Descendants("CHITIETPHIEUNHAP")
                .Any(item =>
                    int.Parse(item.Element("MAPN")?.Value) == mapn &&
                    item.Element("MADT")?.Value == madt
                );

            if (exists)
            {
                MessageBox.Show("Mã phiếu nhập và mã điện thoại đã tồn tại trong chi tiết phiếu nhập. Vui lòng kiểm tra lại!");
                return;
            }
            DateTime ngayNhapHang = dptNgayNhapHang.Value;
            string mancc = cbNCC.SelectedValue.ToString();
            int soluongNhap = int.Parse(txtSoLuong.Text);
            decimal gianhap = decimal.Parse(txtGiaNhap.Text);
            bool mapnExists = phieuNhapDoc.Descendants("MAPN")
       .Any(m => int.Parse(m.Value) == mapn);
            if (mapnExists)
            {
                XElement chiTietPhieuNhapElement = new XElement("CHITIETPHIEUNHAP",
                    new XElement("MAPN", mapn),
                    new XElement("MADT", madt),
                    new XElement("SOLUONGNHAP", soluongNhap),
                    new XElement("GIANHAP", gianhap)
                );

                chiTietPhieuNhapDoc.Element("NewDataSet").Add(chiTietPhieuNhapElement);
                chiTietPhieuNhapDoc.Save("CHITIETPHIEUNHAP.xml");

                MessageBox.Show("Đã thêm!");
                
            }
            else
            {
                DialogResult result = MessageBox.Show("Phiếu nhập này chưa có, bạn muốn thêm mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thêm mới vào PHIEUNHAP.xml
                    XElement phieuNhapElement = new XElement("PHIEUNHAP",
                        new XElement("MAPN", mapn),
                        new XElement("NGAYNHAPHANG", ngayNhapHang.ToString("yyyy-MM-ddTHH:mm:sszzz")),
                        new XElement("MANCC", mancc));
                    phieuNhapDoc.Element("NewDataSet").Add(phieuNhapElement);
                    phieuNhapDoc.Save("PHIEUNHAP.xml");

                    // Thêm mới vào CHITIETPHIEUNHAP.xml
                    XElement chiTietPhieuNhapElement = new XElement("CHITIETPHIEUNHAP",
                        new XElement("MAPN", mapn),
                        new XElement("MADT", madt),
                        new XElement("SOLUONGNHAP", soluongNhap),
                        new XElement("GIANHAP", gianhap)
                    );
                    chiTietPhieuNhapDoc.Element("NewDataSet").Add(chiTietPhieuNhapElement);
                    chiTietPhieuNhapDoc.Save("CHITIETPHIEUNHAP.xml");
                    
                    MessageBox.Show("Đã thêm mới vào cả PHIEUNHAP và CHITIETPHIEUNHAP!");
                }
                else
                {
                    MessageBox.Show("Bạn đã hủy thêm mới!");
                    return;
                }
            }
            capNhatSoluongCon(madt, soluongNhap);
            viewCTPN();
        }
        #endregion

        private void ChiTiet_PhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Quanly_PhieuNhap frm = new Quanly_PhieuNhap();
            frm.Visible = true;
            this.Visible = false;
        }
        public void capNhatSoluongCon(string maSP, int soluong)
        {
            // tìm số lượng sản phẩm còn
            
            
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\DIENTHOAI.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/DIENTHOAI[MADT = '" + maSP + "']");
            if (node != null)
            {
                int soLuongHienCon = int.Parse(node.SelectSingleNode("SOLUONGHIENCON")?.InnerText ?? "0");
                int soLuongMoi = soLuongHienCon + soluong;
                node.SelectSingleNode("SOLUONGHIENCON").InnerText = soLuongMoi.ToString();
                doc1.Save(Application.StartupPath + "\\DIENTHOAI.xml");
            }
        }
    }
}
