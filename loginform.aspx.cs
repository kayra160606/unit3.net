using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace unit3
{
    public partial class loginform : System.Web.UI.Page
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
             //   cmd.CommandText = "select from registration where username='" + TextBox1.Text + "'and password1='" + TextBox2.Text + "'";
            try
            {
                SqlDataReader red;
                cmd.CommandText = "select* from registration where username='" + TextBox1.Text + "' and password1 = '" + TextBox2.Text + "'"; 
                red = cmd.ExecuteReader();
                if (red.Read() == true)
                {
                    Label1.Text = "Successfully Login";
                    
                }
                else
                {
                    Label1.Text = "UserName or Password Incorrect";
                }
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit3_p2.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("forgetPassword.aspx");
        }
    }
}