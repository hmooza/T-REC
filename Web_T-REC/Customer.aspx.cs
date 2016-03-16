using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_T_REC.Entities;
using Web_T_REC.Classes;

namespace Web_T_REC
{
    public partial class Customer : System.Web.UI.Page
    {
        enum Enum_Mode
        {
            Add = 1,
            Edit = 2
        }
        public int mode
        {
            get { return (int)ViewState["mode"]; }
            set { ViewState["mode"] = value; }
        }

        public CustomerEN[] ss_CustomerEN
        {
            get { return (CustomerEN[])Session["ss_CustomerEN"]; }
            set { Session["ss_CustomerEN"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                btnDelete.Attributes.Add("style", "display:none;");
                btnAdd.Attributes.Add("style", "display:none;");
                LoadData();
            }
        }

        private void LoadData()
        {
            CustomerEN[] CustomerENs = null;
            //DataTable dt = ClassJopPosition.LoadDept();
            ClassCustomer.LoadData(out CustomerENs);

            if (CustomerENs != null && CustomerENs.Any())
            {
                divCustormerDetail.Visible = false;
                dgSearch.Visible = true;
                ss_CustomerEN = CustomerENs;
                dgSearch.DataSource = CustomerENs;
                dgSearch.DataBind();
                mode = Enum_Mode.Edit.GetHashCode();
                btnAdd.Attributes.Add("style", "display;");
                btnCencel.Attributes.Add("style", "display:none;");
                btnSave.Attributes.Add("style", "display:none;");
                btnDelete.Attributes.Add("style", "display:none;");
            }
            else
            {
                btnAdd.Attributes.Add("style", "display:none;");
                btnCencel.Attributes.Add("style", "display:none;");
                btnSave.Attributes.Add("style", "display;");
                btnDelete.Attributes.Add("style", "display:none;");
                mode = Enum_Mode.Add.GetHashCode();
                divCustormerDetail.Visible = true;
                dgSearch.Visible = false;
            }
        }

        #region " Event "
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnCencel.Attributes.Add("style", "display;");
            btnSave.Attributes.Add("style", "display;");
            btnAdd.Attributes.Add("style", "display:none;");
            btnDelete.Attributes.Add("style", "display:none;");
            divCustormerDetail.Visible = true;
            mode = Enum_Mode.Add.GetHashCode();
            set();
        }

        protected void btnCencel_Click(object sender, EventArgs e)
        {
            divCustormerDetail.Visible = false;

            if (ss_CustomerEN != null && ss_CustomerEN.Any())
            {
                btnAdd.Attributes.Add("style", "display;");
            }
            else
            {
                btnAdd.Attributes.Add("style", "display:none;");
            }
            btnCencel.Attributes.Add("style", "display:none;");
            btnSave.Attributes.Add("style", "display:none;");
            btnDelete.Attributes.Add("style", "display:none;");
            set();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultEN ResultENs = new ResultEN();
            CustomerEN CustomerENs = new CustomerEN();

            CustomerENs.C_ID = this.txtC_ID.Text;
            CustomerENs.Name = this.txtName.Text;
            CustomerENs.Tel = this.txtTel.Text;
            CustomerENs.Email = this.txtEmail.Text;
            CustomerENs.Fax = this.txtFax.Text;
            CustomerENs.Name_Company = this.txtCompany.Text;
            CustomerENs.Tel_Company = this.txtTel_Company.Text;
            CustomerENs.Address = this.txtAddress.Text;
            CustomerENs.Tax_Number = this.txtTax_Number.Text;

            if (Enum_Mode.Add.GetHashCode() == mode)
            {
                CustomerENs.CreatedBy = "";
                CustomerENs.CreatedDate = DateTime.Now;
                ResultENs = ClassCustomer.Insert(CustomerENs);
            }
            else if (Enum_Mode.Edit.GetHashCode() == mode)
            {
                CustomerENs.UpdatedBy = "";
                CustomerENs.UpdatedDate = DateTime.Now;
                ResultENs = ClassCustomer.Update(CustomerENs);
            }

            if (ResultENs != null && ResultENs.result)
            {
                LoadData();
            }
            else
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string C_ID = this.txtC_ID.Text;
            ResultEN ResultENs = ClassCustomer.Delete(C_ID);
            if (ResultENs != null && ResultENs.result)
            {
                LoadData();
                set();
            }
            else
            {
            }
        }

        void set()
        {
            this.txtC_ID.Text = "";
            this.txtName.Text = "";
            this.txtTel.Text = "";
            this.txtEmail.Text = "";
            this.txtFax.Text = "";
            this.txtCompany.Text = "";
            this.txtTel_Company.Text = "";
            this.txtAddress.Text = "";
            this.txtTax_Number.Text = "";
        }

        protected void dgSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                btnDelete.Attributes.Add("style", "display;");
                btnSave.Attributes.Add("style", "display;");
                btnCencel.Attributes.Add("style", "display;");
                btnAdd.Attributes.Add("style", "display:none;");
                mode = 2;
                CustomerEN[] CustomerENs = (CustomerEN[])ss_CustomerEN;

                if (CustomerENs != null)
                {
                    divCustormerDetail.Visible = true;
                    string C_ID = Convert.ToString(e.CommandArgument);

                    if (!string.IsNullOrEmpty(C_ID))
                    {
                        var _t = (from a in CustomerENs
                                  where a.C_ID == C_ID
                                  select new CustomerEN
                                  {
                                      C_ID = a.C_ID,
                                      Address = a.Address,
                                      CreatedBy = a.CreatedBy,
                                      CreatedDate = a.CreatedDate,
                                      Email = a.Email,
                                      EXT = a.EXT,
                                      Fax = a.Fax,
                                      ID = a.ID,
                                      Name = a.Name,
                                      Name_Company = a.Name_Company,
                                      Tax_Number = a.Tax_Number,
                                      Tel = a.Tel,
                                      Tel_Company = a.Tel_Company,
                                      UpdatedBy = a.UpdatedBy,
                                      UpdatedDate = a.UpdatedDate
                                  }).First();

                        this.txtC_ID.Text = _t.C_ID;
                        this.txtName.Text = _t.Name;
                        this.txtTel.Text = _t.Tel;
                        this.txtEmail.Text = _t.Email;
                        this.txtFax.Text = _t.Fax;
                        this.txtCompany.Text = _t.Name_Company;
                        this.txtTel_Company.Text = _t.Tel_Company;
                        this.txtAddress.Text = _t.Address;
                        this.txtTax_Number.Text = _t.Tax_Number;
                    }
                }
            }
            else
            {
                //inputUsername.Enabled = true;
                //inputUsername.ReadOnly = false;
            }
        }

        protected void dgSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgSearch.PageIndex = e.NewPageIndex;
            dgSearch.DataSource = ss_CustomerEN;
            dgSearch.DataBind();
        }
        #endregion
    }

}