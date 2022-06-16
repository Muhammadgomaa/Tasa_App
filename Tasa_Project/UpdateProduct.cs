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
    public partial class UpdateProduct : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        HttpClient client = new HttpClient();
        int index;

        public UpdateProduct()
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

        //Update Product Button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string pname = name.Text;
                float pprice = float.Parse(price.Text);
                string pcategory = category.Text;
                string psize = size.Text;

                if (pname.Equals("") || pcategory.Equals("") || pprice.Equals("0.00"))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من تعديل بيانات المنتج", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        Product product = dB.Products.Where(n => n.Prod_Code == index).SingleOrDefault();

                        product.Prod_Name = pname;
                        product.Prod_Category = pcategory;
                        product.Prod_Price = pprice;
                        product.Prod_Size = psize;

                        HttpResponseMessage message = client.PutAsJsonAsync($"api/products/{index}",product).Result;

                        if (message.IsSuccessStatusCode)
                        {
                            MessageBox.Show("تم تعديل البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            button1_Click(sender, e);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Preview Product Information
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Products.Select(n => new { Product_Code = n.Prod_Code, Product_Name = n.Prod_Name, Product_Category = n.Prod_Category, Product_Size = n.Prod_Size , Product_Price = n.Prod_Price }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Product to Update its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                try
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من اختيار كود المنتج الصحيح", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        Product product = dB.Products.Where(n => n.Prod_Code == index).SingleOrDefault();

                        name.Text = product.Prod_Name;
                        price.Value = decimal.Parse(product.Prod_Price.ToString());
                        category.Text = product.Prod_Category;
                        size.Text = product.Prod_Size;
                        
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("برجاء اختيار كود المنتج", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود المنتج", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}