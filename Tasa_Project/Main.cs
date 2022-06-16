using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Tasa_Project
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("هل متأكد من تسجيل الخروج", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Application.OpenForms[0].Show();
                this.Close();
            }
        }

        private void product_menu_Click(object sender, EventArgs e)
        {
            ProductPage productPage = new ProductPage();

            if (productPage == null)
            {
                this.Hide();
                productPage.Show();
            }
            else
            {
                this.Hide();
                productPage.Show();
                productPage.Focus();
            }
        }

        private void supplier_menu_Click(object sender, EventArgs e)
        {
            SupplierPage supplierPage = new SupplierPage();

            if (supplierPage == null)
            {
                this.Hide();
                supplierPage.Show();
            }
            else
            {
                this.Hide();
                supplierPage.Show();
                supplierPage.Focus();
            }
        }

        private void purchase_menu_Click(object sender, EventArgs e)
        {
            PurchasePage purchasePage = new PurchasePage();

            if (purchasePage == null)
            {
                this.Hide();
                purchasePage.Show();
            }
            else
            {
                this.Hide();
                purchasePage.Show();
                purchasePage.Focus();
            }
        }

        private void customer_menu_Click(object sender, EventArgs e)
        {
            CustomerPage CustomerPage = new CustomerPage();

            if (CustomerPage == null)
            {
                this.Hide();
                CustomerPage.Show();
            }
            else
            {
                this.Hide();
                CustomerPage.Show();
                CustomerPage.Focus();
            }
        }

        private void sales_menu_Click(object sender, EventArgs e)
        {
            SalesPage salesPage = new SalesPage();

            if (salesPage == null)
            {
                this.Hide();
                salesPage.Show();
            }
            else
            {
                this.Hide();
                salesPage.Show();
                salesPage.Focus();
            }
        }

        private void setting_menu_Click(object sender, EventArgs e)
        {
            SettingPage settingPage = new SettingPage();

            if (settingPage == null)
            {
                this.Hide();
                settingPage.Show();
            }
            else
            {
                this.Hide();
                settingPage.Show();
                settingPage.Focus();
            }
        }

        #region Add Sales
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            AddSales addSales = new AddSales();

            if (addSales == null)
            {
                this.Hide();
                addSales.Show();
            }
            else
            {
                this.Hide();
                addSales.Show();
                addSales.Focus();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            bunifuCards1_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bunifuCards1_Click(sender, e);
        }

        #endregion

        #region Add Product
        private void bunifuCards2_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();

            if (addProduct == null)
            {
                this.Hide();
                addProduct.Show();
            }
            else
            {
                this.Hide();
                addProduct.Show();
                addProduct.Focus();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        #endregion

        #region Add Customer
        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();

            if (addCustomer == null)
            {
                this.Hide();
                addCustomer.Show();
            }
            else
            {
                this.Hide();
                addCustomer.Show();
                addCustomer.Focus();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            bunifuCards3_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            bunifuCards3_Click(sender, e);
        }

        #endregion

        #region Add Supplier
        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();

            if (addSupplier == null)
            {
                this.Hide();
                addSupplier.Show();
            }
            else
            {
                this.Hide();
                addSupplier.Show();
                addSupplier.Focus();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            bunifuCards4_Click(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            bunifuCards4_Click(sender, e);
        }

        #endregion

        #region Add Purchases
        private void bunifuCards5_Click(object sender, EventArgs e)
        {
            AddPurchase addPurchase = new AddPurchase();

            if (addPurchase == null)
            {
                this.Hide();
                addPurchase.Show();
            }
            else
            {
                this.Hide();
                addPurchase.Show();
                addPurchase.Focus();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            bunifuCards5_Click(sender, e);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            bunifuCards5_Click(sender, e);

        }
        #endregion

        #region Add User
        private void bunifuCards6_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            if (addUser == null)
            {
                this.Hide();
                addUser.Show();
            }
            else
            {
                this.Hide();
                addUser.Show();
                addUser.Focus();
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            bunifuCards6_Click(sender, e);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            bunifuCards6_Click(sender, e);
        }
        #endregion
    }
}