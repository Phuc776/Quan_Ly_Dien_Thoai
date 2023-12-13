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
            // Lấy văn bản tìm kiếm từ TextBox, nếu trống thì sử dụng "0"
            string searchText = string.IsNullOrWhiteSpace(searchBox.Text) ? "0" : searchBox.Text.Trim();

            // Sử dụng XmlTextReader để đọc dữ liệu từ tệp tin XML
            XmlTextReader reader = new XmlTextReader(fileName);

            // Đọc dữ liệu XML vào DataSet
            DataSet ds = new DataSet();
            ds.ReadXml(reader);

            // Tạo DataView để sắp xếp và tìm kiếm trong DataSet
            DataView dv = new DataView(ds.Tables[0]);

            // Sắp xếp DataView nếu có cột sắp xếp được chỉ định
            if (columnNames.Length > 0)
                dv.Sort = columnNames[0];

            // Đóng XmlTextReader sau khi đọc xong
            reader.Close();

            // Tìm kiếm giá trị trong DataView
            int index = dv.Find(searchText.Trim());

            // Kiểm tra xem có tìm thấy hay không
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                searchBox.Focus();
            }
            else
            {
                // Tạo DataTable để chứa kết quả tìm kiếm
                DataTable dt = new DataTable();

                // Đối với mỗi tên cột, thêm một cột vào DataTable với tên đã được ánh xạ
                foreach (string columnName in columnNames)
                {
                    string displayTitle = columnTitleMap.ContainsKey(columnName) ? columnTitleMap[columnName] : columnName;
                    dt.Columns.Add(displayTitle);
                }

                // Tạo một hàng mới trong DataTable và điền giá trị từ DataView vào
                object[] list = new object[columnNames.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    list[i] = dv[index][columnNames[i]];
                }
                dt.Rows.Add(list);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView.DataSource = dt;
            }
        }
        public void GenerateHTMLFromXML1(string inputXMLFile, string descendElement, string[] elementNames,string[] displayNames, string outputHTMLFile, string Headline)
        {
            // Load XML từ tệp tin đầu vào
            XDocument xItem = XDocument.Load(inputXMLFile);

            // Lấy tất cả các phần tử con của phần tử có tên là 'descendElement'
            var xI = xItem.Descendants(descendElement);

            // Tạo phần tử HTML <table> với hàng đầu tiên chứa tên các cột
            XElement tableRows = new XElement("table",
                new XElement("tr",
                    displayNames.Select(name => new XElement("td", new XAttribute("style", "background-color:lightgreen"), name)))
            );

            // Duyệt qua mỗi phần tử con và tạo một hàng mới cho mỗi phần tử
            foreach (var el in xI)
            {
                // Tạo một hàng HTML mới
                XElement row = new XElement("tr",
                    // Đối với mỗi tên cột, tạo một ô <td> và điền giá trị từ phần tử XML hoặc chuỗi rỗng nếu không có giá trị
                    elementNames.Select(name => new XElement("td", el.Element(name)?.Value ))
                );

                // Thêm hàng mới vào bảng
                tableRows.Add(row);
            }

            // Tạo phần tử HTML <html> với đầu <head> chứa định dạng CSS và thân <body> chứa tiêu đề và bảng dữ liệu
            var html = new XElement("html",
    new XElement("head",
        new XElement("link", new XAttribute("rel", "stylesheet"), new XAttribute("href", "../../style.css")),
        new XElement("style", "table { border: solid 1px red; } td { border: solid 1px silver; }")
    ),
    new XElement("body",
        new XElement("h2", Headline),
        tableRows
    )
);

            // Lưu phần tử HTML vào tệp tin đầu ra
            html.Save(outputHTMLFile);

            // Mở trình duyệt mặc định để hiển thị tệp tin HTML
            Process.Start(outputHTMLFile);
        }
       

    }
}
