using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Data;
using System.Xml;

namespace Quan_Ly_Dien_Thoai.Controller
{
    internal class DienThoai
    {
        XulyXML xulyXML = new XulyXML();
        public DienThoai() { }
        public bool checkMaDT(string MaDM)
        {
            XmlTextReader reader = new XmlTextReader("DIENTHOAI.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/DIENTHOAI[MADT='" + MaDM + "']");
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
        public DataTable LoadDT()
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("DIENTHOAI.xml");
            dt.Columns.Add("CombinedColumn", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                string MADT = row["MADT"].ToString();
                string TENDT = row["TENDT"].ToString();
                row["CombinedColumn"] = $"{MADT} - {TENDT}";
            }
            DataRow dr = dt.NewRow();
            dr["CombinedColumn"] = "";
            dt.Rows.Add(dr);
            return dt;
        }
        public void AddDT(String MaDT, String TENDT, String Soluonghiencon, String MaDM)
        {
            String noidung = "<DIENTHOAI>" +
                "<MADT>" + MaDT + "</MADT>" +
                "<TENDT>" + TENDT + "</TENDT>" +
                "<SOLUONGHIENCON>" + Soluonghiencon + "</SOLUONGHIENCON>" +
                "<MaDM>" + MaDM + "</MaDM>" +
                "</DIENTHOAI>";
            xulyXML.Them("DIENTHOAI.xml", noidung);
        }

        public void EditDT(String MADT, String TENDT, String Soluonghiencon, String MaDM)
        {
            String noidung =
               "<MADT>" + MADT + "</MADT>" +
               "<TENDT>" + TENDT + "</TENDT>" +
               "<SOLUONGHIENCON>" + Soluonghiencon + "</SOLUONGHIENCON>" +
                "<MaDM>" + MaDM + "</MaDM>";
            xulyXML.Sua("DIENTHOAI.xml", "DIENTHOAI", "MADT", MADT, noidung);
        }

        public void DeleteDT(String MaDT)
        {
            xulyXML.Xoa("DIENTHOAI.xml", "DIENTHOAI", "MADT", MaDT);
        }
    }
}
