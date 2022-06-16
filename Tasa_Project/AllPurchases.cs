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
    public partial class AllPurchases : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        public AllPurchases()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:2711/");
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

        //Purchase Page 
        private void button1_Click(object sender, EventArgs e)
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

        //Preview Purchases Transactions Information , Calculate Total Purchase Price
        private void AllPurchases_Load(object sender, EventArgs e)
        {
         
            try
            {
                HttpResponseMessage message = client.GetAsync("api/purchases").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Purchase> purchases = message.Content.ReadAsAsync<List<Purchase>>().Result;

                    dataGridView1.DataSource = purchases.Select(n => new {
                        Purchase_ID = n.Purch_ID,
                        Supplier_Name = n.Supp_Name,
                        Purchase_Details = n.Purch_Details,
                        Purchase_Quantity = n.Purch_Quantity,
                        Purchase_Cost = n.Purch_Cost
                    }).ToList();

                    List<string> Cost = new List<string>();
                    Cost = purchases.Select(n => n.Purch_Cost).ToList();
                    float Total = 0;
                    for (int i = 0; i < Cost.Count; i++)
                    {
                        Total += float.Parse(Cost[i]);
                    }

                    total.Text = Total.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}