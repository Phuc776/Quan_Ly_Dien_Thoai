using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quan_Ly_Dien_Thoai.Controller
{   
    internal class NCC
    {
        
        XulyXML xulyXML = new XulyXML();
        public NCC() { }

        public bool checkMaNhanVien(string MANCC)
        {
            XmlTextReader reader = new XmlTextReader("NHACUNGCAP.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/NHACUNGCAP[MANCC='" + MANCC + "']");
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
        public DataTable LoadNCC()
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("NHACUNGCAP.xml");
            dt.Columns.Add("CombinedColumn", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                string maNCC = row["MANCC"].ToString();
                string tenNCC = row["TENNCC"].ToString();
                row["CombinedColumn"] = $"{maNCC} - {tenNCC}";
            }
            DataRow dr = dt.NewRow();
            dr["CombinedColumn"] = "";
            dt.Rows.Add(dr);
            return dt;
        }
        public void AddNCC(String MANCC, String TENNCC, String SDT)
        {
            String noidung = "<NHACUNGCAP>" +
                "<MANCC>" + MANCC + "</MANCC>" +
                "<TENNCC>" + TENNCC + "</TENNCC>" +
                "<SDT>" + SDT + "</SDT>" +
                "</NHACUNGCAP>";
            xulyXML.Them("NHACUNGCAP.xml", noidung);
        }

        public void EditNCC(String MANCC, String TENNCC, String SDT)
        {
            String noidung =
               "<MANCC>" + MANCC + "</MANCC>" +
               "<TENNCC>" + TENNCC + "</TENNCC>" +
               "<SDT>" + SDT + "</SDT>";
            xulyXML.Sua("NHACUNGCAP.xml", "NHACUNGCAP", "MANCC", MANCC, noidung);
        }

        public void DeleteNCC(String MANCC)
        {
            xulyXML.Xoa("NHACUNGCAP.xml", "NHACUNGCAP", "MANCC", MANCC);
        }
    }
}
