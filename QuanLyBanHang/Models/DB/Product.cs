using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class Product
    {
        public long ID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public string ProductCategoryName {
            get
            {
                ProductCategoryModel categoryModel = new ProductCategoryModel();
                var cate = categoryModel.GetByID(ProductCategoryID);
                return cate.Name;
            }
        }
    }
}
