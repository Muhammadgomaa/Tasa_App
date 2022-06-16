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
    public partial class DeleteSupplier : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();
        int index;

        public DeleteSupplier()
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

        //Supplier Page 
        private void button1_Click(object sender, EventArgs e)
        {
            SupplierPage supplierPage = new SupplierPage();

            if (supplierPage == null)
            {
                this.Hide();
                supplierPage.Show();
            }
            else
            {
                this.Hide();
                supplierPage.Show();
                supplierPage.Focus();
            }
        }

        //Preview Supplier Information
        private void DeleteSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage message = client.GetAsync("api/suppliers").Result;

                if (message.IsSuccessStatusCode)
                {
                    List<Supplier> suppliers = message.Content.ReadAsAsync<List<Supplier>>().Result;
                    dataGridView1.DataSource = suppliers.Select(n => new { Supplier_ID = n.Supp_ID, Supplier_Name = n.Supp_Name, Supplier_Phone = n.Supp_Phone }).ToList();
                    total.Text = suppliers.Count().ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Supplier to Delete its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من مسح بيانات المورد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        HttpResponseMessage message1 = client.DeleteAsync($"api/suppliers/{index}").Result;

                        if (message1.IsSuccessStatusCode)
                        {
                            MessageBox.Show("تم مسح البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            button1_Click(sender, e);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("برجاء اختيار كود المورد", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود المورد", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}