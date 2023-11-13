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
        Xulydulieu xuly = new Xulydulieu();
        public Quanly_DanhMuc()
        {
            InitializeComponent();
        }
        private void Quanly_DanhMuc_Load(object sender, EventArgs e)
        {
            
            String sql = "select * from DANHMUC";
            this.dgvDanhMuc.DataSource = xuly.getTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
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
            
            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            String sql = "Insert into [DANHMUC] ([MaDM], [LoaiDT]) " +
                "Values ('" + maDM + "', '" + tenDM + "')";
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            String maDM = txtMaDanhMuc.Text.Trim();
            String tenDM = txtTenDanhMuc.Text.Trim();

            String sql = "Update [DANHMUC] " +
                "SET [MaDM] = '" + maDM + "', [LoaiDM] = '" + tenDM + "' " +
                "WHERE  [MaDM] = '" + maDM + "'";
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
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
