using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Reportings
{
    public class OrderReporting
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public long OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total {
            get
            {
                return Price * Quantity;
            } 
        }
    }
}
