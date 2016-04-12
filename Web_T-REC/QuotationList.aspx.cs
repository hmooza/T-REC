using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_T_REC
{
    public partial class QuotationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuotationDetail.aspx?mode=" + Enumeration.ObjectStutus.Insert.GetHashCode().ToString());
        }
    }
}