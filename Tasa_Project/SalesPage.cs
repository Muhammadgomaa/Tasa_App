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
    public partial class SalesPage : DevExpress.XtraEditors.XtraForm
    {
        public SalesPage()
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

        private void home_menu_Click(object sender, EventArgs e)
        {
            Main main = new Main();

            if (main == null)
            {
                this.Hide();
                main.Show();
            }
            else
            {
                this.Hide();
                main.Show();
                main.Focus();
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

        private void customer_menu_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage();

            if (customerPage == null)
            {
                this.Hide();
                customerPage.Show();
            }
            else
            {
                this.Hide();
                customerPage.Show();
                customerPage.Focus();
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

        #region Add Sales Transaction
        private void bunifuCards2_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        #endregion

        #region Delete Sales Transaction
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            DeleteSales deleteSales = new DeleteSales();

            if (deleteSales == null)
            {
                this.Hide();
                deleteSales.Show();
            }
            else
            {
                this.Hide();
                deleteSales.Show();
                deleteSales.Focus();
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

        #region Invoice Details
        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();

            if (invoiceDetails == null)
            {
                this.Hide();
                invoiceDetails.Show();
            }
            else
            {
                this.Hide();
                invoiceDetails.Show();
                invoiceDetails.Focus();
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

        #region All Sales
        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            AllSales allSales = new AllSales();

            if (allSales == null)
            {
                this.Hide();
                allSales.Show();
            }
            else
            {
                this.Hide();
                allSales.Show();
                allSales.Focus();
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
    }
}