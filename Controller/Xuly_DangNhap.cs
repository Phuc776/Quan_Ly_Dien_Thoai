using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quan_Ly_Dien_Thoai.Controller
{
    internal class Xuly_DangNhap
    {
        XulyXML xuly = new XulyXML();
        string fileDangNhap = "NHANVIEN.xml";
        public bool kiemtraTTDN(string user, string pass)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = xuly.getXMLData(fileDangNhap);
                dt.DefaultView.RowFilter = "username ='" + user + "' AND password ='" + pass + "'";
                if (dt.DefaultView.Count > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public string setQuyenDangNhap(TextBox txtDangNhap)
        {
            XDocument doc = XDocument.Load(fileDangNhap);
            var list = doc.Descendants("NHANVIEN");
            string group;
            foreach( XElement node in list )
            {
                group = node.Element("username").Value;
                if ( txtDangNhap.Text == group)
                {
                    return node.Element("loainv").Value;
                }
            }
            return "";
        }

        public string setTenDangNhap(TextBox txtDangNhap)
        {
            XDocument doc = XDocument.Load(fileDangNhap);
            var list = doc.Descendants("NHANVIEN");
            string group;
            foreach (XElement node in list)
            {
                group = node.Element("username").Value;
                if (txtDangNhap.Text == group)
                {
                    return node.Element("tenNV").Value;
                }
            }
            return "";
        }
    }
}
