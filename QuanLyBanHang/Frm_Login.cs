using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_Login : Form
    {
        public string username { get; set; }
        public UserModel userModel = new UserModel();
        public Frm_Login()
        {
            InitializeComponent();
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Thông báo");
            }
            else
            {
                int result = userModel.Login(txtUsername.Text, txtPassword.Text);
                if (result == 1)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    this.username = txtUsername.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else if (result == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo");
                }
                else if (result == -1)
                {
                    MessageBox.Show("Sai mật khẩu", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Tài khoản đang bị khóa", "Thông báo");
                }
            }
        }
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
