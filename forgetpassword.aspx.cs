using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace unit3
{
    public partial class forgetpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Shriyasem5\\unit3\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataReader red;
            try
            {
               // string password1;
                cmd.CommandText = ("select* from registration where username='" + TextBox1.Text + "' and email = '" + TextBox2.Text + "'");
                red = cmd.ExecuteReader();
                if (red.Read() == true)
                {
                    Label1.Text = "Your password is :" + red["password1"].ToString();

                }
                else
                {
                    Label1.Text = "UserName or Password Incorrect";
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}