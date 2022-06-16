using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;

namespace Tasa_Project
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        HttpClient client = new HttpClient();

        public Login()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:2711/");
        }

        //Close Program
        private void logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("شكرا لاستخدامكم البرنامج", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.None);
            Environment.Exit(0);
        }

        //Login Button
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string username = name.Text;
                string userpass = pass.Text;

                if (username.Equals("") || userpass.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    HttpResponseMessage message = client.GetAsync("api/users").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        List<User> users = message.Content.ReadAsAsync<List<User>>().Result;

                        User user = users.Where(n => n.User_Name == username && n.User_Password == userpass).FirstOrDefault();

                        if(user != null)
                        {
                            MessageBox.Show("مرحبا بك", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        else
                        {
                            MessageBox.Show("خطأ فى اسم المستخدم او كلمه المرور", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ فى اسم المستخدم او كلمه المرور", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
