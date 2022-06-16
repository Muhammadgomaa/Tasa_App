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

namespace Tasa_Project
{
    public partial class DeleteSales : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        int index;

        public DeleteSales()
        {
            InitializeComponent();
            dB = new DB_Context();
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

        //Sales Page
        private void button1_Click(object sender, EventArgs e)
        {
            SalesPage salesPage = new SalesPage();

            if (salesPage == null)
            {
                this.Hide();
                salesPage.Show();
            }
            else
            {
                this.Hide();
                salesPage.Show();
                salesPage.Focus();
            }
        }

        //Preview Invoices Information
        private void DeleteSales_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Invoices.Select(n => new { Invoice_Number = n.Invo_Num, Invoice_Total_Price = n.Invo_TotalPrice}).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose Invoice to Delete its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من مسح بيانات الفاتوره", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection CONN1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                        SqlCommand command1 = new SqlCommand();

                        command1.Connection = CONN1;

                        command1.CommandText = "delete from Sales where Invo_Num = '" + index + "' ";

                        CONN1.Open();

                        command1.ExecuteNonQuery();

                        CONN1.Close();

                        Invoice invoice = dB.Invoices.Where(n => n.Invo_Num == index).SingleOrDefault();

                        dB.Invoices.Remove(invoice);
                        dB.SaveChanges();

                        MessageBox.Show("تم مسح البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        button1_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("برجاء اختيار رقم الفاتوره", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار رقم الفاتوره", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}