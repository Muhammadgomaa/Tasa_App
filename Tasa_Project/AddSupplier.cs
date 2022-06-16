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
    public partial class AddSupplier : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        public AddSupplier()
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

        //Add Supplier Button , Check for Supplier Phone before Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string supname = name.Text;
                string supphone = phone.Text;

                if (supname.Equals("") || supphone.Equals("") || supphone.Length != 11)
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HttpResponseMessage message = client.GetAsync("api/suppliers").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        List<Supplier> suppliers = message.Content.ReadAsAsync<List<Supplier>>().Result;
                        Supplier supplier = suppliers.Where(n => n.Supp_Phone == supphone).FirstOrDefault();

                        if(supplier != null)
                        {
                            MessageBox.Show("هذا المورد تم اضافته من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            DialogResult result;
                            result = MessageBox.Show("هل متأكد من اضافه مورد جديد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                Supplier supplier1 = new Supplier();

                                supplier1.Supp_Name = supname;
                                supplier1.Supp_Phone = supphone;

                                HttpResponseMessage message1 = client.PostAsJsonAsync("api/suppliers", supplier1).Result;

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