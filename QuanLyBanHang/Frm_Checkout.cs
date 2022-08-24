using QuanLyBanHang.Models;
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
    public partial class Frm_Checkout : Form
    {
        public long CustomerID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public float CartTotal { get; set; }
        
        private CustomerModel customerModel = new CustomerModel();

        public Frm_Checkout()
        {
            InitializeComponent();

        }

        private void btPayment_Click(object sender, EventArgs e)
        {
            
            if (customerModel.GetByID(CustomerID)!=null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Frm_Checkout_Load(object sender, EventArgs e)
        {
            txtEmployeeID.Focus();
            txtCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEmployeeName.Text = EmployeeName.ToString();
            txtEmployeeID.Text = EmployeeID.ToString();
            txtCartTotal.Text = CartTotal.ToString();
            CustomerID = 0;
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            if (txtCustomerID.Text !="")
            {
                CustomerID = long.Parse(txtCustomerID.Text);
                var customer = customerModel.GetByID(CustomerID);
                if (customer != null)
                {
                    txtCustomerName.Text = customer.FirstName + " " + customer.LastName;
                }
            }
        }

        private void btSearchCustomer_Click(object sender, EventArgs e)
        {
            Frm_Customer frm = new Frm_Customer();
            frm.IsActive = true;
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                CustomerID = frm.CustomerID;
                var customer = customerModel.GetByID(CustomerID);
                if (customer != null)
                {
                    txtCustomerID.Text = CustomerID.ToString();
                    txtCustomerName.Text = customer.FirstName + " " + customer.LastName;
                }
            }
        }
    }
}
