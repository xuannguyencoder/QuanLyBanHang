using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class OrderDetailModel
    {
        ConnectDB db;
        public OrderDetailModel()
        {
            db = new ConnectDB();
        }
        public DataTable DanhSach()
        {
            DataTable dt = db.LayDuLieu("SELECT * from OrderTail Order BY ID DESC");
            return dt;
        }
        public bool Add(OrderDetail orderDetail)
        {
            try
            {
                string sql = String.Format("INSERT INTO OrderDetail(ProductID,OrderID,Quantity,Price)" +
                    "Values({0},{1},{2},{3})", orderDetail.ProductID, orderDetail.OrderID, orderDetail.Quantity, orderDetail.Price);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
