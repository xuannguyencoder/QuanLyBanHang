using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class ProductCategory
    {
        public ProductCategory()
        {

        }
        public ProductCategory(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
