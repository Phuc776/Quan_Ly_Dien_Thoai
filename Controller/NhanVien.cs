using Quan_Ly_Dien_Thoai.App_code;
using Quan_Ly_Dien_Thoai.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quan_Ly_Dien_Thoai.Controller
{
    internal class NhanVien
    {
        XulyXML xulyXML = new XulyXML();
        public NhanVien() { }

        public bool checkMaNhanVien(string maNV)
        {
            XmlTextReader reader = new XmlTextReader("NHANVIEN.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/NHANVIEN[maNV='" + maNV + "']");
            reader.Close();
            if (node != null)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public void AddNhanVien(string maNV, string tenNV, string user, string pass, string LoaiNV )
        {
            string noidung = "<NHANVIEN>" +
                "<maNV>" + maNV + "</maNV>" +
                "<tenNV>" + tenNV + "</tenNV>" +
                "<username>" + user + "</username>" +
                "<password>" + pass + "</password>" +
                "<loainv>" + LoaiNV + "</loainv>" +
                "</NHANVIEN>";
            xulyXML.Them("NHANVIEN.xml", noidung);
        }

        public void EditNhanVien(string maNV, string tenNV, string user, string pass, string LoaiNV )
        {
            string noidung =
               "<maNV>" + maNV + "</maNV>" +
               "<tenNV>" + tenNV + "</tenNV>" +
               "<username>" + user + "</username>" +
               "<password>" + pass + "</password>" +
               "<loainv>" + LoaiNV + "</loainv>";
            xulyXML.Sua("NHANVIEN.xml", "NHANVIEN", "maNV", maNV, noidung);
        }

        public void DeleteNhanVien(string maNV)
        {
            xulyXML.Xoa("NHANVIEN.xml", "NHANVIEN", "maNV", maNV);
        }
    }
}
