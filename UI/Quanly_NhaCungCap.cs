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
    public partial class Quanly_NhaCungCap : Form
    {
        Xulydulieu xuly = new Xulydulieu();
        public Quanly_NhaCungCap()
        {
            InitializeComponent();
        }

        private void Quanly_NhaCungCap_Load(object sender, EventArgs e)
        {
            String sql = "SELECT * from NHACUNGCAP";
            this.dgvNCC.DataSource = xuly.getTable(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM NHACUNGCAP";
            List<string> conditions = new List<string>();

            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            String tenDN = txtTenDN.Text.Trim();
            String mk = txtMatKhau.Text.Trim();

            if (!String.IsNullOrEmpty(maNCC))
            {
                conditions.Add("MANCC = '" + maNCC + "'");
            }
            if (!String.IsNullOrEmpty(tenNCC))
            {
                conditions.Add("TENNCC = '" + tenNCC + "'");
            }
            if (!String.IsNullOrEmpty(sdt))
            {
                conditions.Add("SDT = '" + sdt + "'");
            }
            if (!String.IsNullOrEmpty(tenDN))
            {
                conditions.Add("TENDN = '" + tenDN + "'");
            }
            if (!String.IsNullOrEmpty(mk))
            {
                conditions.Add("MK = '" + mk + "'");
            }
            if (conditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", conditions);
            }

            this.dgvNCC.DataSource = xuly.getTable(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            String tenDN = txtTenDN.Text.Trim();
            String mk = txtMatKhau.Text.Trim();

            String sql = "INSERT INTO NHACUNGCAP (MANCC, TENNCC, SDT, TENDN, MK) " +
                "Values ( " + maNCC + " , " + tenNCC + " , " + sdt + " , " + tenDN + " , "+ mk +" )";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC.Text.Trim();
            String tenNCC = txtTenNCC.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            String tenDN = txtTenDN.Text.Trim();
            String mk = txtMatKhau.Text.Trim();

            string updateQuery = "UPDATE NHACUNGCAP " +
                "SET TENNCC = "+ tenNCC +", SDT = "+ sdt + ", TENDN = "+ tenDN + ", MK = "+ mk +" " +
                "WHERE MANCC = "+ maNCC + " ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maNCC = txtMaNCC.Text.Trim();

            String sql = "DELETE NHACUNGCAP " +
                "WHERE  MaNCC = '" + maNCC + "'";
        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            dgvRowSelected();
        }

        private void dgvRowSelected()
        {
            
        }
    }
}
