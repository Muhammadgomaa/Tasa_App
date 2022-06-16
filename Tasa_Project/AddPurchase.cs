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
    public partial class AddPurchase : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        public AddPurchase()
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

        //Get Suppliers Name
        private void AddPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                suppname.DisplayMember = "Supp_Name";
                suppname.ValueMember = "Supp_ID";

                HttpResponseMessage message = client.GetAsync("api/suppliers").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Supplier> suppliers = message.Content.ReadAsAsync<List<Supplier>>().Result;
                    suppname.DataSource = suppliers.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Add Purchase Button , Check for Purchase Details before Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pdetails = details.Text;
                string pcost = cost.Text;
                string pquantity = quantity.Text;
                string sname = suppname.Text;

                if (pdetails.Equals("") || sname.Equals("") || pcost.Equals("0.00") || pquantity.Equals("0"))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    HttpResponseMessage message = client.GetAsync("api/purchases").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        List<Purchase> purchases = message.Content.ReadAsAsync<List<Purchase>>().Result;
                        Purchase purchase = purchases.Where(n => n.Purch_Details == pdetails).SingleOrDefault();

                        if(purchase != null)
                        {
                            MessageBox.Show("عمليه الشراء تلك تم اضافتها من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult result;
                            result = MessageBox.Show("هل متأكد من اضافه عميله شراء جديده", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                Purchase purchase1 = new Purchase();

                                purchase1.Supp_ID = int.Parse(suppname.SelectedValue.ToString());
                                purchase1.Supp_Name = suppname.Text;
                                purchase1.Purch_Details = details.Text;
                                purchase1.Purch_Quantity = quantity.Value.ToString();
                                purchase1.Purch_Cost = cost.Value.ToString();

                                HttpResponseMessage message1 = client.PostAsJsonAsync("api/purchases", purchase1).Result;

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