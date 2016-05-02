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
    public partial class Equiptment : System.Web.UI.Page
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

        public EquiptmentEN SelectedEquip
        {
            get { return (EquiptmentEN)Session["SelectedItem"]; }
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
                BindTree();

                BindGrid();
                SetDefult();
            }
        }

        private void BindTree()
        {
            if (TreeView1.Nodes.Count > 0)
            { TreeView1.Nodes.Clear(); }

            DataTable dt = ClassEuipt.LoadData();
            BindTreeView(TreeView1.Nodes, dt, 0);


        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)sender;
            txtTypeName.Text = tree.SelectedNode.Text;
            hidID.Value = tree.SelectedValue;
            // SearchItem();
        }

        private void BindTreeView(TreeNodeCollection NodeCollection, DataTable dt, int Level)
        {
            IEnumerable<DataRow> nodes = from d in dt.AsEnumerable()
                                         where d.Field<int>("ParentID") == Level
                                         select d;

            foreach (DataRow Dr in nodes)
            {
                TreeNode node = new TreeNode(Dr.Field<string>("TypeName"), Convert.ToString(Dr.Field<int>("ID")));
                NodeCollection.Add(node);
                BindTreeView(node.ChildNodes, dt, Dr.Field<int>("ID"));
            }
        }

        private void BindGrid()
        {
            DataTable dt = ClassEuipt.LoadData_Master();
            this.ss_dt = dt;
            datagrid.DataSource = dt;
            datagrid.DataBind();

            if (dt.Rows.Count == 0)
            {
                MessageShow("ไม่มีข้อมูล");
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

        private void Save()
        {
            ResultEN res = new ResultEN();
            EquiptmentEN en = new EquiptmentEN();


            switch (mode)
            {
                case "add":
                    
                    SetItem(en);

                    res = ClassEuipt.Insert_Equip(en);
                    break;


                case "edit":
                    en = this.SelectedEquip;
                    SetItem(en);

                    res = ClassEuipt.Update_Equip(en);
                    break;

                default:
                    break;

            }


            //if (mode == "add")
            //{
            //    EquiptmentEN en = new EquiptmentEN();
            //    SetItem(en);

            //    res = ClassEuipt.Insert_Equip(en);

            //}
            //else
            //{
            //    EquiptmentEN en = this.SelectedEquip;
            //    SetItem(en);

            //    res = ClassEuipt.Update_Equip(en);
            //}

            if (res.result)
            {
                MessageShow("บันทึกเรียบร้อยแล้ว");
                BindGrid();
                BindTree();
                SetDefult();
                this.SelectedItem = null;
            }




        }

        private void SetItem(EquiptmentEN en)
        {
            en.Name = txtName.Text;
            en.Fullname = txtFullName.Text;
            en.EquipNo = txtEquipNo.Text;
            en.ReceiptTax = txtReceiptTax.Text;
            en.SupplierName = txtSupplierName.Text;
            en.ExpireDate = Utilities.ConvertoDate(txtExpireDate.Text);
            en.BuyDate = Utilities.ConvertoDate(txtBuyDate.Text);
            en.CostBuy = Convert.ToDecimal(txtCostBuy.Text);
            en.CostRent = Convert.ToDecimal(txtCostRent.Text);
            en.SN = txtSN.Text;

            en.Equip_type_id = Convert.ToInt32(hidID.Value);
        }

        private void ClearText()
        {
            txtBuyDate.Text = "";
            txtCostBuy.Text = "";
            txtCostRent.Text = "";
            txtExpireDate.Text = "";
            txtFullName.Text = "";
            txtName.Text = "";
            txtEquipNo.Text = "";
            txtReceiptTax.Text = "";
            txtSN.Text = "";
            txtSupplierName.Text = "";
            txtTypeName.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            ClearText();

            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnCencel.Visible = true;
            btnDelete.Visible = false;

            divDetail.Visible = true;
            msg.Visible = false;
        }

        protected void btnCencel_Click(object sender, EventArgs e)
        {
            SetDefult();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Save();
            SetDefult();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                mode = "edit";
                btnAdd.Visible = false;
                ClearText();

                int id = Convert.ToInt32(e.CommandArgument);
                this.SelectedID = id;
                EquiptmentEN en = ClassEuipt.SearchEquipByID(id);
                this.SelectedEquip = en;
                setControl(en);



                divDetail.Visible = true;
                btnSave.Visible = true;
                btnDelete.Visible = true;
                btnCencel.Visible = true;
            }
            else
            {

            }
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        private void setControl(EquiptmentEN en)
        {
            txtBuyDate.Text = en.BuyDate.ToString("dd/MM/yyyy");
            txtCostBuy.Text = en.CostBuy.ToString();
            txtCostRent.Text = en.CostRent.ToString();
            txtExpireDate.Text = en.ExpireDate.ToString("dd/MM/yyyy");
            txtFullName.Text = en.Fullname;
            txtName.Text = en.Name;
            txtEquipNo.Text = en.EquipNo;
            txtReceiptTax.Text = en.ReceiptTax;
            txtSN.Text = en.SN;
            txtSupplierName.Text = en.SupplierName;
            txtTypeName.Text = en.equipType.TypeName;

            hidID.Value = en.Equip_type_id.ToString();
        }

    }
}