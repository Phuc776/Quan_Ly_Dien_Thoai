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

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_PhieuNhap : Form
    {
        XulyXML xuly = new XulyXML();
        private bool drag = false;
        private Point dragCursor, dragForm;
        String[] colnames = { "MAPN", "NGAYNHAPHANG", "MANCC", "TongTienNhap" };
        Dictionary<string, string> columnTitleMap = new Dictionary<string, string>
        {
            { "MAPN", "ID" },
            { "NGAYNHAPHANG", "Date" },
            { "TongTienNhap", "Tổng Tiền Nhập" }
        };
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
            this.dgvChiTietPhieuNhap.Columns[0].Name = "Mã phiếu nhập";
            this.dgvChiTietPhieuNhap.Columns[1].Name = "Mã điện thoại";
            this.dgvChiTietPhieuNhap.Columns[2].Name = "Số lượng nhập";
            this.dgvChiTietPhieuNhap.Columns[3].Name = "Giá nhập";
        }
        private void HienThiPhieuNhap()
        {
            DataTable dt = new DataTable();
            UpdateTongTienNhap();
            dt = xuly.getXMLData("PHIEUNHAP.xml");
            changeIDtoName(dt);
            this.dgvPhieuNhap.DataSource = dt;
        }
        private void changeIDtoName(DataTable dt)
        {
            foreach (DataColumn column in dt.Columns)
            {
                string columnName = column.ColumnName;
                if (columnTitleMap.ContainsKey(columnName))
                {
                    column.ColumnName = columnTitleMap[columnName];
                }
            }
            Dictionary<string, string> providerDictionary = GetProviderDictionary("NHACUNGCAP.xml");

            if (dt.Columns.Contains("MANCC"))
            {
                DataColumn newColumn = new DataColumn("Tên nhà cung cấp", typeof(string));
                dt.Columns.Add(newColumn);
                foreach (DataRow row in dt.Rows)
                {
                    string mancc = row["MANCC"].ToString();
                    if (providerDictionary.ContainsKey(mancc))
                    {
                        row["Tên nhà cung cấp"] = providerDictionary[mancc];
                    }
                }
                dt.Columns.Remove("MANCC");
            }
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
        public void SearchAndDisplayData(string fileName, TextBox searchBox, string[] columnNames, DataGridView dataGridView, Dictionary<string, string> columnTitleMap)
        {
            string searchText = string.IsNullOrWhiteSpace(searchBox.Text) ? "0" : searchBox.Text.Trim();
            XmlTextReader reader = new XmlTextReader(fileName);
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            if (columnNames.Length > 0)
                dv.Sort = columnNames[0];

            reader.Close();
            int index = dv.Find(searchText.Trim());
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                searchBox.Focus();
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (string columnName in columnNames)
                {
                    string displayTitle = columnTitleMap.ContainsKey(columnName) ? columnTitleMap[columnName] : columnName;
                    dt.Columns.Add(displayTitle);
                }
                object[] list = new object[columnNames.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    list[i] = dv[index][columnNames[i]];
                }
                changeIDtoName(dt);
                dt.Rows.Add(list);
                dataGridView.DataSource = dt;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchAndDisplayData("PHIEUNHAP.xml", txtTimKiem, colnames, dgvPhieuNhap, columnTitleMap);
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
        public Dictionary<string, string> GetProviderDictionary(string file)
        {
            Dictionary<string, string> providerDictionary = new Dictionary<string, string>();
            string filePath = Application.StartupPath + "\\" + file;
            if (File.Exists(filePath))
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filePath);
                DataTable dataTable = dataSet.Tables["NHACUNGCAP"];
                foreach (DataRow row in dataTable.Rows)
                {
                    string mancc = row["MANCC"].ToString();
                    string tenncc = row["TENNCC"].ToString();
                    providerDictionary[mancc] = tenncc;
                }
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }
            return providerDictionary;
        }
        private void UpdateTongTienNhap()
        {
            try
            {
                string phieuNhapFilePath = "PHIEUNHAP.xml";
                string chiTietPhieuNhapFilePath = "CHITIETPHIEUNHAP.xml";

                XDocument phieuNhapDoc = XDocument.Load(phieuNhapFilePath);
                XDocument chiTietPhieuNhapDoc = XDocument.Load(chiTietPhieuNhapFilePath);

                var phieuNhapElements = phieuNhapDoc.Descendants("PHIEUNHAP");
                var chiTietPhieuNhapElements = chiTietPhieuNhapDoc.Descendants("CHITIETPHIEUNHAP");

                foreach (var phieuNhap in phieuNhapElements)
                {
                    int mapn = int.Parse(phieuNhap.Element("MAPN")?.Value ?? "0");
                    decimal tongTienNhap = 0;

                    // Find corresponding CHITIETPHIEUNHAP elements for the current MAPN
                    var matchingChiTietPhieuNhap = chiTietPhieuNhapElements
                        .Where(ct => int.Parse(ct.Element("MAPN")?.Value ?? "0") == mapn);

                    foreach (var chiTietPhieuNhap in matchingChiTietPhieuNhap)
                    {
                        int soluongNhap = int.Parse(chiTietPhieuNhap.Element("SOLUONGNHAP")?.Value ?? "0");
                        decimal gianhap = decimal.Parse(chiTietPhieuNhap.Element("GIANHAP")?.Value ?? "0");

                        // Calculate TongTienNhap for the current PHIEUNHAP
                        tongTienNhap += soluongNhap * gianhap;
                    }

                    // Update the TongTienNhap in PHIEUNHAP.xml
                    phieuNhap.Element("TongTienNhap").Value = tongTienNhap.ToString("F2");
                }
                phieuNhapDoc.Save(phieuNhapFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating TongTienNhap: {ex.Message}");
            }
        }
    }
}
