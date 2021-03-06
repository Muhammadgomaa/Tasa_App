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
    public partial class AllCustomers : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        public AllCustomers()
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

        //Customer Page 
        private void button1_Click(object sender, EventArgs e)
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

        //Preview Customers Information
        private void AllCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage message = client.GetAsync("api/customers").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Customer> customers = message.Content.ReadAsAsync<List<Customer>>().Result;

                    dataGridView1.DataSource = customers.Select(n => new
                    {
                        Customer_Name = n.Cus_Name,
                        Customer_Address = n.Cus_Address,
                        Customer_Phone = n.Cus_Phone
                    }).ToList();

                    total.Text = customers.Count().ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}