using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_T_REC.Classes;
using Web_T_REC.DataModel;

namespace Web_T_REC
{
    public partial class Package : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                SetDefult();
                LoadConfig();
            }
        }

        private void initial(int? Set_id = null)
        {
            //Equipment_SET[] Equipment_SETs = null;
            //ClassSet.GetDate_Equipment_SET(out Equipment_SETs, Set_id);

            //grid_SetName.DataSource = Equipment_SETs;
            //grid_SetName.DataBind();
        }

        private void LoadConfig()
        {
            this.ddlSet.Items.Add(new ListItem("กรุณาเลือก", "-1"));
            this.ddlEquipmentList.Items.Add(new ListItem("กรุณาเลือก", "-1"));

            Equipment_SET[] Equipment_SETs = null;
            ClassSet.GetDate_Equipment_SET(out Equipment_SETs, null);
            if (Equipment_SETs != null && Equipment_SETs.Any())
            {
                Equipment_SETs = Equipment_SETs.OrderBy(x => x.SETName).ToArray();
                foreach (Equipment_SET en in Equipment_SETs)
                {
                    this.ddlSet.Items.Add(new ListItem(en.SETName, en.SET_ID.ToString()));
                }

                ddlSet.SelectedIndex = 0;
            }

            ListItem[] lts = null;
            ClassPackage.GetEQForDDL_All(out lts);

            if (lts != null && lts.Any())
            {
                foreach (ListItem lt in lts)
                {
                    this.ddlEquipmentList.Items.Add(lt);
                }
                this.ddlEquipmentList.SelectedIndex = 0;
            }
        }

        private void SetDefult()
        {
            btnAdd.Visible = true;
            btnCencel.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            divDetail.Visible = false;
        }

        #region " Event "

        protected void btnAddSet_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddEquip_Click(object sender, EventArgs e)
        {

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

        #endregion 
    }
}