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
    public partial class ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        int index;

        public ChangePassword()
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

        //Preview User Informations
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Users.Select(n => new { User_ID = n.User_ID, User_Name = n.User_Name }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose User to Update its Password
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من تعديل كلمه المرور للمستخدم", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        User user = dB.Users.Where(n => n.User_ID == index).SingleOrDefault();

                        username.Text = user.User_Name;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("برجاء اختيار كود المستخدم", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء اختيار كود المستخدم", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Change Password Button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = username.Text;
                string upass = pass.Text;

                if (uname.Equals("") || upass.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (upass.Length < 6)
                {
                    MessageBox.Show("يجب ادخال كلمه مرور لا تقل عن 6 حروف او ارقام", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("هل متأكد من تعديل كلمه المرور للمستخدم", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        User user = dB.Users.Where(n => n.User_ID == index).SingleOrDefault();

                        user.User_Name = uname;
                        user.User_Password = upass;

                        dB.SaveChanges();

                        MessageBox.Show("تم تعديل البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        button1_Click(sender, e);
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