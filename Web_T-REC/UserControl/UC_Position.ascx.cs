using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Web_T_REC.Classes;
using Web_T_REC.Entities;
using Web_T_REC.Commons;

namespace Web_T_REC.UserControl
{
    public partial class UC_Position : System.Web.UI.UserControl
    {
        #region Properties
        public DataTable ss_dt
        {
            get { return (DataTable)Session["ss_dt"]; }
            set { Session["ss_dt"] = value; }
        }
        public string empid
        {
            get { return (string)Session["ss_empid"]; }
            set { Session["ss_empid"] = value; }
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
                LoadPosition();
                if ((this.empid != "") || (this.empid != ""))
                {
                    BindPosition_Emp();
                }
            }
        }

        private void LoadPosition()
        {
            DataTable dt = ClassJopPosition.LoadData();

            // Set Defult
            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["position"] = "";
                dr["cost"] = "";
                dt.Rows.Add(dr);
            }

            dt.Columns.Add("name");
            foreach (DataRow dr in dt.Rows)
            {
                dr["name"] = dr["position"] + " " + dr["cost"] + " บาท";
            }

            ddlPosition.DataTextField = "name";
            ddlPosition.DataValueField = "id";
            ddlPosition.DataSource = dt;
            ddlPosition.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            JobPositionEN pos = ClassJopPosition.SearchByPosid(Convert.ToInt16(ddlPosition.SelectedValue));

            JobPosition_EmpEN en = new JobPosition_EmpEN();
            en.empid = this.empid;
            en.posid = Convert.ToInt16(ddlPosition.SelectedValue);
            en.cost = pos.cost;

            ClassJopPosition.InsertPosition_Emp(en);

            BindPosition_Emp();
        }


        public void BindPosition_Emp()
        {
            DataTable dt = ClassJopPosition.SearchPosiionByEmp(this.empid);

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["position"] = "";
                dr["pos_id"] = 0;

                dt.Rows.Add(dr);
            }

            datagrid.DataSource = dt;
            datagrid.DataBind();

        }
    }
}