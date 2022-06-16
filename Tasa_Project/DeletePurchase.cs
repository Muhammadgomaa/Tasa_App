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
    public partial class DeletePurchase : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        int index;

        public DeletePurchase()
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

        //Preview Purchases Transaction Information
        private void DeletePurchase_Load(object sender, EventArgs e)
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
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Purchase to Delete its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من مسح عمليه الشراء", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        HttpResponseMessage message1 = client.DeleteAsync($"api/purchases/{index}").Result;

                        if (message1.IsSuccessStatusCode)
                        {
                            MessageBox.Show("تم مسح البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            button1_Click(sender, e);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("برجاء اختيار رقم العمليه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار رقم العمليه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}