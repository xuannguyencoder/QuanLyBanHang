using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class OrderDetail
    {
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public OrderDetail(long ProductID, long OrderID, int Quantity, float Price)
        {
            this.ProductID = ProductID;
            this.OrderID = OrderID; 
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
