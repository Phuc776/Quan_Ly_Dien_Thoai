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

namespace Quan_Ly_Dien_Thoai.App_code
{
    internal class XulyXML
    {
        XDocument xItem = new XDocument();
        public XulyXML() { }

        public DataTable getXMLData(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + file;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }

            return dt;
        }

        public void Them(string duongDan, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode currNode;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            docFrag.InnerXml = noiDung;
            currNode = doc.DocumentElement;
            currNode.InsertAfter(docFrag, currNode.LastChild);
            doc.Save(duongDan);
        }
        public void Xoa(string duongDan, string tenFileXML, string xoaTheoTruong, string giaTriTruong)
        {
            string fileName = Application.StartupPath + "\\" + duongDan;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode nodeCu = doc.SelectSingleNode("NewDataSet/" + tenFileXML + "[" + xoaTheoTruong + "='" + giaTriTruong + "']");
            doc.DocumentElement.RemoveChild(nodeCu);
            doc.Save(fileName);
        }

        public void Sua(string duongDan, string tenFile, string suaTheoTruong, string giaTriTruong, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldHang;
            XmlElement root = doc.DocumentElement;
            oldHang = root.SelectSingleNode("/NewDataSet/" + tenFile + "[" + suaTheoTruong + " ='" + giaTriTruong + "']");
            XmlElement newhang = doc.CreateElement(tenFile);
            newhang.InnerXml = noiDung;
            root.ReplaceChild(newhang, oldHang);
            doc.Save(duongDan);
        }

        public void SearchAndDisplayData(string fileName, TextBox searchBox, string[] columnNames, DataGridView dataGridView, Dictionary<string, string> columnTitleMap)
        {
            string searchText = string.IsNullOrWhiteSpace(searchBox.Text) ? "0" : searchBox.Text.Trim();
            XmlTextReader reader = new XmlTextReader(fileName);
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            if (columnNames.Length > 0)
                dv.Sort = columnNames[0];

            reader.Close();
            int index = dv.Find(searchText.Trim());
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                searchBox.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (string columnName in columnNames)
                {
                    string displayTitle = columnTitleMap.ContainsKey(columnName) ? columnTitleMap[columnName] : columnName;
                    dt.Columns.Add(displayTitle);
                }
                object[] list = new object[columnNames.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    list[i] = dv[index][columnNames[i]];
                }
                dt.Rows.Add(list);
                dataGridView.DataSource = dt;
            }
        }
        public void GenerateHTMLFromXML(string inputXMLFile, string descendElement, string[] elementNames, string outputHTMLFile, string Headline)
        {
            XDocument xItem = XDocument.Load(inputXMLFile);
            var xI = xItem.Descendants(descendElement);

            XElement tableRows = new XElement("table",
                new XElement("tr",
                    elementNames.Select(name => new XElement("td", new XAttribute("style", "background-color:lightgreen"), name)))
            );

            foreach (var el in xI)
            {
                XElement row = new XElement("tr",
                    elementNames.Select(name => new XElement("td", el.Element(name)?.Value ?? string.Empty))
                );
                tableRows.Add(row);
            }

            var html = new XElement("html",
                new XElement("head",
                    new XElement("style", "table{border:solid 1px red;}", "td{border:solid 1px silver;}")),
                new XElement("body",
                    new XElement("h2", Headline),
                    tableRows
                )
            );

            html.Save(outputHTMLFile);
            Process.Start(outputHTMLFile);
        }


    }
}
