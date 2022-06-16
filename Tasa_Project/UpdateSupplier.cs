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
    public partial class UpdateSupplier : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        HttpClient client = new HttpClient();
        int index;

        public UpdateSupplier()
        {
            InitializeComponent();
            dB = new DB_Context();
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

        //Choose Supplier to Update its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                try
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من اختيار كود المورد الصحيح", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        HttpResponseMessage message = client.GetAsync("api/suppliers").Result;

                        if (message.IsSuccessStatusCode)
                        {
                            List<Supplier> suppliers = message.Content.ReadAsAsync<List<Supplier>>().Result;
                            Supplier supplier = suppliers.Where(n => n.Supp_ID == index).FirstOrDefault();

                            name.Text = supplier.Supp_Name;
                            phone.Text = supplier.Supp_Phone;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("برجاء اختيار كود المورد", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود المورد", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update Supplier Button , Check for Supplier Phone before Update
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sname = name.Text;
                string sphone = phone.Text;

                if (sname.Equals("") || sphone.Equals("") || sphone.Length != 11)
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    HttpResponseMessage message = client.GetAsync("api/suppliers").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        List<Supplier> suppliers = message.Content.ReadAsAsync<List<Supplier>>().Result;
                        Supplier supplier1 = suppliers.Where(n => n.Supp_Phone == sphone && n.Supp_Name != sname).FirstOrDefault();

                        if (supplier1 != null)
                        {
                            MessageBox.Show("رقم الهاتف الذى ادخلته مسجل لدى مورد من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult result;
                            result = MessageBox.Show("هل متأكد من تعديل بيانات المورد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {
                                Supplier supplier2 = suppliers.Where(n => n.Supp_ID == index).SingleOrDefault();

                                supplier2.Supp_Name = sname;
                                supplier2.Supp_Phone = sphone;

                                HttpResponseMessage message1 = client.PutAsJsonAsync($"api/suppliers/{index}", supplier2).Result;

                                if (message1.IsSuccessStatusCode)
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

        //Preview Supplier Information
        private void UpdateSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Suppliers.Select(n => new { Supplier_ID = n.Supp_ID, Supplier_Name = n.Supp_Name, Supplier_Phone = n.Supp_Phone }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}