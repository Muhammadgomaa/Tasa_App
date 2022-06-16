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
    public partial class AllSales : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        public AllSales()
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

        //Preview Sales Transactions Information , Calculate Total Sales Price
        private void AllSales_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Sales.Select(n => new { Invoice_Number = n.Invo_Num , Customer_Name=n.Cus_Name , Product_Code = n.Prod_Code, Product_Name = n.Prod_Name , Quantity = n.Quantity ,  Product_Price = n.Price , Date = n.Date , Time = n.Time }).ToList();

                float Total = 0;

                List<String> totalsales = new List<string>();

                DataTable table = new DataTable();

                SqlConnection CONN = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                SqlCommand command = new SqlCommand();

                command.Connection = CONN;
                command.CommandText = "select [Invo_TotalPrice] from Invoices";

                CONN.Open();

                table.Load(command.ExecuteReader());

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    totalsales.Add(table.Rows[i][0].ToString());
                    Total += float.Parse(totalsales[i]);
                }

                total.Text = Total.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}