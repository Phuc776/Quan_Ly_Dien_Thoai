using Quan_Ly_Dien_Thoai.Controller;
using Quan_Ly_Dien_Thoai.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quan_Ly_Dien_Thoai.UI
{
    public partial class Login : Form
    {
        Xuly_DangNhap dangnhap = new Xuly_DangNhap();
        public Login()
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
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Equals("") || txtMK.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTenDN.Focus();
            }
            else
            {
                if (dangnhap.kiemtraTTDN(txtTenDN.Text, txtMK.Text))
                {
                    QuanLy.quyen = dangnhap.setQuyenDangNhap(txtTenDN);
                    QuanLy.tenDN = dangnhap.setTenDangNhap(txtTenDN);
                    QuanLy frmquanLy = new QuanLy();
                    frmquanLy.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenDN.Focus();
                    txtMK.Text = "";
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
            txtMK.KeyPress += TxtMK_KeyPress;
        }

        private void TxtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Checks if Enter key is pressed
            {
                e.Handled = true; // Prevents 'ding' sound
                btnDangNhap.PerformClick(); // Simulates the click on the login button
            }
        }

        private void lbTittle_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        // Start



    }
}
