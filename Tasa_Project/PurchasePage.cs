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
    public partial class PurchasePage : DevExpress.XtraEditors.XtraForm
    {
        public PurchasePage()
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

        #region Add Purchase Transaction
        private void bunifuCards2_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        #endregion

        #region Update Purchase Transaction
        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            UpdatePurchase updatePurchase = new UpdatePurchase();

            if (updatePurchase == null)
            {
                this.Hide();
                updatePurchase.Show();
            }
            else
            {
                this.Hide();
                updatePurchase.Show();
                updatePurchase.Focus();
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

        #region Delete Purchase Transaction
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            DeletePurchase deletePurchase = new DeletePurchase();

            if (deletePurchase == null)
            {
                this.Hide();
                deletePurchase.Show();
            }
            else
            {
                this.Hide();
                deletePurchase.Show();
                deletePurchase.Focus();
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

        #region All Purchases Transactions
        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            AllPurchases allPurchases = new AllPurchases();

            if (allPurchases == null)
            {
                this.Hide();
                allPurchases.Show();
            }
            else
            {
                this.Hide();
                allPurchases.Show();
                allPurchases.Focus();
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