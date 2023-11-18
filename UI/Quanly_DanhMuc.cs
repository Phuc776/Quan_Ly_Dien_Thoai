using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Dien_Thoai.App_code;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Quanly_DanhMuc : Form
    {
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
            Xulydulieu xuly = new Xulydulieu();
            String sql = "select * from DANHMUC";
            this.dgvDanhMuc.DataSource = xuly.getTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String sql = "SELECT * FROM DANHMUC";
            List<string> conditions = new List<string>();

            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            if (!String.IsNullOrEmpty(maDM))
            {
                conditions.Add("MaDM = '" + maDM + "'");
            }
            if (!String.IsNullOrEmpty(tenDM))
            {
                conditions.Add("LoaiDT = '" + tenDM + "'");
            }

            if (conditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", conditions);
            }
            
            this.dgvDanhMuc.DataSource = xuly.getTable(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            String sql = "Insert into [DANHMUC] ([MaDM], [LoaiDT]) " +
                "Values ('" + maDM + "', '" + tenDM + "')";
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            String sql = "Update [DANHMUC] " +
                "SET [MaDM] = '" + maDM + "', [LoaiDM] = '" + tenDM + "' " +
                "WHERE  [MaDM] = '" + maDM + "'";
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xulydulieu xuly = new Xulydulieu();
            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            String sql = "DELETE [DANHMUC] " +
                "WHERE  [MaDM] = '" + maDM + "'";
            
        }

        private void btnXmlPrinter_Click(object sender, EventArgs e)
        {

        }

        private void btnViewWeb_Click(object sender, EventArgs e)
        {

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

        private void dgvRowSelected()
        {
            int d = dgvDanhMuc.CurrentRow.Index;
            txtMaDanhMuc.Text = dgvDanhMuc.Rows[d].Cells[0].Value.ToString();
            txtTenDanhMuc.Text = dgvDanhMuc.Rows[d].Cells[1].Value.ToString();

        }
    }
}
