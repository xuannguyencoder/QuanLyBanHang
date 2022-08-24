using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class Order
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long EmployeeID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
