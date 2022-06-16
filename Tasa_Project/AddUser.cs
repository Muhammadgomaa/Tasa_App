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
    public partial class AddUser : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        public AddUser()
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

        //Add User Button , Check for Username before Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = username.Text;
                string upass = confirm.Text;
                string upassconfirm = pass.Text;

                if (uname.Equals("") || upass.Equals("") || upassconfirm.Equals(""))
                {
                    MessageBox.Show("برجاء استكمال البيانات المطلوبه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!upass.Equals(upassconfirm))
                {
                    MessageBox.Show("كلمه المرور الذى ادخلتها غير متطابقه", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (upass.Length < 6)
                {
                    MessageBox.Show("يجب ادخال كلمه مرور لا تقل عن 6 حروف او ارقام", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<String> usernames = new List<string>();

                    DataTable table = new DataTable();

                    SqlConnection CONN = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString);

                    SqlCommand command = new SqlCommand();

                    command.Connection = CONN;
                    command.CommandText = "select [User_Name] from Users";

                    CONN.Open();

                    table.Load(command.ExecuteReader());

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        usernames.Add(table.Rows[i][0].ToString());
                    }

                    if (usernames.Contains(uname))
                    {
                        MessageBox.Show("هذا المستخدم تم اضافته من قبل يرجى التأكد", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show("هل متأكد من اضافه مستخدم جديد", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            User user = new User();

                            user.User_Name = uname;
                            user.User_Password = upass;

                            dB.Users.Add(user);
                            dB.SaveChanges();

                            MessageBox.Show("تم اضافه البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CONN.Close();

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