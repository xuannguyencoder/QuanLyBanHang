using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_ProductDetail : Form
    {
        public int Quantity { get; set; }
        public Product product { get; set; }

        public Frm_ProductDetail()
        {
            InitializeComponent();
        }

        private void btAddCart_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(txtQuantity.Text);
            if (quantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0", "Thông báo");
            }
            else
            {
                if (product.Quantity >= quantity)
                {
                    Quantity = Convert.ToInt32(txtQuantity.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Số lượng sản phẩm tối đa là " + product.Quantity,"Thông báo");
                }
            }
        }

        private void Frm_ProductDetail_Load(object sender, EventArgs e)
        {
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 350;
            pictureBox.Height = 300;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.BackgroundImage = ConvertByteArrayToImage(product.Image);
            pictureBox.BorderStyle = BorderStyle.Fixed3D;

            flowLayoutPanel1.Controls.Add(pictureBox);
            if (product.Discount > 0)
            {
                txtPrice.Text = (product.Price - (product.Price * product.Discount) / 100).ToString();
            }
            else
            {
                txtPrice.Text = product.Price.ToString();
            }
        }

        private Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
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