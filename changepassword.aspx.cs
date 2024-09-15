using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace unit3
{
    public partial class changepassword : System.Web.UI.Page
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
                cmd.CommandText = ("select* from registration where password1='" + TextBox1.Text + "'");
                red = cmd.ExecuteReader();
                if (red.Read() == true)
                {
                    red.Close();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("update registration set password1='" + TextBox2.Text + "' where username='" + TextBox1.Text + "'");
                    cmd.ExecuteNonQuery();
                    Label4.Text = "Your Password is Change";
                }
                else
                {
                    Label4.Text = "Password Incorrect";
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Label4.Text = ex.Message;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginform.aspx");
        }
    }
}