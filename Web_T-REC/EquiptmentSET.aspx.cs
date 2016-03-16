using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_T_REC.DataModel;
using Web_T_REC.Classes;

namespace Web_T_REC
{
    public partial class EquiptmentSET : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadConfig()
        {
            Equipment_Type[] Equipment_Types = null;
            ClassSet.LoadType(out Equipment_Types,1);
            if (Equipment_Types != null && Equipment_Types.Any())
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnCencel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}