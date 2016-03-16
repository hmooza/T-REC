using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated == false)
        {
             Response.Redirect("Login.aspx");


            ////TEST
            //if (Session["test"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

           
        }
    }
}