using QuanLyBanHang.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class UserModel
    {
        ConnectDB db;
        public UserModel()
        {
            db = new ConnectDB();
        }

        public User GetByUsername(string username)
        {
            string sql = "SELECT * FROM [User] Where username = '" + username + "'";
            DataTable dt = db.LayDuLieu(sql);
            if (dt.Rows.Count==1)
            {
                User user = new User();
                user.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                user.Username = dt.Rows[0]["Username"].ToString();
                user.Password = dt.Rows[0]["Password"].ToString();
                user.EmployeeID = long.Parse(dt.Rows[0]["EmployeeID"].ToString());
                user.Status = bool.Parse(dt.Rows[0]["Status"].ToString());
                user.Role = int.Parse(dt.Rows[0]["Role"].ToString());
                return user;
            }
            return null;
        }
        
        public int Login(string username, string password)
        {
            string passswordHash = ConvertData.MD5Hash(password);
            var user = GetByUsername(username);
            if (user == null)
            {
                return 0; // không tồn tại
            }
            else
            {
                if (user.Status == false)
                    return -2; // tài khoản bị khóa
                if (user.Password == passswordHash)
                    return 1;
                return -1; //sai mật khẩu
            }
        }
        public bool Insert(long ID, string Username, string Password, string FirstName, string LastName, bool Status)
        {
            try
            {
                string sql = String.Format("Insert into User(ID,Username,Password,FirstName,LastName,Status)" +
                    "Values({0},N'{1}',N'{2}',N'{3}',N'{4}',{5})", ID, Username, Password, FirstName, LastName, Status);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(long ID, string Username, string Password, string FirstName, string LastName, bool Status)
        {
            try
            {
                string sql = String.Format("Update User SET Username = N'{0}', Password = N'{1}', " +
                    "FirstName = N'{2}', LastName = N'{3}', LastName = N'{4}', Status = {5}  WHERE ID = N'{6}'", Username, Password, FirstName, LastName, Status, ID);
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
                db.ThucThi("DELETE User WHERE ID=" + ID + "");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
