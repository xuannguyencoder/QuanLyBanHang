using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class ProductCategoryModel
    {

        ConnectDB db;
        public ProductCategoryModel()
        {
            db = new ConnectDB();
        }
        public DataTable GetAllOrderByDESC()
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM ProductCategory ORDER BY ID DESC");
            return dt;
        }
        public DataTable GetAll()
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM ProductCategory");
            return dt;
        }
        public ProductCategory GetFirst()
        {
            string sql = "SELECT TOP 1 *  FROM ProductCategory";
            DataTable dt = db.LayDuLieu(sql);
            if (dt.Rows.Count == 1)
            {
                ProductCategory productCate = new ProductCategory();
                productCate.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                productCate.Name = dt.Rows[0]["Name"].ToString();
                return productCate;
            }
            return null;
        }

        public ProductCategory GetByID(int ID)
        {
            string sql = "SELECT * FROM ProductCategory Where ID = " + ID;
            DataTable dt = db.LayDuLieu(sql);
            if (dt.Rows.Count == 1)
            {
                ProductCategory productCate = new ProductCategory();
                productCate.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                productCate.Name = dt.Rows[0]["Name"].ToString();
                return productCate;
            }
            return null;
        }

        public bool Insert(ProductCategory productCate)
        {
            try
            {
                string sql = String.Format("Insert INTO ProductCategory(Name) VALUES(N'{0}')", productCate.Name);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(ProductCategory productCate)
        {
            try
            {
                string sql = String.Format("Update ProductCategory SET Name = N'{0}' WHERE ID = {1}", productCate.Name, productCate.ID);
                db.ThucThi(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            try
            {
                db.ThucThi("DELETE ProductCategory WHERE ID=" + ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
