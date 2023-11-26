using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Quan_Ly_Dien_Thoai.Controller
{
    internal class PhieuNhap
    {
        XDocument doc;
        XulyXML xuly  = new XulyXML();
        string path = "./PHIEUNHAP.xml";
        public bool CheckEmpty(string maPN, string soluong)
        {
            if(string.IsNullOrEmpty(maPN) || string.IsNullOrEmpty(soluong) || Int32.Parse(soluong) <=0 )
                return false;
            return true;
        }

        public int tim_Tongtien(string maHD)
        {
            int tongtien = 0;
            doc = XDocument.Load(path);
            var list = doc.Descendants("PHIEUNHAP");
            string group;
            foreach (XElement node in list)
            {
                group = node.Element("MAPN").Value;
                if (maHD == group)
                {
                    tongtien = Int32.Parse(node.Element("TongTienNhap").Value);
                }
            }
            return tongtien;
        }

        public void capNhatTongTien(string maPN, string soluong, string dongia)
        {
            int thanhtien = Int32.Parse(soluong) * Int32.Parse(dongia) + tim_Tongtien(maPN);
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\PHIEUNHAP.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/PHIEUNHAP[MAPN = '" + maPN + "']");
            if (node1 != null)
            {
                node1.ChildNodes[3].InnerText = thanhtien.ToString();
                doc1.Save(Application.StartupPath + "\\PHIEUNHAP.xml");
            }
        }

        public void themHD(string maPN, string ngayNhap, string maNCC, string TongTienNhap, string maDT, string soluongNhap, string giaNhap)
        {
            themCTHD(maPN, maDT, soluongNhap, giaNhap);
            string noidung =
                "<PHIEUNHAP>" +
                    "<MAPN>" + maPN + "</MAPN>" +
                    "<NGAYNHAPHANG>" + ngayNhap + "</NGAYNHAPHANG>" +
                    "<MANCC>" + maNCC + "</MANCC>" +
                    "<TongTienNhap>" + TongTienNhap + "</TongTienNhap>" +
                "</PHIEUNHAP>";
            xuly.Them("PHIEUNHAP.xml", noidung);
        }

        public void themCTHD(string maPN,string maDT, string soluongNhap, string giaNhap)
        {
            string noidung = "<CHITIETPHIEUNHAP>" +
                        "<MAPN>" + maPN + "</MAPN>" +
                        "<MADT>" + maDT + "</MADT>" +
                        "<SOLUONGNHAP>" + soluongNhap + "</SOLUONGNHAP>" +
                        "<GIANHAP>" + giaNhap + "</GIANHAP>" +
                        "</CHITIETPHIEUNHAP>";
            xuly.Them("CHITIETPHIEUNHAP.xml", noidung);
            capNhatTongTien(maPN, soluongNhap, giaNhap);
        }
        public Boolean checkIdenticalDienThoai(string maPN, string maDT)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = xuly.getXMLData("ChiTietHoaDon.xml");
                dt.DefaultView.RowFilter = "MAPN ='" + maPN + "' AND MADT ='" + maDT + "'";
                if (dt.DefaultView.Count > 0)
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool checkMaPN(string MaPN)
        {
            XmlTextReader reader = new XmlTextReader("PHIEUNHAP.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MAPN";
            reader.Close();
            int index = dv.Find(MaPN);
            if (index == -1)
            {
                return false;
            }
            return true;
        }

        public void UpdateTongTienNhap()
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

                MessageBox.Show("TongTienNhap updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating TongTienNhap: {ex.Message}");
            }
        }

    }
}
