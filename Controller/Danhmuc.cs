using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Quan_Ly_Dien_Thoai.App_code;

namespace Quan_Ly_Dien_Thoai.Controller
{
    public class Danhmuc
    {
        XulyXML xulyXML = new XulyXML();
        public Danhmuc() { }
        public bool checkMaDanhMuc(string MaDM)
        {
            XmlTextReader reader = new XmlTextReader("DANHMUC.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/DANHMUC[MADM='" + MaDM + "']");
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
        public DataTable LoadDanhMuc()
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("DANHMUC.xml");
            dt.Columns.Add("CombinedColumn", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                string maDM = row["MADM"].ToString();
                string tenDM = row["TENDM"].ToString();
                row["CombinedColumn"] = $"{maDM} - {tenDM}";
            }
            
            return dt;
        }
        public void AddDanhMuc(string MaDM, string TenDm) 
        {
            string noidung = "<DANHMUC>" +
                "<MADM>" + MaDM + "</MADM>" +
                "<TENDM>" + TenDm + "</TENDM>" +
                "</DANHMUC>";
            xulyXML.Them("DANHMUC.xml", noidung);
        }

        public void EditDanhMuc(string MaDM, string TenDm)
        {
            string noidung = 
               "<MADM>" + MaDM + "</MADM>" +
               "<TENDM>" + TenDm + "</TENDM>";
            xulyXML.Sua("DANHMUC.xml","DANHMUC","MADM",MaDM, noidung);
        }

        public void DeleteDanhMuc(string MaDM)
        {
            xulyXML.Xoa("DANHMUC.xml", "DANHMUC", "MADM", MaDM);
        }
        public void ChangeColumnDanhMuc(DataTable dt)
        {
            dt.Columns["MADM"].ColumnName = "Mã danh mục";
            dt.Columns["TENDM"].ColumnName = "Tên danh mục";
        }
        public void TimDanhMucTheoMa(string MaDM,DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("DANHMUC.xml");
            DataView dv = new DataView(dt);
            dv.RowFilter = $"MADM ='{MaDM}'";
            if (dv.Count > 0)
            {
                dt = dv.ToTable();
            }
            else
            {
                MessageBox.Show("Không tìm thấy danh mục với Mã: " + MaDM);
                return;
            }
            ChangeColumnDanhMuc(dt);
            dgv.DataSource = dt;
        }
    }
}
