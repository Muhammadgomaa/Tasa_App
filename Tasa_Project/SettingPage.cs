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
    public partial class SettingPage : DevExpress.XtraEditors.XtraForm
    {
        public SettingPage()
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

        #region Add User
        private void bunifuCards2_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bunifuCards2_Click(sender, e);
        }

        #endregion

        #region Delete User
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser();

            if (deleteUser == null)
            {
                this.Hide();
                deleteUser.Show();
            }
            else
            {
                this.Hide();
                deleteUser.Show();
                deleteUser.Focus();
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

        #region Change Password
        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();

            if (changePassword == null)
            {
                this.Hide();
                changePassword.Show();
            }
            else
            {
                this.Hide();
                changePassword.Show();
                changePassword.Focus();
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

        #region Close Shift
        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            CloseShift closeShift = new CloseShift();

            if (closeShift == null)
            {
                this.Hide();
                closeShift.Show();
            }
            else
            {
                this.Hide();
                closeShift.Show();
                closeShift.Focus();
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