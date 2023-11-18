using Quan_Ly_Dien_Thoai.App_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class SaoLuu_Phuchoi : Form
    {
        public SaoLuu_Phuchoi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool drag = false;
        private Point dragCursor, dragForm;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int wid = SystemInformation.VirtualScreen.Width;
            int hei = SystemInformation.VirtualScreen.Height;
            if (drag)
            {
                // Phải using System.Drawing;
                Point change = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Point newpos = Point.Add(dragForm, new Size(change));
                this.Location = newpos;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void XMLtoSQL_Click(object sender, EventArgs e)
        {
            try
            {
                Xulydulieu xuly = new Xulydulieu();
                string[] tableNames = { "NHACUNGCAP", "DANHMUC", "DIENTHOAI", "PHIEUNHAP", "CHITIETPHIEUNHAP", "NHANVIEN" };
                foreach (string tableName in tableNames) {
                    xuly.Execute(@"delete from " + tableName);
                }
                
                xuly.loadTables(tableNames);
                MessageBox.Show("Cập nhập SQL server thành công");
            }catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void SQLtoXML_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();

            string[] tableNames = { "NHACUNGCAP", "DANHMUC", "DIENTHOAI", "PHIEUNHAP", "CHITIETPHIEUNHAP", "NHANVIEN" };
            xuly.loadXML(tableNames);
            
            MessageBox.Show("Khôi phục dữ liệu thành công");
        }

    }
}
