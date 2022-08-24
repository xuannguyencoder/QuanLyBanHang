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
    public partial class Frm_Customer : Form
    {
        CustomerModel customerModel = new CustomerModel();
        public long CustomerID { get; set; }
        public bool IsActive { get; set; }
        public Frm_Customer()
        {
            InitializeComponent();
        }
        private void Frm_Customer_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dgvListAll.DataSource = customerModel.GetAll();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            if (rdNam.Checked == true)
                customer.Gender = rdNam.Text;
            else
                customer.Gender = rdNu.Text;
            bool result = customerModel.Insert(customer);
            if (result)
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
                Clear();
                LoadList();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ID = int.Parse(txtID.Text);
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            if (rdNam.Checked == true)
                customer.Gender = rdNam.Text;
            else
                customer.Gender = rdNu.Text;
            bool result = customerModel.Update(customer);
            if (result)
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công", "Thông báo");
                LoadList();
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Thông báo");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            bool result = customerModel.Delete(long.Parse(txtID.Text));
            if (result)
            {
                MessageBox.Show("Xóa khách hàng thành công", "Thông báo");
                Clear();
                LoadList();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Thông báo");
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtAddress.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtID.Clear();
            rdNam.Checked = true;
            btAdd.Enabled = true;
        }

        private void dgvListAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row;
            row = dgvListAll.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(row.Cells["ID"].Value);
            txtAddress.Text = Convert.ToString(row.Cells["Address"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtFirstName.Text = Convert.ToString(row.Cells["FirstName"].Value);
            txtLastName.Text = Convert.ToString(row.Cells["LastName"].Value);
            txtPhoneNumber.Text = Convert.ToString(row.Cells["PhoneNumber"].Value);
            string gender = Convert.ToString(row.Cells["Gender"].Value);

            if (gender == rdNam.Text)
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            btAdd.Enabled = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchName.Text))
            {
                dgvListAll.DataSource = customerModel.GetByName(txtSearchName.Text);
            }
        }
        private void dgvListAll_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsActive)
            {
                DataGridViewRow row;
                row = dgvListAll.Rows[e.RowIndex];
                CustomerID = long.Parse(row.Cells["ID"].Value.ToString());
                DialogResult = DialogResult.OK;
            } 
        }
    }
}