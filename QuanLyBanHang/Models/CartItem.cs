using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class CartItem
    {
        public CartItem()
        {

        }
        public CartItem(Product product, int quantity)
        {
            this.product =product;
            Quantity = quantity;
        }
        private Product product { get; set; }
        public long ProductID
        {
            get { return product.ID; }
        }
        public string ProductName 
        {
            get { return product.Name; }
        }
        public string ProductCategoryName
        {
            get { return product.ProductCategoryName; }
        }
        public int Quantity { get; set; }
        public float Discount
        {
            get { return product.Discount; }
        }
        public float Price
        {
            get { return product.Price; }
        }
        public float Total
        {
            get
            {
                return CurrentPrice * Quantity;
            }
        }
        public float CurrentPrice
        {
            get
            {
                return Price - Price * Discount / 100;
            }
        }

    }
}
