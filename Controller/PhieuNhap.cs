using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        XulyXML xuly = new XulyXML();
        public bool CheckEmpty(string maPN, string soluong)
        {
            if (string.IsNullOrEmpty(maPN) || string.IsNullOrEmpty(soluong) || Int32.Parse(soluong) <= 0)
                return false;
            return true;
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
            catch (Exception)
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
        public string timTenNCC(string maNCC)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("NHACUNGCAP.xml");
            XmlNode nccNode = doc.SelectSingleNode("NewDataSet/NHACUNGCAP[MANCC = '" + maNCC + "']");
            if (nccNode != null)
            {
                XmlNode tenNCCNode = nccNode.SelectSingleNode("TENNCC");
                return tenNCCNode.InnerText;
            }
            // Trả về chuỗi trống nếu không tìm thấy hoặc có lỗi
            return "";
        }
        public string timTenDT(string maDT)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DIENTHOAI.xml");
            XmlNode nccNode = doc.SelectSingleNode("NewDataSet/DIENTHOAI[MADT = '" + maDT + "']");
            if (nccNode != null)
            {
                XmlNode tenNCCNode = nccNode.SelectSingleNode("TENDT");
                return tenNCCNode.InnerText;
            }
            // Trả về chuỗi trống nếu không tìm thấy hoặc có lỗi
            return "";
        }
        public decimal TinhThanhTien(int maPhieuNhap)
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            var chiTietList = doc.Descendants("CHITIETPHIEUNHAP");
            decimal thanhTien = 0;

            foreach (XElement chiTietNode in chiTietList)
            {
                if (Convert.ToInt32(chiTietNode.Element("MAPN")?.Value) == maPhieuNhap)
                {
                    int soLuongNhap = Convert.ToInt32(chiTietNode.Element("SOLUONGNHAP")?.Value);
                    decimal giaNhap = Convert.ToDecimal(chiTietNode.Element("GIANHAP")?.Value);

                    thanhTien += soLuongNhap * giaNhap;
                }
            }

            return thanhTien;
        }
        
        public void InPhieuNhap(string maPN, string outputHTMLFile)
        {
            XDocument doc = XDocument.Load("CHITIETPHIEUNHAP.xml");
            var list = doc.Descendants("CHITIETPHIEUNHAP");

            XmlDocument pndoc = new XmlDocument();
            pndoc.Load("PHIEUNHAP.xml");

            // Lấy thông tin từ PHIEUNHAP.xml
            XmlNode pnNode = pndoc.SelectSingleNode($"//PHIEUNHAP[MAPN='{maPN}']");
                string maNCC = pnNode.SelectSingleNode("MANCC")?.InnerText;
                string ngayNhap = pnNode.SelectSingleNode("NGAYNHAPHANG")?.InnerText;
            DateTime ngayNhapDate = DateTime.Parse(ngayNhap);
            string ngayNhapFormatted = ngayNhapDate.ToString("dd/MM/yyyy HH:mm:ss");
            // Create HTML StringBuilder
            StringBuilder html = new StringBuilder();

            // Start HTML document
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='en'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine($"<link rel='stylesheet' href='{"../../style.css"}'>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine($"<div>Mã phiếu nhập: {maPN}</div>");
            html.AppendLine($"<div>Nhà cung cấp: {maNCC}_{timTenNCC(maNCC)}</div>");
            html.AppendLine($"<div>Ngày nhập: {ngayNhapFormatted}</div>");
            html.AppendLine("<h2>Chi Tiết Phiếu Nhập</h2>");
            html.AppendLine("<table border='1'>");
            html.AppendLine("<tr>");
            html.AppendLine("<th>Điện thoại</th>");
            html.AppendLine("<th>Số lượng nhập</th>");
            html.AppendLine("<th>Giá nhập</th>");
            html.AppendLine("<th>Tổng tiền</th>");
            html.AppendLine("</tr>");

            foreach (XElement node in list)
            {
                string mapn = node.Element("MAPN").Value.ToString();
                if (mapn == maPN)
                {
                    
                    string madt = node.Element("MADT").Value.ToString();
                    int soluongnhap = Convert.ToInt32(node.Element("SOLUONGNHAP")?.Value);
                    decimal gianhap = Convert.ToDecimal(node.Element("GIANHAP")?.Value);
                    html.AppendLine("<tr>");
                    html.AppendLine($"<td>{madt}_{timTenDT(madt)}</td>");
                    html.AppendLine($"<td>{soluongnhap}</td>");
                    html.AppendLine($"<td>{gianhap}</td>");
                    html.AppendLine($"<td>{gianhap* soluongnhap}</td>");
                    html.AppendLine("</tr>");

                }
            }
            html.AppendLine("</table>");
            html.AppendLine($"</div>Thành tiền:  {TinhThanhTien(Convert.ToInt32(maPN))}");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            // Lưu phần tử HTML vào tệp tin đầu ra
            File.WriteAllText(outputHTMLFile,html.ToString());

            // Mở trình duyệt mặc định để hiển thị tệp tin HTML
            Process.Start(outputHTMLFile);
        }

    }
}
