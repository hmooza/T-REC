using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Web_T_REC.WebForm
{
    public partial class sys_Users : System.Web.UI.Page
    {
        #region Properties
        public DataTable ss_dtUser
        {
            get { return (DataTable)Session["ss_dtUser"]; }
            set { Session["ss_dtUser"] = value; }
        }

        string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
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
                // Authen Access page
                string username = Context.User.Identity.Name;
                UserEN user = ClassUser.FindUser(username);
                if (user != null)
                {
                    if ((user.rolename == "system") || (user.rolename == "admin"))
                    {
                        divcontent.Visible = true;
                        divwarning.Visible = false;
                    }
                    else
                    {
                        divcontent.Visible = false;
                        divwarning.Visible = true;
                    }
                }

                BindGrid();

                SetDefaultControl();
            }

        }
        private void EnableControl(bool enable)
        {
            inputUsername.ReadOnly = !enable;
            inputPassword.Enabled = enable;

            btnCencel.Visible = enable;
            divDetail.Visible = enable;
            //btnSave.Visible = enable;
            btnDelete.Visible = enable;
            msg.Visible = false;
        }

        private void SetDefaultControl()
        {
            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
            btnCencel.Visible = false;
            divDetail.Visible = false;
        }


        protected void BindGrid()
        {
            DataTable dt = ClassUser.LoadUser();
            this.ss_dtUser = dt;
            dgSearch.DataSource = dt;
            dgSearch.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            EnableControl(true);
            btnSave.Text = "บันทีก";
            btnSave.Visible = true;
            btnDelete.Visible = false;
            inputUsername.Text = "";
            inputPassword.Text = "";
            msg.Visible = false;
            btnAdd.Visible = false;




        }
        protected void btnCencel_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            btnAdd.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultEN res = new ResultEN();

            if (mode == "add")
            {
                int branch_id = 0;
                int role_id = 3;
                if (Session["selectbranch"] != null)
                {
                    branch_id = Convert.ToInt32(Session["selectbranch"]);
                }

                role_id = Convert.ToInt32(rdbRole.SelectedValue);

                res = ClassUser.CreateUser(inputUsername.Text, inputPassword.Text, role_id, branch_id);
                if (res.result)
                {
                    BindGrid();

                    ShowMessage("Created user success.");
                    SetDefaultControl();
                   
                }
            }
            else
            {
                ClassUser.ChangePassword(inputUsername.Text, inputPassword.Text);
                SetDefaultControl();

                ShowMessage("Changed Password success.");
            }


        }

        private void ShowMessage(string txt)
        {
            msg.Visible = true;
            lblmsg.Text = txt;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete
            string res = ClassUser.DeleteUser(HiddenUsername.Value);
            BindGrid();
            EnableControl(false);
        }

        protected void dgSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgSearch.PageIndex = e.NewPageIndex;
            dgSearch.DataSource = this.ss_dtUser;
            dgSearch.DataBind();
        }
        protected void dgSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                mode = "edit";
                inputPassword.Text = "";
                btnAdd.Visible = false;
                this.username = Convert.ToString(e.CommandArgument);
                HiddenUsername.Value = this.username;
                DataTable dt = ClassUser.LoadUser(this.username);
                if (dt.Rows.Count > 0)
                {
                    inputUsername.Text = Convert.ToString(dt.Rows[0]["Username"]);
                    EnableControl(true);
                    btnSave.Text = "เปลี่ยนรหัสผ่าน";
                    //inputUsername.Enabled = false;
                    inputUsername.ReadOnly = true;
                    rdbRole.SelectedValue = Convert.ToString(dt.Rows[0]["Role_ID"]);
                }
            }
            else
            {
                //inputUsername.Enabled = true;
                inputUsername.ReadOnly = false;
            }
        }
        protected void dgSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

    }
}