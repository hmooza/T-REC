using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_T_REC
{
    public partial class QuotationDetail : System.Web.UI.Page
    {
        private Enumeration.ObjectStutus vsMode
        {
            get
            {
                if (ViewState["vsFormMode"] == null) ViewState["vsFormMode"] = Enumeration.ObjectStutus.NoEvent;
                return (Enumeration.ObjectStutus)ViewState["vsFormMode"];
            }
            set { ViewState["vsFormMode"] = value; }
        }
        private int vsQuotationID
        {
            get
            {
                if (string.IsNullOrEmpty(hdnQuotationID.Value)) hdnQuotationID.Value = "0";
                return Convert.ToInt32(hdnQuotationID.Value);
            }
            set { hdnQuotationID.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitQueryString();

                if (vsMode == Enumeration.ObjectStutus.Update && vsQuotationID > 0)
                {
                    // Load Data

                }
            }
        }

        private void InitQueryString()
        {
            if (Request.QueryString["mode"] != null && !string.IsNullOrEmpty(Request.QueryString["mode"].ToString()))
            {
                vsMode = (Enumeration.ObjectStutus)Enum.Parse(typeof(Enumeration.ObjectStutus), Request.QueryString["mode"].ToString());
            }
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                vsQuotationID = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
        }

        private void SetDetail()
        {
        }

        
    }
}