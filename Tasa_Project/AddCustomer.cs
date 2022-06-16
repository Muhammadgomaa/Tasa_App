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
    public partial class AddCustomer : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();

        public AddCustomer()
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

        //Add Customer Button , Check for Phone Number before Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cname = name.Text;
                string cphone = phone.Text;
                string caddress = address.Text;

                if (cname.Equals("") || caddress.Equals("") || cphone.Equals("") || cphone.Length != 11)
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HttpResponseMessage message = client.GetAsync("api/customers").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        List<Customer> customers = message.Content.ReadAsAsync<List<Customer>>().Result;
                        Customer customer = customers.Where(n => n.Cus_Phone == cphone).SingleOrDefault();

                        if(customer != null)
                        {
                            MessageBox.Show("هذا العميل تم اضافته من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult result;
                            result = MessageBox.Show("هل متأكد من اضافه عميل جديد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                Customer customer1 = new Customer();

                                customer1.Cus_Name = cname;
                                customer1.Cus_Address = caddress;
                                customer1.Cus_Phone = cphone;

                                HttpResponseMessage message1 = client.PostAsJsonAsync("api/customers", customer1).Result;

                                if (message1.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("تم اضافه البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}