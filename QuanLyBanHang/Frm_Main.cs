using QuanLyBanHang.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_Main : Form
    {
        public User user { get; set; }
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }
        public bool CheckAdmin()
        {
            if (user!=null && user.Role ==1)
                return true;
            return false;
        }
        private void mn_Customer_Click(object sender, EventArgs e)
        {
            if (CheckAdmin())
            {
                Frm_Customer form = new Frm_Customer();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản người quản trị");
            }
        }

        private void mn_Employee_Click(object sender, EventArgs e)
        {
            if (CheckAdmin())
            {
                Frm_Employee form = new Frm_Employee();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản người quản trị");
            }
        }

        private void mn_ProductCategory_Click(object sender, EventArgs e)
        {
            if (CheckAdmin())
            {
                Frm_ProductCategory form = new Frm_ProductCategory();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản người quản trị");
            }    
        }

        private void mn_Product_Click(object sender, EventArgs e)
        {
            if (CheckAdmin())
            {
                Frm_Product form = new Frm_Product();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập tài khoản người quản trị");
            }
        }

        private void mn_Login_Click(object sender, EventArgs e)
        {
            Frm_Login form = new Frm_Login();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                mn_Login.Visible = false;
                mn_Logout.Visible = true;
                UserModel userModel = new UserModel();
                user = userModel.GetByUsername(form.username);
            }
        }

        private void mn_Logout_Click(object sender, EventArgs e)
        {
            user = null;
            mn_Login_Click(sender, e);
        }

        private void btSellProducts_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                EmployeeModel employeeModel = new EmployeeModel();
                Frm_SellProduct frm = new Frm_SellProduct();

                frm.employee = employeeModel.GetByID(user.EmployeeID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập để thực hiện chức năng này");
            }
        }

        private void bt_ListProduct_Click(object sender, EventArgs e)
        {
            Frm_ListProduct frm = new Frm_ListProduct();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int one = rd.Next(0,255);
            int two = rd.Next(0,255);
            int three = rd.Next(0,255);
            int four = rd.Next(0,255);
            label1.ForeColor = Color.FromArgb(one,two,three, four);
            btSellProducts.ForeColor = Color.FromArgb(one,two,three, four);
            bt_danhthu.ForeColor = Color.FromArgb(one,two,three, four);
            bt_nhaphang.ForeColor = Color.FromArgb(one,two,three, four);
            bt_ListProduct.ForeColor = Color.FromArgb(one,two,three, four);
        }
    }
}