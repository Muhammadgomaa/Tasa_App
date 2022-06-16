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
    public partial class DeleteUser : DevExpress.XtraEditors.XtraForm
    {
        DB_Context dB;
        int index;

        public DeleteUser()
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
        private void DeleteUser_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dB.Users.Select(n => new { User_ID = n.User_ID, User_Name = n.User_Name}).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("برجاء استكمال البيانات المطلوبه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Choose User to Delete its Information
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = int.Parse(dataGridView1.CurrentCell.Value.ToString());

                DialogResult result;
                result = MessageBox.Show("هل متأكد من مسح بيانات المستخدم", "Tasa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        User user = dB.Users.Where(n => n.User_ID == index).SingleOrDefault();

                        dB.Users.Remove(user);
                        dB.SaveChanges();

                        MessageBox.Show("تم مسح البيانات بنجاح", "Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        button1_Click(sender, e);

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
    }
}