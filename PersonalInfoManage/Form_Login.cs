using PersonalInfoManage.SqlLiteClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalInfoManage
{
    public partial class Form_Login : Form
    {
        DataClass dataClass = new DataClass();

        public Form_Login()
        {
            InitializeComponent();
            dataClass.createNewDatabase();
            txt_Pass.PasswordChar = '*';
            Random random = new Random();       
            int fourDigitNumber = random.Next(1000, 10000);
            lbl_PassTwice.Text = fourDigitNumber.ToString();
            uiWaitingBar1.Visible = false;
        }

        private  void btn_Login_Click(object sender, EventArgs e)
        {
            uiWaitingBar1.Visible = true;
            string PassTwice = lbl_PassTwice.Text.ToString();
            try
            {
                if (txt_Name.Text != "" && txt_Pass.Text != "")
                {
                    SQLiteDataReader login_test = dataClass.selectData("Select * from tb_Login where Account='" + txt_Name.Text.Trim() + "'and PassWord='" + txt_Pass.Text.Trim() + "'");
                    bool sda_login_read = login_test.Read();
                    if (sda_login_read)
                    {
                        if (txt_PassTwice.Text == PassTwice)
                        {
                            MessageBox.Show("登录成功！", "提示！");
                            txt_Name.Text = "";
                            txt_Pass.Text = "";
                            txt_PassTwice.Text = "";
                            Random random = new Random();
                            int fourDigitNumber = random.Next(1000, 10000);
                            lbl_PassTwice.Text = fourDigitNumber.ToString();

                            uiWaitingBar1.Visible = false;
                            Form_Main form_Main = new Form_Main();
                            this.Hide();
                            form_Main.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("登录失败！请检查验证码是否正确！", "提示！");
                            uiWaitingBar1.Visible = false;
                            txt_Name.Text = "";
                            txt_Pass.Text = "";
                            txt_PassTwice.Text = "";
                            Random random = new Random();
                            int fourDigitNumber = random.Next(1000, 10000);
                            lbl_PassTwice.Text = fourDigitNumber.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("登录失败！请检查账户密码！", "提示！");
                        uiWaitingBar1.Visible = false;
                        txt_Name.Text = "";
                        txt_Pass.Text = "";
                        txt_PassTwice.Text = "";
                        Random random = new Random();
                        int fourDigitNumber = random.Next(1000, 10000);
                        lbl_PassTwice.Text = fourDigitNumber.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！请检查账户密码！" + ex, "提示！");
                uiWaitingBar1.Visible = false;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.ToString() != null || txt_Name.Text.ToString() != "" ||
                txt_Pass.Text.ToString() != null || txt_Pass.Text.ToString() != "" ||
                 txt_PassTwice.Text.ToString() != null || txt_PassTwice.Text.ToString() != "")
            {
                txt_Name.Text = "";
                txt_Pass.Text = "";
                txt_PassTwice.Text = "";
            }
        }
    }
}
