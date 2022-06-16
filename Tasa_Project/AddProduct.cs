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
    public partial class AddProduct : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();

        public AddProduct()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:2711/");
        }

        //Home
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

        //Logout
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

        //Add Product Button , Check Product Name , Category and Size before Add
        private void button1_Click(object sender, EventArgs e)
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
                    List<String> productsname = new List<string>();
                    List<String> productscategory = new List<string>();
                    List<String> productssize = new List<string>();

                    DataTable table = new DataTable();
                    DataTable table1 = new DataTable();
                    DataTable table2 = new DataTable();

                    SqlConnection CONN = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                    SqlConnection CONN1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                    SqlConnection CONN2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                    SqlCommand command = new SqlCommand();
                    SqlCommand command1 = new SqlCommand();
                    SqlCommand command2 = new SqlCommand();

                    command.Connection = CONN;
                    command.CommandText = "select [Prod_Name] from Products";

                    command1.Connection = CONN1;
                    command1.CommandText = "select [Prod_Category] from Products where Prod_Name = '" + pname + "' ";

                    command2.Connection = CONN2;
                    command2.CommandText = "select [Prod_Size] from Products where Prod_Name = '" + pname + "' ";

                    CONN.Open();
                    CONN1.Open();
                    CONN2.Open();

                    table.Load(command.ExecuteReader());
                    table1.Load(command1.ExecuteReader());
                    table2.Load(command2.ExecuteReader());

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        productsname.Add(table.Rows[i][0].ToString());
                    }
                    for (int i = 0; i < table1.Rows.Count; i++)
                    {
                        productscategory.Add(table1.Rows[i][0].ToString());
                    }
                    for (int i = 0; i < table2.Rows.Count; i++)
                    {
                        productssize.Add(table2.Rows[i][0].ToString());
                    }

                    if (productsname.Contains(pname) && productscategory.Contains(pcategory) && productssize.Contains(psize))
                    {
                        MessageBox.Show("هذا المنتج تم اضافته من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show("هل متأكد من اضافه منتج جديد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            Product product = new Product();

                            product.Prod_Name = pname;
                            product.Prod_Category = pcategory;
                            product.Prod_Price = pprice;
                            product.Prod_Size = psize;

                            HttpResponseMessage message = client.PostAsJsonAsync("api/products", product).Result;

                            if (message.IsSuccessStatusCode)
                            {
                                MessageBox.Show("تم اضافه البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CONN.Close();
                                CONN1.Close();
                                CONN2.Close();

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
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}