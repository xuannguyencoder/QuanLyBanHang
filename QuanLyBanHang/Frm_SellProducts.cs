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
    public partial class Frm_SellProduct : Form
    {
        private List<CartItem> cart = new List<CartItem>();
        public Employee employee { get; set; }
        public Frm_SellProduct()
        {
            InitializeComponent();
        }

        private void Frm_SellProducts_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            txtCartTotal.Text = cart.Sum(x => x.Total).ToString();
            dgvListAll.DataSource = cart.ToList();
        }

        private void btAddOrder_Click(object sender, EventArgs e)
        {
            cart.Clear();
            LoadList();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && int.Parse(txtQuantity.Text)>0)
            {
                ProductModel productModel = new ProductModel();
                var product = productModel.GetByID(txtProductID.Text);
                if (product!=null)
                {
                    if (cart.Where(x=>x.ProductID == product.ID).Count()==0)
                    {
                        CartItem cartItem = new CartItem(product, int.Parse(txtQuantity.Text));
                        cart.Add(cartItem);
                        LoadList();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm này đã tồn tại trong giỏ hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm mã sản phẩm");
                }
            }else
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }    
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && int.Parse(txtQuantity.Text) > 0)
            {
                long productID = long.Parse(txtProductID.Text);
                var cartItem = cart.Where(x => x.ProductID == productID).FirstOrDefault();
                int index = cart.FindIndex(a => a.ProductID == productID);
                cartItem.Quantity = int.Parse(txtQuantity.Text);
                cart[index] = cartItem;
                LoadList();
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }
        }
        private void btPayment_Click(object sender, EventArgs e)
        {
            Frm_Checkout form = new Frm_Checkout();
            form.EmployeeName = employee.FirstName + " " +employee.LastName;
            form.EmployeeID = employee.ID;
            form.CartTotal = cart.Sum(x => x.Total);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                OrderModel orderModel = new OrderModel();
                Order order = new Order();
                order.CustomerID = form.CustomerID;
                order.EmployeeID = employee.ID;
                order.CreatedDate = DateTime.Now;
                long OrderID = orderModel.Add(order);
                OrderDetailModel orderDetailModel = new OrderDetailModel();
                foreach (var item in cart)
                {
                    OrderDetail orderDetail = new OrderDetail(item.ProductID, OrderID, item.Quantity, item.CurrentPrice);
                    orderDetailModel.Add(orderDetail);
                }
                MessageBox.Show("Thanh toán thành công","Thông báo");
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            var product = productModel.GetByID(txtProductID.Text);
            if (product != null)
            {
                txtProductName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();
                txtDiscount.Text = product.Discount.ToString();
            }
            else
            {
                txtProductName.Clear();
                txtDiscount.Clear();
                txtPrice.Clear();
                txtTotal.Clear();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                int quantity;
                float price = float.Parse(txtPrice.Text);
                float discount = float.Parse(txtDiscount.Text);

                if (txtQuantity.Text == "")
                    quantity = 0;
                else
                    quantity = int.Parse(txtQuantity.Text);

                txtTotal.Text = ((price - price * discount / 100) * quantity).ToString();
            }
            
        }
        private void dgvListAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row;
            row = dgvListAll.Rows[e.RowIndex];
            txtProductID.Text = Convert.ToString(row.Cells["ProductID"].Value);
            txtProductName.Text = Convert.ToString(row.Cells["ProductName"].Value);
            txtQuantity.Text = Convert.ToString(row.Cells["Quantity"].Value);
            txtDiscount.Text = Convert.ToString(row.Cells["Discount"].Value);
            txtPrice.Text = Convert.ToString(row.Cells["Price"].Value);
            txtTotal.Text = Convert.ToString(row.Cells["Total"].Value);
            txtProductID.Enabled = false;
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            long productID = long.Parse(txtProductID.Text);
            int index = cart.FindIndex(a => a.ProductID == productID);
            cart.RemoveAt(index);
            LoadList();
            Clear();
        }
        private void Clear()
        {
            txtDiscount.Clear();
            txtPrice.Clear();
            txtProductID.Clear();
            txtQuantity.Clear();
            txtTotal.Clear();
            txtProductID.Enabled = true;
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}