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
    public partial class AddSales : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;

        long Customer_ID;
        long Invo_Num;

        public AddSales()
        {
            InitializeComponent();
            dB = new DB_Context();
        }


        //Hide Items
        private void AddSales_Load(object sender, EventArgs e)
        {
            label3.Show();
            //____________
            label1.Hide();
            label2.Hide();
            label5.Hide();
            label12.Hide();
            label8.Hide();
            label10.Hide();
            label11.Hide();
            label9.Hide();
            label13.Hide();
            //______________
            dataGridView1.Hide();
            //______________
            button1.Hide();
            button3.Hide();
            //______________
            cusname.Hide();
            address.Hide();
            prodname.Hide();
            size.Hide();
            price.Hide();
            date.Hide();
            time.Hide();
            quantity.Hide();
            totalinvo.Hide();
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

        //Check Customer Phone Number , Get Current Date and Time , Get Customer Name and Address , Get All Products Name
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cphone = phone.Text;

                if (cphone.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<String> customersphone = new List<string>();

                    DataTable table = new DataTable();

                    SqlConnection CONN = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                    SqlCommand command = new SqlCommand();

                    command.Connection = CONN;
                    command.CommandText = "select [Cus_Phone] from Customers";

                    CONN.Open();

                    table.Load(command.ExecuteReader());

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        customersphone.Add(table.Rows[i][0].ToString());
                    }

                    if (!customersphone.Contains(cphone))
                    {
                        MessageBox.Show("هذا العميل غير متواجد من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        label3.Hide();
                        phone.Hide();
                        button2.Hide();

                        //_________________________________________________________

                        label1.Show();
                        label2.Show();
                        label5.Show();
                        label12.Show();
                        label8.Show();
                        label10.Show();
                        label11.Show();
                        label9.Show();
                        label13.Show();
                        //______________
                        dataGridView1.Show();
                        //______________
                        button1.Show();
                        button3.Show();
                        //______________
                        cusname.Show();
                        address.Show();
                        prodname.Show();
                        size.Show();
                        price.Show();
                        date.Show();
                        time.Show();
                        quantity.Show();
                        totalinvo.Show();
                        //_________________________________________________________

                        string datenow = DateTime.Today.ToString("dd/MM/yyyy");
                        date.Text = datenow;
                        string timenow = DateTime.Now.ToString("HH:mm:ss");
                        time.Text = timenow;

                        //_________________________________________________________


                        Customer customer = dB.Customers.Where(n => n.Cus_Phone == cphone).SingleOrDefault();

                        cusname.Text = customer.Cus_Name;
                        address.Text = customer.Cus_Address;
                        Customer_ID = customer.Cus_ID;

                        //_________________________________________________________

                        List<String> Products_Name = new List<string>();

                        DataTable table1 = new DataTable();

                        SqlConnection CONN1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                        SqlCommand command1 = new SqlCommand();

                        command1.Connection = CONN1;
                        command1.CommandText = "select [Prod_Name] from Products";

                        CONN1.Open();

                        table1.Load(command1.ExecuteReader());

                        for (int i = 0; i < table1.Rows.Count; i++)
                        {
                            Products_Name.Add(table1.Rows[i][0].ToString());
                            prodname.Items.Add(Products_Name[i]);
                        }

                        CONN1.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Get The Product Price Depends of The Product Name and Size
        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string proname = prodname.Text;
                string prosize = size.Text;
                string proquan= quantity.Value.ToString();

                DataTable table2 = new DataTable();

                SqlConnection CONN2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                SqlCommand command2 = new SqlCommand();

                command2.Connection = CONN2;
                command2.CommandText = "select [Prod_Price] from Products where Prod_Name = '" + proname + "' AND Prod_Size = '" + prosize + "' ";

                CONN2.Open();
                table2.Load(command2.ExecuteReader());

                string proprice = table2.Rows[0][0].ToString();
                float totalprice = float.Parse(proquan) * float.Parse(proprice);

                price.Text = totalprice.ToString();
                CONN2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار اسم الصنف و الحجم المطلوب", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Add Item to Invoice , Calculate Total Invo Price , Hide Customer Name and Address to Avoid Conflict
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cusname.Hide();
                address.Hide();
                label1.Hide();
                label2.Hide();

                string proname = prodname.Text;
                string prosize = size.Text;
                string proquan = quantity.Value.ToString();
                float totalprice = float.Parse(price.Text);

                if (proname.Equals("") || proquan.Equals("0"))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من اضافه الصنف للفاتوره", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        object[] row = { proname , prosize, proquan, totalprice };

                        dataGridView1.Rows.Add(row);

                        totalinvo.Text = "";

                        float t = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            t += float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        }

                        totalinvo.Text = t.ToString();

                        price.Text = "0";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete Items from Invoice , Calculate Total Invo Price
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("هل متأكد من حذف الصنف من الفاتوره", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                int ind = int.Parse(dataGridView1.CurrentCell.RowIndex.ToString());

                dataGridView1.Rows.RemoveAt(ind);

                MessageBox.Show("تم حذف الصنف", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                totalinvo.Text = "";

                float t = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    t += float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                totalinvo.Text = t.ToString();
            }
        }

        //Add Sales Button , Add Invoice Total Price ,  
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;

                string cname = cusname.Text;
                string orddate = date.Text;
                string ordtime = time.Text;

                List<String> ProductsCode = new List<string>();
                List<String> ProductsName = new List<string>();
                List<String> ProductsSize = new List<string>();
                List<String> ProductsQuantity = new List<string>();
                List<String> ProductsPrice = new List<string>();

                if (dataGridView1.Rows.Count == 0 || cname.Equals("") || orddate.Equals("") || ordtime.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من اضافه عمليه بيع جديده", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        Invoice invoice = new Invoice();

                        invoice.Invo_TotalPrice = double.Parse(totalinvo.Text);

                        dB.Invoices.Add(invoice);
                        dB.SaveChanges();

                        //_________________________________________________________________


                        List<String> Invo_Nums = new List<string>();

                        DataTable table3 = new DataTable();

                        SqlConnection CONN3 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                        SqlCommand command3 = new SqlCommand();

                        command3.Connection = CONN3;
                        command3.CommandText = "select [Invo_Num] from Invoices";

                        CONN3.Open();

                        table3.Load(command3.ExecuteReader());

                        for (int j = 0; j < table3.Rows.Count; j++)
                        {
                            Invo_Nums.Add(table3.Rows[j][0].ToString());
                        }

                        Invo_Num = int.Parse(Invo_Nums.Last().ToString());


                        if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                        {
                            printDocument1.Print();
                        }

                        //_________________________________________________________________
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            ProductsName.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            ProductsSize.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                            ProductsQuantity.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            ProductsPrice.Add(dataGridView1.Rows[i].Cells[3].Value.ToString());

                            //________________________________________________________________

                            DataTable table4 = new DataTable();

                            SqlConnection CONN4 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);
                            SqlCommand command4 = new SqlCommand();

                            command4.Connection = CONN4;
                            command4.CommandText = "select [Prod_Code] from Products where Prod_Name = '" + ProductsName[i] + "' AND Prod_Size = '" + ProductsSize[i] + "' ";

                            CONN4.Open();
                            table4.Load(command4.ExecuteReader());

                            for (int j = 0; j < table4.Rows.Count; j++)
                            {
                                ProductsCode.Add(table4.Rows[j][0].ToString());
                            }

                            CONN4.Close();

                            //________________________________________________________________

                            Sale sale = new Sale();

                            sale.Invo_Num = Invo_Num;
                            sale.Cus_ID = Customer_ID;
                            sale.Cus_Name = cname;
                            sale.Prod_Code = long.Parse(ProductsCode[i]);
                            sale.Prod_Name = ProductsName[i];
                            sale.Quantity = long.Parse(ProductsQuantity[i]);
                            sale.Price = double.Parse(ProductsPrice[i]);
                            sale.Date = orddate;
                            sale.Time = ordtime;

                            dB.Sales.Add(sale);
                            dB.SaveChanges();

                            //_________________________________________________________________
                        }

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

                        MessageBox.Show("شكرا لتعاملكم معنا", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Print Document Details
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float mar = 50;

            Font font1 = new Font("Kristen ITC", 24, FontStyle.Bold);
            Font font2 = new Font("Kristen ITC", 18, FontStyle.Regular);
            Font font3 = new Font("Kristen ITC", 18, FontStyle.Bold);
            Font font4 = new Font("Kristen ITC", 12, FontStyle.Underline);

            SizeF size1 = e.Graphics.MeasureString("رقم الفاتوره :" + Invo_Num.ToString(), font1);
            SizeF size2 = e.Graphics.MeasureString("التاريخ : " + date.Text, font2);
            SizeF size3 = e.Graphics.MeasureString("الوقت : " + time.Text, font2);
            SizeF size4 = e.Graphics.MeasureString("اسم العميل : " + cusname.Text, font2);
            SizeF size5 = e.Graphics.MeasureString("Copyrights : Muhammad Gomaa ©", font4);

            e.Graphics.DrawImage(Properties.Resources.logo22, mar - 45, mar - 45, 200, 200);

            e.Graphics.DrawString("رقم الفاتوره :" + Invo_Num.ToString(), font1, Brushes.Black, (e.PageBounds.Width - size1.Width) / 2, mar);
            e.Graphics.DrawString("التاريخ : " + date.Text, font2, Brushes.Black, (e.PageBounds.Width - size2.Width - mar), mar + size1.Height);
            e.Graphics.DrawString("الوقت : " + time.Text, font2, Brushes.Black, (e.PageBounds.Width - size3.Width - mar), mar + size1.Height + size2.Height);
            e.Graphics.DrawString("اسم العميل : " + cusname.Text, font2, Brushes.Black, (e.PageBounds.Width - size4.Width - mar), mar + size1.Height + size2.Height + size3.Height);
            e.Graphics.DrawString("Copyrights : Muhammad Gomaa ©", font4, Brushes.Black, (e.PageBounds.Width - size5.Width) / 2, mar + size1.Height + size2.Height + size3.Height + size4.Height);


            float PreHeights = mar + size1.Height + size2.Height + size3.Height + size4.Height + 70;

            e.Graphics.DrawRectangle(Pens.Black, mar, PreHeights, e.PageBounds.Width - mar * 2, e.PageBounds.Height - mar - PreHeights);

            float ColHeight = 60;

            float Col1Width = 100;
            float Col2Width = 300 + Col1Width;
            float Col3Width = 125 + Col2Width;
            float Col4Width = 150 + Col3Width;

            e.Graphics.DrawLine(Pens.Black, mar, PreHeights + ColHeight, e.PageBounds.Width - mar, PreHeights + ColHeight);

            e.Graphics.DrawString("اسم المنتج", font3, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col1Width, PreHeights);
            e.Graphics.DrawLine(Pens.Black, (e.PageBounds.Width - mar * 2) - Col1Width, PreHeights, (e.PageBounds.Width - mar * 2) - Col1Width, e.PageBounds.Height - mar);

            e.Graphics.DrawString("حجم المنتج", font3, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col2Width, PreHeights);
            e.Graphics.DrawLine(Pens.Black, (e.PageBounds.Width - mar * 2) - Col2Width, PreHeights, (e.PageBounds.Width - mar * 2) - Col2Width, e.PageBounds.Height - mar);

            e.Graphics.DrawString("الكميه", font3, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col3Width, PreHeights);
            e.Graphics.DrawLine(Pens.Black, (e.PageBounds.Width - mar * 2) - Col3Width, PreHeights, (e.PageBounds.Width - mar * 2) - Col3Width, e.PageBounds.Height - mar);

            e.Graphics.DrawString("اجمالى السعر", font3, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col4Width, PreHeights);

            float RowsHeight = 60;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), font2, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col1Width, PreHeights + RowsHeight);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), font2, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col2Width, PreHeights + RowsHeight);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), font2, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col3Width, PreHeights + RowsHeight);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), font2, Brushes.Black, (e.PageBounds.Width - mar * 2) - Col4Width, PreHeights + RowsHeight);
                e.Graphics.DrawLine(Pens.Black, mar, PreHeights + RowsHeight + ColHeight, e.PageBounds.Width - mar, PreHeights + RowsHeight + ColHeight);


                RowsHeight += 60;
            }

            e.Graphics.DrawString("اجمالى سعر الفاتوره", font3, Brushes.Blue, (e.PageBounds.Width - mar * 2) - Col3Width, PreHeights + RowsHeight);
            e.Graphics.DrawString(totalinvo.Text, font3, Brushes.Blue, (e.PageBounds.Width - mar * 2) - Col4Width, PreHeights + RowsHeight);
            e.Graphics.DrawLine(Pens.Black, mar, PreHeights + RowsHeight + ColHeight, e.PageBounds.Width - mar, PreHeights + RowsHeight + ColHeight);

        }
    }
}