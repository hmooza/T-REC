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
using Web_T_REC.Classes;

namespace Web_T_REC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblResult.Visible = false;
                Session.Clear();
            }
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            // EnCryptPassword
            string salt = System.Configuration.ConfigurationManager.AppSettings["salt"];
            string strEnCrypt =  SHA256.EcryptPassword(inputPassword.Text, salt);


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




                        bool isAuthenticated = true;
                        if (isAuthenticated == true)
                        {
                            // generate authentication ticket
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,   // version
                                                    inputUsername.Text,           // username
                                                    DateTime.Now,               // creation
                                                    DateTime.Now.AddMinutes(60),// Expiration
                                                    false,   // Persistent
                                                    ""   //No additional data supplied
                                                );
                            // Encrypt the ticket.
                            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                            // Create a cookie and add the encrypted ticket to the cookie
                            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                        encryptedTicket);
                            Response.Cookies.Add(authCookie);
                            // Redirect the user to the originally requested page
                            Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsername.Text,false));

                            
                        }
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }


            //// TEST
            //Session["test"] = "1";
            //Response.Redirect("~/Default.aspx");
        }
    }
}