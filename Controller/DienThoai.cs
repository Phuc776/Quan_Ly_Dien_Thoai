using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Data;
using System.Windows.Forms;
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
            if (node != null)
            {
                return  true;
            }
            else
            {
                return  false;

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
        public void AddDT(string MaDT, string TENDT, string Soluonghiencon, string MaDM)
        {
            string noidung = "<DIENTHOAI>" +
                "<MADT>" + MaDT + "</MADT>" +
                "<TENDT>" + TENDT + "</TENDT>" +
                "<SOLUONGHIENCON>" + Soluonghiencon + "</SOLUONGHIENCON>" +
                "<MADM>" + MaDM + "</MADM>" +
                "</DIENTHOAI>";
            xulyXML.Them("DIENTHOAI.xml", noidung);
        }

        public void EditDT(string MADT, string TENDT, string Soluonghiencon, string MaDM)
        {
            string noidung =
               "<MADT>" + MADT + "</MADT>" +
               "<TENDT>" + TENDT + "</TENDT>" +
               "<SOLUONGHIENCON>" + Soluonghiencon + "</SOLUONGHIENCON>" +
                "<MADM>" + MaDM + "</MADM>";
            xulyXML.Sua("DIENTHOAI.xml", "DIENTHOAI", "MADT", MADT, noidung);
        }

        public void DeleteDT(string MaDT)
        {
            xulyXML.Xoa("DIENTHOAI.xml", "DIENTHOAI", "MADT", MaDT);
        }
        public void ChangeColumnDienThoai(DataTable dt)
        {
            dt.Columns["MADT"].ColumnName = "Mã điện thoại";
            dt.Columns["TENDT"].ColumnName = "Tên điện thoại";
            dt.Columns["MADM"].ColumnName = "Mã danh mục";
            dt.Columns["SOLUONGHIENCON"].ColumnName = "Số lượng hiện còn";
            dt.Columns["TENDM"].ColumnName = "Tên danh mục";
        }
        public void TimDienThoaiTheoMa(string MaDt, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt = xulyXML.getXMLData("DIENTHOAI.xml");
            DataView dv = new DataView(dt);
            dv.RowFilter = $"MADT ='{MaDt}'";
            if (dv.Count > 0)
            {
                /*dt = dv.ToTable();*/
                int maDanhMuc = Convert.ToInt32(dv[0]["MADM"]);
                DataTable dm = xulyXML.getXMLData("DANHMUC.xml");
                DataRow rows = dm.Select($"MADM = {maDanhMuc}")[0];
                string tenDanhMuc = rows["TENDM"].ToString();
                DataTable dtResult = dv.ToTable();
                dtResult.Columns.Add("TENDM", typeof(string));
                dtResult.Rows[0]["TENDM"] = tenDanhMuc;
                ChangeColumnDienThoai(dtResult);
                dgv.DataSource = dtResult;
            }
            else
            {
                MessageBox.Show("Không tìm thấy điện thoại với Mã: " + MaDt);
                return;
            }
            
            
        }
    }
}
