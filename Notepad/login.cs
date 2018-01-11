using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Notepad
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private const int MAX_LOGIN_COUNT = 3;
        private int userLoginCount = 0;
        //引用配置文件定义连接数据库字符串
        string mysq1 = "Data Source=小腾7plus\\test;Initial Catalog=NoteBook;Persist Security Info=True;User ID=sa;Password=521314";
        //string strConnection="user id=sa;password=521314;";
        //strConnection ="initial catalog=Student_Dorm;Server=小腾7plus\test;";
        //strConnection ="Connect Timeout=30";
        SqlCommand sqlcommand = new SqlCommand();
        SqlConnection con = new SqlConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            //Note note = new Note();
            //note.Show();
            //Hide();
            con.ConnectionString = mysq1;
            con.Open();
            sqlcommand.Connection = con;
            //提取User表用户名列的项s
            String sqluserpword = "select password FROM Users";
            SqlDataAdapter sqladapter = new SqlDataAdapter(sqluserpword, con);
            sqlcommand.CommandText = sqluserpword;
            DataSet dt = new DataSet();
            sqladapter.Fill(dt, "users");
            con.Close();
            if ((dt.Tables[0].Rows[0])["password"].ToString() == textBox2.Text.Trim())
            {
                MessageBox.Show("密码正确!欢迎使用小腾笔记本！" + textBox1.Text);
                //更新用户数据类
                Program.user.Username = textBox1.Text;
                Program.user.Password = textBox2.Text;
               
                this.Hide();
                Note f1 = new Note();
                f1.Show();
            }
            else
            {
                userLoginCount++;
                if (userLoginCount == MAX_LOGIN_COUNT)
                {
                    //验证失败且达到最大验证次数，返回DialogResult.Cancle
                    MessageBox.Show("登录失败，退出登录!");
                    this.Close();
                }
                else
                {
                    //验证失败但未达到最大验证次数，重新验证
                    MessageBox.Show("错误密码，请重新输入！");
                    textBox2.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            Hide();
        }
    }
}
