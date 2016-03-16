using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web_T_REC.Classes;
using Web_T_REC.Entities;
using Web_T_REC.Commons;


namespace Web_T_REC
{
    public partial class Employee : System.Web.UI.Page
    {
        #region Properties
        public DataTable ss_dt
        {
            get { return (DataTable)Session["ss_dt"]; }
            set { Session["ss_dt"] = value; }
        }
        public EquipmentTypeEN SelectedItem
        {
            get { return (EquipmentTypeEN)Session["SelectedItem"]; }
            set { Session["SelectedItem"] = value; }
        }

        public string mode
        {
            get { return (string)Session["mode"]; }
            set { Session["mode"] = value; }
        }

        public int SelectedID
        {
            get { return (int)Session["SelectedID"]; }
            set { Session["SelectedID"] = value; }
        }

        public EmployeeEN Selected
        {
            get { return (EmployeeEN)Session["SelectedItem"]; }
            set { Session["SelectedItem"] = value; }
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
                SetDefult();
                BindGrid();
                LoadControl();
                UC_Position.empid = ""; 
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

        private void MessageShow(string text)
        {
            msg.Visible = true;
            lblmsg.Text = text;
        }

        private void MessageHide()
        {
            msg.Visible = false;            
        }

        private void Save()
        {
            ResultEN res = new ResultEN();
            EmployeeEN en = new EmployeeEN();

            switch (mode)
            {
                case "add":
                    SetItem(en);
                    res = ClassEmployee.Insert(en);

                    break;

                case "edit":
                    en = this.Selected;
                    SetItem(en);
                    res = ClassEmployee.Update(en);

                    break;

                default:
                    break;
            }

            //if (mode == "add")
            //{
            //    EmployeeEN en = new EmployeeEN();
            //    SetItem(en);

            //    res = ClassEmployee.Insert(en);

            //}
            //else
            //{
            //    EmployeeEN en = this.Selected;
            //    SetItem(en);

            //    res = ClassEmployee.Update(en);
            //}

            if (res.result)
            {
                MessageShow("บันทึกเรียบร้อยแล้ว");
                BindGrid();

                SetDefult();
                this.SelectedItem = null;
            }




        }

        private void SetItem(EmployeeEN en)
        {
            en.Firstname = txtFirstName.Text;
            en.Lastname = txtLastName.Text;
            en.Nickname = txtNickname.Text;
            en.IdenNumber = txtIdenNo.Text;
            en.AccNo = txtAccNo.Text;
            en.AccName = txtAccNo.Text;
            en.Address = txtAddress.Text;
            en.StartWorkDate = Utilities.ConvertoDate(txtStartWotk_Date.Text);
            en.BirthDate = Utilities.ConvertoDate(txtBirthDay.Text);
            en.Phone = txtPhone.Text;
            en.Email = txtEmail.Text;

            //
            en.position = "";
            en.salary = Utilities.ConvertToDecimal(txtSalary.Text);  // Convert.ToDecimal( txtSalary.Text);

            en.DeptId = Convert.ToInt16(ddlDept.SelectedValue);

        }
        private void setControl(EmployeeEN en)
        {
            txtFirstName.Text = en.Firstname;
            txtLastName.Text = en.Lastname;
            txtNickname.Text = en.Nickname;
            txtIdenNo.Text = en.IdenNumber;
            txtAccNo.Text = en.AccNo;
            txtAccName.Text = en.AccName;
            txtAddress.Text = en.Address;
            txtPhone.Text = en.Phone;
            txtEmail.Text = en.Email;


            txtStartWotk_Date.Text = Utilities.FormatStringDDMMYYY(en.StartWorkDate);
            txtBirthDay.Text = Utilities.FormatStringDDMMYYY(en.BirthDate);

            txtAge.Text = Convert.ToString((DateTime.Now.Date.Year - en.BirthDate.Date.Year));

            if (en.DeptId != 0)
            { ddlDept.SelectedItem.Value = Convert.ToString(en.DeptId); }

            txtSalary.Text = en.salary.ToString();
        }

        private void ClearText()
        {
            txtEmpID.Text = "";
            txtNickname.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtBirthDay.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtStartWotk_Date.Text = "";
            txtIdenNo.Text = "";
            txtAccNo.Text = "";
            txtAccName.Text = "";
            txtAddress.Text = "";

        }

        private void LoadControl()
        {
            DataTable dt = ClassJopPosition.LoadDept();
            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["Name"] = "-- กรุณาเลือก --";
            dt.Rows.InsertAt(dr, 0);

            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "id";
            ddlDept.DataSource = dt;
            ddlDept.DataBind();
        }


        #region -- GRID --
        private void BindGrid()
        {
            DataTable dt = ClassEmployee.LoadData();
            ss_dt = dt;
            datagrid.DataSource = dt;
            datagrid.DataBind();
        }

        protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                mode = "edit";
                btnAdd.Visible = false;
                ClearText();

                string id = Convert.ToString(e.CommandArgument);
                this.SelectedID = Convert.ToInt32(id);
                EmployeeEN en = ClassEmployee.SearchEmp(this.SelectedID);
                this.Selected = en;
                setControl(en);
                UC_Position.empid = en.Emp_id;
                UC_Position.BindPosition_Emp();

                divDetail.Visible = true;
                btnSave.Visible = true;
                btnDelete.Visible = true;
                btnCencel.Visible = true;
                UC_Position.Visible = true;
            }
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #endregion

        #region -- BUTTON --
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            divDetail.Visible = true;
            ClearText();
            MessageHide();

            btnAdd.Visible = false;
            btnCencel.Visible = true;
            btnSave.Visible = true;
            btnDelete.Visible = false;
            UC_Position.Visible = false;
        }

        protected void btnCencel_Click(object sender, EventArgs e)
        {
            divDetail.Visible = false;

            SetDefult();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            UC_Position.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ResultEN res = ClassEmployee.Delete(this.SelectedID);

            if (res.result == true)
            {
                MessageShow("ลบข้อมูลเรียบร้อยแล้ว");
                SetDefult();
                BindGrid();
            }
        }

        #endregion
    }
    
}