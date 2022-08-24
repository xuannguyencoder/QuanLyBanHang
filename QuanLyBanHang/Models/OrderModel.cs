using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class OrderModel
    {
        ConnectDB db ;
        public OrderModel()
        {
            db = new ConnectDB();
        }
        public DataTable GetAll()
        {
            DataTable dt = db.LayDuLieu("SELECT * from Order Order BY ID DESC");
            return dt;
        }
        public long Add(Order order)
        {
            try
            {
                string sql = String.Format("INSERT INTO [Order](CustomerID,EmployeeID,CreatedDate)" +
                    "VALUES({0},{1},@OrderCreateDate)", order.CustomerID, order.EmployeeID);
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                SqlParameter sqlParameter = new SqlParameter("@OrderCreateDate", order.CreatedDate);
                cmd.Parameters.Add(sqlParameter);
                db.conn.Open();
                cmd.ExecuteNonQuery();
                db.conn.Close();


                string query2 = "Select TOP 1 * from [Order] ORDER BY CreatedDate DESC";

                DataTable dt = db.LayDuLieu(query2);
                return long.Parse(dt.Rows[0]["ID"].ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
}
