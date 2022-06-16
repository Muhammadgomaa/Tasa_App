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
    public partial class SupplierPage : DevExpress.XtraEditors.XtraForm
    {
        public SupplierPage()
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

        #region Add Supplier
        private void bunifuCards2_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        #endregion

        #region Update Supplier
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            UpdateSupplier updateSupplier = new UpdateSupplier();

            if (updateSupplier == null)
            {
                this.Hide();
                updateSupplier.Show();
            }
            else
            {
                this.Hide();
                updateSupplier.Show();
                updateSupplier.Focus();
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

        #region Delete Supplier
        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            DeleteSupplier deleteSupplier = new DeleteSupplier();

            if (deleteSupplier == null)
            {
                this.Hide();
                deleteSupplier.Show();
            }
            else
            {
                this.Hide();
                deleteSupplier.Show();
                deleteSupplier.Focus();
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

        #region All Suppliers
        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            AllSuppliers allSuppliers = new AllSuppliers();

            if (allSuppliers == null)
            {
                this.Hide();
                allSuppliers.Show();
            }
            else
            {
                this.Hide();
                allSuppliers.Show();
                allSuppliers.Focus();
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