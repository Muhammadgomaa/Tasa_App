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
    public partial class UpdateCustomer : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        int index;

        public UpdateCustomer()
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

        //Preview Customer Information
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage message = client.GetAsync("api/customers").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Customer> customers = message.Content.ReadAsAsync<List<Customer>>().Result;

                    dataGridView1.DataSource = customers.Select(n => new
                    {
                        Customer_ID = n.Cus_ID,
                        Customer_Name = n.Cus_Name,
                        Customer_Address = n.Cus_Address,
                        Customer_Phone = n.Cus_Phone
                    }).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Customer to Update its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                try
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من اختيار كود العميل الصحيح", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        HttpResponseMessage message1 = client.GetAsync("api/customers").Result;

                        if (message1.IsSuccessStatusCode)
                        {
                            List<Customer> customers = message1.Content.ReadAsAsync<List<Customer>>().Result;
                            Customer customer = customers.Where(n => n.Cus_ID == index).FirstOrDefault();

                            name.Text = customer.Cus_Name;
                            address.Text = customer.Cus_Address;
                            phone.Text = customer.Cus_Phone;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("برجاء اختيار كود العميل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود العميل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update Customer Button , Check for Customer Phone before Update
        private void button2_Click(object sender, EventArgs e)
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
                    HttpResponseMessage message2 = client.GetAsync("api/customers").Result;

                    if (message2.IsSuccessStatusCode)
                    {
                        List<Customer> customers = message2.Content.ReadAsAsync<List<Customer>>().Result;
                        Customer customer1 = customers.Where(n => n.Cus_Phone == cphone && n.Cus_Name != cname).FirstOrDefault();

                        if (customer1 != null)
                        {
                            MessageBox.Show("رقم الهاتف الذى ادخلته مسجل لدى عميل من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult result;
                            result = MessageBox.Show("هل متأكد من تعديل بيانات العميل", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                Customer customer2 = customers.Where(n => n.Cus_ID == index).SingleOrDefault();

                                customer2.Cus_Name = cname;
                                customer2.Cus_Phone = cphone;
                                customer2.Cus_Address = caddress;



                                HttpResponseMessage message3 = client.PutAsJsonAsync($"api/customers/{index}", customer2).Result;

                                if (message3.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("تم تعديل البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    button1_Click(sender, e);
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