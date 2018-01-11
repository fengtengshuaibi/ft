using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Notepad
{
    public partial class Register : Form
    {
        public Register()
        {
         
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mysq1 = "Data Source=小腾7plus\\test;Initial Catalog=NoteBook;Persist Security Info=True;User ID=sa;password=521314";
            SqlConnection con = new SqlConnection();
            SqlCommand sqlcommand = new SqlCommand();
            string sqladd = "insert into Users values(";
            sqladd += "'" + textBox1.Text;
            sqladd += "','" + textBox2.Text+"')";
            try
            {
                con.ConnectionString = mysq1;
                con.Open();
                sqlcommand.CommandText = sqladd;
                sqlcommand.Connection = con;
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.CommandTimeout = 30;
                //执行insert语句
                int n = sqlcommand.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("成功注册了用户！");
                    Program.user.Username = textBox1.Text;
                    Program.user.Password = textBox2.Text;

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { if (con != null) con.Close(); sqlcommand.Dispose(); }
            this.Hide();
            login l1 = new login();
            l1.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
