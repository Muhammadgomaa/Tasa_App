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
using System.Net.Http;

namespace Tasa_Project
{
    public partial class DeleteProduct : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        HttpClient client = new HttpClient();
        int index;

        public DeleteProduct()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:2711/");
            dB = new DB_Context();
        }

        private void home_Click(object sender, EventArgs e)
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

        //Product Page 
        private void button1_Click(object sender, EventArgs e)
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

        //Preview Product Information
        private void DeleteProduct_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Products.Select(n => new { Product_Code = n.Prod_Code, Product_Name = n.Prod_Name, Product_Category = n.Prod_Category, Product_Size = n.Prod_Size, Product_Price = n.Prod_Price }).ToList();
                total.Text = dB.Products.Count().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Product to Delete its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من مسح المنتج", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        HttpResponseMessage message = client.DeleteAsync($"api/products/{index}").Result;

                        if (message.IsSuccessStatusCode)
                        {
                            MessageBox.Show("تم مسح البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            button1_Click(sender, e);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("برجاء اختيار كود المنتج", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود المنتج", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}