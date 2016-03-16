using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web_T_REC.Classes;

namespace Web_T_REC
{
    public partial class JobPosition : System.Web.UI.Page
    {
        #region Properties
        public DataTable ss_dt
        {
            get { return (DataTable)Session["ss_dt"]; }
            set { Session["ss_dt"] = value; }
        }

        public string mode
        {
            get { return (string)Session["mode"]; }
            set { Session["mode"] = value; }
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                divwarning.Visible = false;
                BindGrid();
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

        protected void BindGrid()
        {
            DataTable dt = ClassJopPosition.LoadData();
            this.ss_dt = dt;
            datagrid.DataSource = dt;
            datagrid.DataBind();
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagrid.PageIndex = e.NewPageIndex;
            //datagrid.DataSource = this.ss_dtUser;
            //datagrid.DataBind();
        }
        protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                //mode = "edit";
                //inputPassword.Text = "";
                //this.username = Convert.ToString(e.CommandArgument);
                //HiddenUsername.Value = this.username;
                //DataTable dt = ClassUser.LoadUser(this.username);
                //if (dt.Rows.Count > 0)
                //{
                //    inputUsername.Text = Convert.ToString(dt.Rows[0]["Username"]);
                //    EnableControl(true);
                //    btnSave.Text = "เปลี่ยนรหัสผ่าน";
                //    //inputUsername.Enabled = false;
                //    inputUsername.ReadOnly = true;
                //    rdbRole.SelectedValue = Convert.ToString(dt.Rows[0]["Role_ID"]);
                //}
            }
            else
            {
                //inputUsername.ReadOnly = false;
            }
        }
        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}