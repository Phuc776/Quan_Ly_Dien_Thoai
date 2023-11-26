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
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;

            }

        }

        public void AddNhanVien(String maNV, String tenNV, String user, String pass, String LoaiNV )
        {
            String noidung = "<NHANVIEN>" +
                "<maNV>" + maNV + "</maNV>" +
                "<tenNV>" + tenNV + "</tenNV>" +
                "<username>" + user + "</username>" +
                "<password>" + pass + "</password>" +
                "<loainv>" + LoaiNV + "</loainv>" +
                "</NHANVIEN>";
            xulyXML.Them("NHANVIEN.xml", noidung);
        }

        public void EditNhanVien(String maNV, String tenNV, String user, String pass, String LoaiNV )
        {
            String noidung =
               "<maNV>" + maNV + "</maNV>" +
               "<tenNV>" + tenNV + "</tenNV>" +
               "<username>" + user + "</username>" +
               "<password>" + pass + "</password>" +
               "<loainv>" + LoaiNV + "</loainv>";
            xulyXML.Sua("NHANVIEN.xml", "NHANVIEN", "maNV", maNV, noidung);
        }

        public void DeleteNhanVien(String maNV)
        {
            xulyXML.Xoa("NHANVIEN.xml", "NHANVIEN", "maNV", maNV);
        }
    }
}
