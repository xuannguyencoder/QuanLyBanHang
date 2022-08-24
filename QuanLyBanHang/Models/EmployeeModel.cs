using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class EmployeeModel
    {
        ConnectDB db;
        public EmployeeModel()
        {
            db = new ConnectDB();
        }
        public DataTable GetAll()
        {
            DataTable dt = db.LayDuLieu("SELECT * from Employee Order By ID DESC");
            return dt;
        }
        public Employee GetByID(long ID)
        {
            try
            {
                string sql = "SELECT * FROM Employee Where ID = " + ID;
                DataTable dt = db.LayDuLieu(sql);
                if (dt.Rows.Count == 1)
                {
                    Employee employee = new Employee();
                    employee.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                    employee.LastName = dt.Rows[0]["LastName"].ToString();
                    employee.FirstName = dt.Rows[0]["FirstName"].ToString();
                    employee.Address = dt.Rows[0]["Address"].ToString();
                    employee.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    employee.Email = dt.Rows[0]["Email"].ToString();
                    employee.Gender = dt.Rows[0]["Gender"].ToString();
                    return employee;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public bool Insert(Employee employee)
        {
            try
            {
                string sql = String.Format("INSERT INTO Employee(FirstName,LastName,Address,PhoneNumber,Email,Gender)" +
                    "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", employee.FirstName, employee.LastName, employee.Address, employee.PhoneNumber, employee.Email, employee.Gender);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Employee employee)
        {
            try
            {
                string sql = String.Format("UPDATE Employee SET FirstName = N'{0}', LastName = N'{1}'," +
                    "Address = N'{2}', PhoneNumber = N'{3}', Gender = N'{4}', Email =  N'{5}'  WHERE ID = {6}", employee.FirstName, employee.LastName, employee.Address, employee.PhoneNumber, employee.Gender, employee.Email, employee.ID);
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
                db.ThucThi("DELETE Employee WHERE ID=" + ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
