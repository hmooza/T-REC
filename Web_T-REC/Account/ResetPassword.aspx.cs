using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_T_REC.Account
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            // EnCryptPassword
            string salt = System.Configuration.ConfigurationManager.AppSettings["salt"];
            string strEnCrypt = SHA256.EcryptPassword(inputPassword.Text, salt);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "update  dbo.Users set Password = '" + strEnCrypt + "' where Username ='" + inputUsername.Text + "'";

            string res = ClassMain.strExecuteComand(sqlCmd);

            if (res != "")
            { lblResult.Text = res; }
            else
            {
                lblResult.Text = "Update success.";
                lblResult.Visible = true;
            }
        }
    }
}