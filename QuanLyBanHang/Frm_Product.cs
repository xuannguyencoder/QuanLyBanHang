using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_Product : Form
    {
        ProductModel productModel = new ProductModel();
        ProductCategoryModel productCateModel = new ProductCategoryModel();
        private MemoryStream ms = new MemoryStream();
        private Image image;

        public Frm_Product()
        {
            InitializeComponent();
        }
        private void Frm_Product_Load(object sender, EventArgs e)
        {
            LoadList();
            CBBProductCategory();
        }
        private void CBBProductCategory()
        {
            ProductCategoryModel productCateModel = new ProductCategoryModel();
            cbbProductCategory.DataSource = productCateModel.GetAllOrderByDESC();
            cbbProductCategory.DisplayMember = "Name";
            cbbProductCategory.ValueMember = "ID";
        }
        private void LoadList()
        {
            dgvListAll.DataSource = productModel.GetAll();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = float.Parse(txtPrice.Text);
            product.Discount = float.Parse(txtDiscount.Text);
            product.ProductCategoryID = int.Parse(cbbProductCategory.SelectedValue.ToString());
            product.Quantity = int.Parse(txtQuantity.Text);
            if (image!=null)
            {
                product.Image = ConvertImageToBytes(image);
            }
            bool result = productModel.Insert(product);
            if (result)
            {
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");
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
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn chỉnh sửa", "Thông báo");
            }
            else
            {
                Product product = new Product();
                product.ID = long.Parse(txtID.Text);
                product.Name = txtName.Text;
                product.Description = txtDescription.Text;
                product.Price = float.Parse(txtPrice.Text);
                product.Discount = float.Parse(txtDiscount.Text);
                product.Quantity = int.Parse(txtQuantity.Text);
                product.ProductCategoryID = int.Parse(cbbProductCategory.SelectedValue.ToString());
                if (image != null)
                {
                    product.Image = ConvertImageToBytes(image);
                }

                bool result = productModel.Update(product);
                if (result)
                {
                    MessageBox.Show("Sửa thông tin sản phẩm thành công", "Thông báo");
                    image = null;
                    txtImage.Clear();
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông báo");
                }
            }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            bool result = productModel.Delete(long.Parse(txtID.Text));
            if (result)
            {
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo");
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
        private void dgvListAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row;
            row = dgvListAll.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(row.Cells["ID"].Value);
            txtName.Text = Convert.ToString(row.Cells["ProductName"].Value);
            txtPrice.Text = Convert.ToString(row.Cells["Price"].Value);
            txtDiscount.Text = Convert.ToString(row.Cells["Discount"].Value);
            txtQuantity.Text = Convert.ToString(row.Cells["Quantity"].Value);
            txtDescription.Text = Convert.ToString(row.Cells["Description"].Value);
            cbbProductCategory.SelectedValue = Convert.ToString(row.Cells["ProductCategoryID"].Value);
            btAdd.Enabled = false;
            image = null;
        }
        private void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtDiscount.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtImage.Clear();
            btAdd.Enabled = true;
            image = null;
        }

        private void txtImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Image Files(*.jpg;*.gif)|*.jpg;*.gif|All Files (*.*)|*.*", Multiselect = false})
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image = Image.FromFile(openFileDialog.FileName);
                    txtImage.Text = openFileDialog.FileName;
                }
            }  
        }
        private byte[] ConvertImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}