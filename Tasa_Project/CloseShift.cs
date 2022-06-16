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
    public partial class CloseShift : DevExpress.XtraEditors.XtraForm
    {
        public CloseShift()
        {
            InitializeComponent();
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

        //Settings Page 
        private void button1_Click(object sender, EventArgs e)
        {
            SettingPage settingPage = new SettingPage();

            if (settingPage == null)
            {
                this.Hide();
                settingPage.Show();
            }
            else
            {
                this.Hide();
                settingPage.Show();
                settingPage.Focus();
            }
        }

        //Preview System Date, Total Day Sales , Total Day Sales Information 
        private void CloseShift_Load(object sender, EventArgs e)
        {
            try
            {
                List<String> Dates = new List<string>();

                DataTable table = new DataTable();

                SqlConnection CONN = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                SqlCommand command = new SqlCommand();

                command.Connection = CONN;
                command.CommandText = "select [Date] from System_Date";

                CONN.Open();

                table.Load(command.ExecuteReader());

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Dates.Add(table.Rows[i][0].ToString());
                    date.Text = Dates.Last().ToString();
                }

                CONN.Close();

                //________________________________________________________________

                float Total = 0;

                List<String> totalsales = new List<string>();

                DataTable table1 = new DataTable();

                SqlConnection CONN1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                SqlCommand command1 = new SqlCommand();

                command1.Connection = CONN1;
                command1.CommandText = "select [Price] from Sales where Date = '"+ date.Text +"'";

                CONN1.Open();

                table1.Load(command1.ExecuteReader());

                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    totalsales.Add(table1.Rows[i][0].ToString());
                    Total += float.Parse(totalsales[i]);
                }

                total.Text = Total.ToString();

                //________________________________________________________________

                DataTable table2 = new DataTable();

                SqlConnection CONN2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                SqlCommand command2 = new SqlCommand();

                command2.Connection = CONN2;
                command2.CommandText = "select [Invo_Num] as 'Invoice_Number', [Cus_Name] as 'Customer_Name' , [Prod_Code] as 'Product_Code' , [Prod_Name] as 'Product_Name' , [Quantity] as 'Quantity' , [Price] as 'Product_Price' , [Date] as 'Date' , [Time] as 'Time' from Sales where Date = '" + date.Text + "' ";

                dataGridView1.DataSource = table2;

                CONN2.Open();
                table2.Load(command2.ExecuteReader());

                CONN2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Close Shift Button , Check for Date , Add Sales Day Information to DB , Change Date to Next Day
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string systemdate = date.Text;
                string totalsales = total.Text;
                string datenow = DateTime.Today.ToString("dd/MM/yyyy");

                int res = DateTime.Compare(DateTime.Parse(systemdate), DateTime.Parse(datenow));

                if (res == 1)
                {
                    MessageBox.Show("لا يمكن غلق اليوم حاليا يجب ان يكون مطابق لتاريخ اليوم", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection CONN3 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                    SqlCommand command3 = new SqlCommand();

                    command3.Connection = CONN3;
                    command3.CommandText = "insert into System_Date values ('" + systemdate + "','" + totalsales + "')";

                    CONN3.Open();

                    command3.ExecuteNonQuery();

                    CONN3.Close();

                    MessageBox.Show("تم غلق اليوم بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //________________________________________________________________

                    DateTime date = DateTime.Parse( systemdate);
                    DateTime date1 = date.AddDays(1);

                    string nextday= date1.ToString("dd/MM/yyyy");
                    string TotalSales = "0";

                    SqlConnection CONN4 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                    SqlCommand command4 = new SqlCommand();

                    command4.Connection = CONN4;
                    command4.CommandText = "insert into System_Date values ('" + nextday + "','" + TotalSales + "')";

                    CONN4.Open();

                    command4.ExecuteNonQuery(); ;

                    CONN4.Close();

                    button1_Click(sender, e);


                }

            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}