using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class CustomerModel
    {
        ConnectDB db;
        public CustomerModel()
        {
            db = new ConnectDB();
        }
        public DataTable GetAll()
        {
            DataTable dt = db.LayDuLieu("SELECT * from Customer Order By ID DESC");
            return dt;
        }
        public DataTable GetByName(string Name)
        {
            string query = string.Format("SELECT * from Customer WHERE FirstName +' '+ LastName LIKE N'%{0}%'", Name);
            DataTable dt = db.LayDuLieu(query);
            return dt;
        }
        public Customer GetByID(long ID)
        {
            try
            {
                string sql = "SELECT * FROM Customer Where ID = " + ID;
                DataTable dt = db.LayDuLieu(sql);
                if (dt.Rows.Count == 1)
                {
                    Customer customer = new Customer();

                    customer.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                    customer.LastName = dt.Rows[0]["LastName"].ToString();
                    customer.FirstName = dt.Rows[0]["FirstName"].ToString();
                    customer.Address = dt.Rows[0]["Address"].ToString();
                    customer.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    customer.Email = dt.Rows[0]["Email"].ToString();
                    customer.Gender = dt.Rows[0]["Gender"].ToString();
                    return customer;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool Insert(Customer customer)
        {
            try
            {
                string sql = String.Format("INSERT INTO Customer(FirstName,LastName,Address,PhoneNumber,Email,Gender)" +
                    "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", customer.FirstName, customer.LastName, customer.Address, customer.PhoneNumber, customer.Email, customer.Gender);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Customer customer)
        {
            try
            {
                string sql = String.Format("UPDATE Customer SET FirstName = N'{0}', LastName = N'{1}'," +
                    "Address = N'{2}', PhoneNumber = N'{3}', Gender = N'{4}', Email =  N'{5}'  WHERE ID = {6}", customer.FirstName, customer.LastName, customer.Address, customer.PhoneNumber, customer.Gender, customer.Email, customer.ID);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long ID)
        {
            try
            {
                db.ThucThi("DELETE Customer WHERE ID=" + ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
