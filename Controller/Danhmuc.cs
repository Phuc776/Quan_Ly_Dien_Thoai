using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Quan_Ly_Dien_Thoai.App_code;

namespace Quan_Ly_Dien_Thoai.Controller
{
    internal class Danhmuc
    {
        XulyXML xulyXML = new XulyXML();
        public Danhmuc() { }
        public bool checkMaDanhMuc(string MaDM)
        {
            XmlTextReader reader = new XmlTextReader("DANHMUC.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/DANHMUC[MaDM='" + MaDM + "']");
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
        public DataTable LoadDanhMuc()
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("DANHMUC.xml");
            dt.Columns.Add("CombinedColumn", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                string maDM = row["MaDM"].ToString();
                string tenDM = row["TenDM"].ToString();
                row["CombinedColumn"] = $"{maDM} - {tenDM}";
            }
            DataRow dr = dt.NewRow();
            dr["CombinedColumn"] = "";
            dt.Rows.Add(dr);
            return dt;
        }
        public void AddDanhMuc(String MaDM, String TenDm) 
        {
            String noidung = "<DANHMUC>" +
                "<MaDM>" + MaDM + "</MaDM>" +
                "<TenDM>" + TenDm + "</TenDM>" +
                "</DANHMUC>";
            xulyXML.Them("DANHMUC.xml", noidung);
        }

        public void EditDanhMuc(String MaDM, String TenDm)
        {
            String noidung = 
               "<MaDM>" + MaDM + "</MaDM>" +
               "<TenDM>" + TenDm + "</TenDM>";
            xulyXML.Sua("DANHMUC.xml","DANHMUC","MaDM",MaDM, noidung);
        }

        public void DeleteDanhMuc(String MaDM)
        {
            xulyXML.Xoa("DANHMUC.xml", "DANHMUC", "MaDM", MaDM);
        }
    }
}
