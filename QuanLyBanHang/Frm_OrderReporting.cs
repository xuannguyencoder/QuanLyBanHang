using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Reportings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_OrderReporting : Form
    {
        ConnectDB db = new ConnectDB();
        public long OrderID { get ; set; }
        public Frm_OrderReporting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OrderData(OrderID);
        }
        private void OrderData(long OrderID)
        {
            string sql = "SELECT Customer.FirstName + ' ' + Customer.LastName AS 'CustomerName', Customer.ID AS CustomerID, Customer.PhoneNumber AS CustomerPhone, " +
                "Employee.FirstName + ' ' + Employee.LastName AS 'EmployeeName', [Order].ID AS OrderID, [Order].CreatedDate, OrderDetail.Quantity, " +
                "OrderDetail.Price, ProductCategory.Name AS CategoryName, Product.Name AS ProductName, Product.ID AS ProductID, Employee.ID AS EmployeeID " +
                "FROM Customer INNER JOIN[Order] ON Customer.ID = [Order].CustomerID " +
                "INNER JOIN Employee ON Employee.ID = [Order].EmployeeID " +
                "INNER JOIN OrderDetail ON[Order].ID = OrderDetail.OrderID " +
                "INNER JOIN Product ON OrderDetail.ProductID = Product.ID " +
                "INNER JOIN ProductCategory ON Product.ProductCategoryID = ProductCategory.ID " +
                "WHERE [Order].ID = "+ OrderID;
            DataTable dt = db.LayDuLieu(sql);
            List<OrderReporting> orderReportings = new List<OrderReporting>();
            OrderReporting orderReporting;
            for (int i = 0; i<dt.Rows.Count;i++)
            {
                orderReporting  = new OrderReporting();
                orderReporting.CategoryName = dt.Rows[i]["CategoryName"].ToString();

                orderReporting.CustomerID = long.Parse(dt.Rows[i]["CustomerID"].ToString());
                orderReporting.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                orderReporting.CustomerPhone = dt.Rows[i]["CustomerPhone"].ToString();

                orderReporting.EmployeeID = long.Parse(dt.Rows[i]["EmployeeID"].ToString());
                orderReporting.EmployeeName = dt.Rows[i]["EmployeeName"].ToString();

                orderReporting.OrderID = long.Parse(dt.Rows[i]["OrderID"].ToString());
                orderReporting.OrderDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());

                orderReporting.ProductName = dt.Rows[i]["ProductName"].ToString();
                orderReporting.ProductID = long.Parse(dt.Rows[i]["ProductID"].ToString());

                orderReporting.Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString());
                orderReporting.Price = float.Parse(dt.Rows[i]["Price"].ToString());
                orderReportings.Add(orderReporting);
            }

            var rpDataSource = new ReportDataSource("OrderReportingDataSet", orderReportings);
            rpOrder.LocalReport.ReportPath = "OrderReporting.rdlc";
            rpOrder.LocalReport.DataSources.Clear();
            rpOrder.LocalReport.DataSources.Add(rpDataSource);
            rpOrder.RefreshReport();
        }
    }
}
