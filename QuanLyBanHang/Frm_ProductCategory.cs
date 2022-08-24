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
    public partial class Frm_ProductCategory : Form
    {
        ProductCategoryModel productCateModel = new ProductCategoryModel();
        public Frm_ProductCategory()
        {
            InitializeComponent();
        }

        private void Frm_ProductCategory_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dgvListAll.DataSource = productCateModel.GetAllOrderByDESC();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ProductCategory productCate = new ProductCategory();
            productCate.Name = txtName.Text;
            bool result = productCateModel.Insert(productCate);
            if (result)
            {
                MessageBox.Show("Thêm danh mục thành công", "Thông báo");
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
            ProductCategory productCate = new ProductCategory();
            productCate.Name = txtName.Text;
            productCate.ID = int.Parse(txtID.Text);

            bool result = productCateModel.Update(productCate);
            if (result)
            {
                MessageBox.Show("Sửa thông tin danh mục thành công", "Thông báo");
                LoadList();
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Thông báo");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            bool result = productCateModel.Delete(int.Parse(txtID.Text));
            if (result)
            {
                MessageBox.Show("Xóa danh mục thành công", "Thông báo");
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
            txtID.Clear();
            txtName.Clear();
            btAdd.Enabled = true;
        }

        private void dgvListAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row;
            row = dgvListAll.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(row.Cells["ID"].Value);
            txtName.Text = Convert.ToString(row.Cells["CategoryName"].Value);
            btAdd.Enabled = false;
        }
    }
}