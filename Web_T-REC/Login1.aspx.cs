using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Security;

public partial class Login1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblResult.Visible = false;
            //Session["loginuser"] = null;
            Session.Clear();
        }
    }
    protected void btnSignin_Click(object sender, EventArgs e)
    {
        // EnCryptPassword
        string salt = System.Configuration.ConfigurationManager.AppSettings["salt"];
        string strEnCrypt = SHA256.EcryptPassword(inputPassword.Text, salt);

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select ID from dbo.Users where Username =LOWER('" + inputUsername.Text + "') and Password = '" + strEnCrypt + "'";

        DataTable dt = new DataTable();
        int userId = 0;
        try
        {
            userId = ClassMain.intExecuteComand(sql);
            dt = ClassMain.ExecuteComandTable(sql);
            switch (userId)
            {
                case 0:
                    //Login1.FailureText = "Username and/or password is incorrect.";
                    lblResult.Visible = true;
                    lblResult.Text = "Username and/or password is incorrect.";
                    break;
                case -1:
                    //Login1.FailureText = "Username and/or password is incorrect.";
                    lblResult.Visible = true;
                    lblResult.Text = "Username and/or password is incorrect.";
                    break;
                case -2:
                    //Login1.FailureText = "Account has not been activated.";
                    lblResult.Visible = true;
                    lblResult.Text = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.RedirectFromLoginPage(inputUsername.Text, true);
                    Session["userlogin"] = inputUsername.Text;
                    Response.Redirect("~/Default.aspx");
                    break;
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
}