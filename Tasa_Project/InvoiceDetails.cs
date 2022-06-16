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
    public partial class InvoiceDetails : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        public InvoiceDetails()
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

        //Preview All Invoices Numbers
        private void InvoiceDetails_Load(object sender, EventArgs e)
        {
            try
            {
                invonum.DisplayMember = "Invo_Num";
                invonum.DataSource = dB.Invoices.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Display Invoice Details
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string invo_Num = invonum.Text;

                if (invo_Num.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataTable table1 = new DataTable();

                    SqlConnection CONN1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                    SqlCommand command1 = new SqlCommand();

                    command1.Connection = CONN1;
                    command1.CommandText = "select [Cus_Name] as 'Customer_Name',[Prod_Code] as 'Product_Code',[Prod_Name] as 'Product_Name ',[Quantity] as 'Quantity',[Price] as 'Price' , [Date] as 'Date' , [Time] as 'Time' from Sales where Invo_Num = '" + invo_Num + "' ";

                    dataGridView1.DataSource = table1;

                    CONN1.Open();
                    table1.Load(command1.ExecuteReader());

                    CONN1.Close();

                    //____________________________________________________________________

                    float t = 0;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        t += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    }

                    total.Text = t.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}