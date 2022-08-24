using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class ProductModel
    {
        ConnectDB db;
        public ProductModel()
        {
            db = new ConnectDB();
        }
        public DataTable GetAll()
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM Product, ProductCategory Where ProductCategoryID = ProductCategory.ID ORDER BY Product.ID DESC");
            return dt;
        }
        public DataTable GetListByCategoryID(int ID)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM Product LEFT JOIN ProductCategory ON ProductCategoryID = ProductCategory.ID WHERE ProductCategoryID ="+ID);
            return dt;
        }

        public Product GetByID(string ID)
        {
            try
            {
                string sql = "SELECT * FROM Product Where ID = "+ID;
                DataTable dt = db.LayDuLieu(sql);
                if (dt.Rows.Count == 1)
                {
                    Product product = new Product();
                    product.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                    product.Price = float.Parse(dt.Rows[0]["Price"].ToString());
                    product.Discount = float.Parse(dt.Rows[0]["Discount"].ToString());
                    product.Description = dt.Rows[0]["Description"].ToString();
                    product.Image = (byte[])dt.Rows[0]["Image"];

                    product.Name = dt.Rows[0]["Name"].ToString();
                    product.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                    product.ProductCategoryID = int.Parse(dt.Rows[0]["ProductCategoryID"].ToString());
                    return product;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public bool Insert(Product product)
        {
            try
            {
                if (product.Image!=null)
                {
                    string sql = String.Format("INSERT INTO Product(ProductCategoryID,Name,Description,Price,Discount,Quantity,Image)" +
                    "Values({0},N'{1}',N'{2}',{3},{4},{5},@image)", product.ProductCategoryID, product.Name,
                    product.Description, product.Price, product.Discount, product.Quantity);
                    ConnectDB db = new ConnectDB();
                    db.conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                    {
                        cmd.Parameters.AddWithValue("@image", product.Image);
                        cmd.ExecuteNonQuery();
                    }
                    db.conn.Close();
                }
                else
                {
                    string sql = String.Format("INSERT INTO Product(ProductCategoryID,Name,Description,Price,Discount,Quantity)" +
                    "Values({0},N'{1}',N'{2}',{3},{4},{5})", product.ProductCategoryID, product.Name,
                    product.Description, product.Price, product.Discount, product.Quantity);
                    db.ThucThi(sql);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Product product)
        {
            try
            {
                if (product.Image !=null)
                {
                    string sql = String.Format("UPDATE Product SET ProductCategoryID = {0}, Name = N'{1}', " +
                    "Description = N'{2}', Price = {3}, Discount = {4}, Quantity = {5},Image=@image  WHERE ID = {6}",
                    product.ProductCategoryID, product.Name, product.Description, product.Price, product.Discount,
                    product.Quantity, product.ID);
                    ConnectDB db = new ConnectDB();
                    db.conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                    {
                        cmd.Parameters.AddWithValue("@image", product.Image);
                        cmd.ExecuteNonQuery();
                    }
                    db.conn.Close();
                }
                else
                {
                    string sql = String.Format("UPDATE Product SET ProductCategoryID = {0}, Name = N'{1}', " +
                    "Description = N'{2}', Price = {3}, Discount = {4}, Quantity = {5}  WHERE ID = {6}",
                    product.ProductCategoryID, product.Name, product.Description, product.Price, product.Discount,
                    product.Quantity, product.ID);
                    db.ThucThi(sql);
                }
               
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
                db.ThucThi("DELETE Product WHERE ID=" + ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
