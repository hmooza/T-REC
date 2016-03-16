using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_T_REC
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated == false)
                {
                    //menu.Style["display"] = "none";
                    menu.Visible = false;
                }
                else
                {
                    if (Context.User.Identity.Name != null)
                    {
                        //menu.Style["display"] = "";
                        menu.Visible = true;
                    }
                    else
                    {
                        //menu.Style["display"] = "none";
                        menu.Visible = false;
                    }
                }


             
            }
        }
    }
}