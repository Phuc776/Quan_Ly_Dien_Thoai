using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Dien_Thoai.App_code;
using Quan_Ly_Dien_Thoai.Controller;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_DanhMuc : Form
    {
        XulyXML xuly = new XulyXML();
        Danhmuc danhmuc = new Danhmuc();
        string[] colnames_elements = { "MaDM", "TenDM" };
        public Quanly_DanhMuc()
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
        private void Quanly_DanhMuc_Load(object sender, EventArgs e)
        {
            dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HienThi();
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt = xuly.getXMLData("DANHMUC.xml");
            this.dgvDanhMuc.DataSource = dt;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            dgvRowSelected();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhmuc.checkMaDanhMuc(txtMaDanhMuc.Text) == true)
                    MessageBox.Show("Mã danh mục đã tồn tại");
                else
                {
                    danhmuc.AddDanhMuc(txtMaDanhMuc.Text, txtTenDanhMuc.Text);
                    MessageBox.Show("Đã thêm");
                    HienThi();
                };
            }catch(Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                danhmuc.EditDanhMuc(txtMaDanhMuc.Text, txtTenDanhMuc.Text);
                MessageBox.Show("Đã sửa");
                HienThi();
            }catch(Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try 
            { 
                danhmuc.DeleteDanhMuc(txtMaDanhMuc.Text);
                MessageBox.Show("Đã xóa");
                HienThi();
            }catch(Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            
            xuly.SearchAndDisplayData("DANHMUC.xml", txtMaDanhMuc, colnames_elements, dgvDanhMuc);
        }

        private void btn_Renew_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnXmlViewer_Click(object sender, EventArgs e)
        {
            xuly.GenerateHTMLFromXML("DANHMUC.xml", "DANHMUC" , colnames_elements, "DANHMUC.html", "Danh mục sản phẩm");
        }

        private void dgvRowSelected()
        {
            if (dgvDanhMuc.CurrentRow != null && dgvDanhMuc.CurrentRow.Index >= 0)
            {
                int d = dgvDanhMuc.CurrentRow.Index;
                txtMaDanhMuc.Text = dgvDanhMuc.Rows[d].Cells[0].Value?.ToString() ?? "";
                txtTenDanhMuc.Text = dgvDanhMuc.Rows[d].Cells[1].Value?.ToString() ?? "";
            }
        }
    }
}
