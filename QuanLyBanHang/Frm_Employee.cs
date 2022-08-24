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
    public partial class Frm_Employee : Form
    {
        EmployeeModel employeeModel = new EmployeeModel();
        public Frm_Employee()
        {
            InitializeComponent();
        }
        private void Frm_Employee_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dgvListAll.DataSource = employeeModel.GetAll();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.PhoneNumber = txtPhoneNumber.Text;
            employee.Email = txtEmail.Text;
            employee.Address = txtAddress.Text;
            if (rdNam.Checked == true)
                employee.Gender = rdNam.Text;
            else
                employee.Gender = rdNu.Text;
            bool result = employeeModel.Insert(employee);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                Clear();
                LoadList();
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo");
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.ID = int.Parse(txtID.Text);
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.PhoneNumber = txtPhoneNumber.Text;
            employee.Email = txtEmail.Text;
            employee.Address = txtAddress.Text;
            if (rdNam.Checked == true)
                employee.Gender = rdNam.Text;
            else
                employee.Gender = rdNu.Text;
            bool result = employeeModel.Update(employee);
            if (result)
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo");
                LoadList();
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Thông báo");
            }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            bool result = employeeModel.Delete(int.Parse(txtID.Text));
            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công", "Thông báo");
                Clear();
                LoadList();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Thông báo");
            }
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
    }
}
