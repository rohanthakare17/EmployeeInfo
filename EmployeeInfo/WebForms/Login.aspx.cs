using System;
using System.Web.UI;

namespace EmployeeInfo.WebForms
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "password";

            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                Response.Redirect("~/WebForms/Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials!";
                lblMessage.Visible = true;
            }
        }
    }
}
