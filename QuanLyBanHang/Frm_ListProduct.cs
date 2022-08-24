using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_ListProduct : Form
    {
        private ProductModel productModel = new ProductModel();
        private ProductCategoryModel cateModel = new ProductCategoryModel();
        private List<CartItem> cart = new List<CartItem>();
        private Employee employee { get; set; }

        public Frm_ListProduct()
        {
            InitializeComponent();
        }

        private void LoadList()
        {
            lboxCart.Items.Clear();
            foreach (var item in cart.ToList())
            {
                lboxCart.Items.Add(string.Format("{0} - {1} - {2} - {3}", item.ProductID, item.ProductName, item.Quantity, item.CurrentPrice));
            }
            int visibleItems = lboxCart.ClientSize.Height / lboxCart.ItemHeight;
            lboxCart.TopIndex = Math.Max(lboxCart.Items.Count - visibleItems + 1, 0);
        }

        private void Frm_ListProduct_Load(object sender, EventArgs e)
        {
            var cate = cateModel.GetFirst();
            if (cate == null)
                GetAllProduct(0);
            else
                GetAllProduct(cate.ID);
            GetMenu();
        }

        private void GetAllProduct(int categoryID)
        {
            DataTable dt = productModel.GetListByCategoryID(categoryID);

            Label lbPrice2;
            Label lbPriceCurrent;
            Label lbPriceOld;
            Label lbName;
            PictureBox pic;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var image = (byte[])dt.Rows[i]["Image"];
                pic = new PictureBox();
                pic.Width = 200;
                pic.Height = 200;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = ConvertByteArrayToImage(image);
                pic.BorderStyle = BorderStyle.Fixed3D;
                int index = i;
                pic.Click += (sender, e) =>
                {
                    long ID = int.Parse(dt.Rows[index]["ID"].ToString());

                    ProductModel productModel = new ProductModel();
                    Frm_ProductDetail frm = new Frm_ProductDetail();
                    frm.product = productModel.GetByID(ID.ToString());
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        AddCart(ID, frm.Quantity);
                    }
                };

                lbPriceCurrent = new Label();
                lbPriceCurrent.Dock = DockStyle.Left;
                lbPriceCurrent.TextAlign = ContentAlignment.MiddleLeft;
                lbPriceCurrent.Font = new Font("Roboto Condensed", 12, FontStyle.Bold);
                lbPriceCurrent.BackColor = Color.FromArgb(229, 200, 96);
                lbPriceCurrent.Width = 100;

                lbPrice2 = new Label();
                lbPrice2.TextAlign = ContentAlignment.MiddleCenter;
                lbPrice2.Width = pic.Width;
                lbPrice2.Dock = DockStyle.Top;
                //Promotion
                long discount = long.Parse(dt.Rows[i]["Discount"].ToString());
                if (discount != 0)
                {
                    long price = long.Parse(dt.Rows[i]["Price"].ToString());
                    long priceCurrent = price - (price * discount) / 100;

                    lbPriceOld = new Label();
                    lbPriceOld.Text = float.Parse(dt.Rows[i]["Price"].ToString()).ToString("N0") + "đ";
                    lbPriceOld.Font = new Font("Roboto Condensed", 12, FontStyle.Strikeout);
                    lbPriceOld.Dock = DockStyle.Right;
                    lbPriceOld.TextAlign = ContentAlignment.MiddleRight;
                    lbPriceOld.BackColor = Color.FromArgb(235, 140, 95);
                    lbPriceOld.Width = 100;

                    lbPriceCurrent.Text = priceCurrent.ToString("N0") + "đ";
                    lbPrice2.Controls.Add(lbPriceOld);
                }
                else
                {
                    lbPriceCurrent.Text = float.Parse(dt.Rows[i]["Price"].ToString()).ToString("N0") + "đ";
                    lbPriceCurrent.Width = 200;
                }

                lbPrice2.Controls.Add(lbPriceCurrent);

                lbName = new Label();
                lbName.Text = dt.Rows[i]["Name"].ToString();
                lbName.Dock = DockStyle.Bottom;
                lbName.BackColor = Color.FromArgb(235, 140, 95);
                lbName.TextAlign = ContentAlignment.MiddleCenter;

                pic.Controls.Add(lbPrice2);
                pic.Controls.Add(lbName);
                flowLayoutPanel2.Controls.Add(pic);
            }
        }

        private void AddCart(long ID, int Quantity)
        {
            ProductModel productModel = new ProductModel();
            var product = productModel.GetByID(ID.ToString());
            if (product != null)
            {
                if (cart.Where(x => x.ProductID == product.ID).Count() == 0)
                {
                    CartItem cartItem = new CartItem(product, Quantity);
                    cart.Add(cartItem);
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã tồn tại trong giỏ hàng");
                }
            }
        }

        private void GetMenu()
        {
            DataTable dt = cateModel.GetAll();

            Button itemMenu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itemMenu = new Button();
                itemMenu.Width = 200;
                itemMenu.Height = 50;
                itemMenu.Text = dt.Rows[i]["Name"].ToString();
                itemMenu.FlatStyle = FlatStyle.Flat;
                itemMenu.BackColor = Color.FromArgb(50, 157, 160);
                itemMenu.BackgroundImageLayout = ImageLayout.Stretch;
                itemMenu.ForeColor = Color.White;
                int index = i;
                itemMenu.Click += (sender, e) =>
                {
                    int cateID = int.Parse(dt.Rows[index]["ID"].ToString());
                    flowLayoutPanel2.Controls.Clear();
                    GetAllProduct(cateID);
                };
                flowLayoutPanel1.Controls.Add(itemMenu);
            }
        }

        private Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            long ID = 0;
            int count = lboxCart.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                var item = lboxCart.SelectedItems[0].ToString();

                string[] arrListStr = item.Split('-');
                ID = long.Parse(arrListStr[0].Trim());
            }
            int index = cart.FindIndex(a => a.ProductID == ID);
            cart.RemoveAt(index);
            LoadList();
        }

        private void btPayment_Click(object sender, EventArgs e)
        {
            if (cart != null && cart.Count > 0)
            {
                if (employee != null)
                {
                    Checkout();
                }
                else
                {
                    Frm_Login form = new Frm_Login();
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        UserModel userModel = new UserModel();
                        var user = userModel.GetByUsername(form.username);
                        EmployeeModel employeeModel = new EmployeeModel();
                        employee = employeeModel.GetByID(user.EmployeeID);
                        Checkout();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào giỏ hàng");
            }
        }

        public void Checkout()
        {
            Frm_Checkout form = new Frm_Checkout();
            form.EmployeeName = employee.FirstName + " " + employee.LastName;
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
                MessageBox.Show("Thanh toán thành công", "Thông báo");
                cart.Clear();
                LoadList();
                Frm_OrderReporting frm = new Frm_OrderReporting();
                frm.OrderID = OrderID;
                frm.ShowDialog();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNewOrder_Click(object sender, EventArgs e)
        {
            cart.Clear();
            lboxCart.Items.Clear();
        }
    }
}