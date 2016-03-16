using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web_T_REC.Classes;
using Web_T_REC.Entities;

namespace Web_T_REC
{
    public partial class EquiptmentType : System.Web.UI.Page
    {
        #region Properties
        public DataTable ss_dt
        {
            get { return (DataTable)Session["ss_dt"]; }
            set { Session["ss_dt"] = value; }
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

        public int Level
        {
            get { return (int)Session["Level"]; }
            set { Session["Level"] = value; }
        }

        public EquipmentTypeEN SelectedItem
        {
            get { return (EquipmentTypeEN)Session["SelectedItem"]; }
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
                BindGrid();
                SetDefaultControl();

                BindTree();

            }
        }

        private void BindTree()
        {
            if (TreeView1.Nodes.Count > 0)
            { TreeView1.Nodes.Clear(); }

            DataTable dt = ClassEuipt.LoadData();
            BindTreeView(TreeView1.Nodes, dt, 0);

            if (TreeView1.SelectedValue == "")
            {
                btnAddSub.Visible = false;
            }
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

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)sender;
            txtTypeName.Text = tree.SelectedNode.Text;
            hidID.Value = tree.SelectedValue;
            SearchItem();

            mode = "edit";
            

            divDetail.Visible = true;
            btnAddSub.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = true;
        }

        private void BindGrid()
        {
            DataTable dt = ClassEuipt.LoadData();
            this.ss_dt = dt;
            datagrid.DataSource = dt;
            datagrid.DataBind();

        }

        private void SearchItem()
        {
            EquipmentTypeEN en = new EquipmentTypeEN();
            en = ClassEuipt.SearchByID(Convert.ToInt32(hidID.Value));
            this.SelectedItem = en;
            hidParentID.Value = en.ParentID.ToString();
        }

        private void SetData()
        {
            EquipmentTypeEN en = new EquipmentTypeEN();

            en.ID = Convert.ToInt32(hidID.Value);
            en.TypeName = txtTypeName.Text;
            en.ParentID =  Convert.ToInt32(hidParentID.Value);
            SelectedItem = en;
        }

        private void SetDefaultControl()
        {
            divDetail.Visible = false;
            divsub.Visible = false;
            btnCencel.Visible = false;
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnDelete.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // เพิ่มประเภทหลัก

            hidID.Value = "";
            hidParentID.Value = "0";
            txtTypeName.Text = "";
            divsub.Visible = false;
            MessageVisible(false);
            btnSave.Visible = true;
            Level = 0;

            divDetail.Visible = true;
            //deletebutton.Visible = true;
            mode = "add";
        }

        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            // เพิ่มประเภทย่อย

            hidParentID.Value = hidID.Value;
            hidID.Value = "";
            txtSubName.Text = "";
            MessageVisible(false);
            divsub.Visible = true;
            btnSave.Visible = true;
            Level = 1;

            mode = "add";
        }


        protected void btnCencel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultEN res = new ResultEN();

            if (mode == "add")
            {
                EquipmentTypeEN en = new EquipmentTypeEN();
                if (Level == 0)
                {
                    en.TypeName = txtTypeName.Text;
                }
                else
                {
                    en.TypeName = txtSubName.Text;
                }

                en.ParentID = Convert.ToInt32(hidParentID.Value);

                res = ClassEuipt.Insert_Type(en);
                
            }
            else
            {

                SetData();
                EquipmentTypeEN en = new EquipmentTypeEN();
                en = SelectedItem;
                res = ClassEuipt.Update_Type(en);
            }

            if (res.result)
            {
                MessageShow("บันทึกเรียบร้อยแล้ว");
                BindGrid();
                BindTree();
                SetDefaultControl();
                this.SelectedItem = null;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ResultEN res = ClassEuipt.Delete_Type(SelectedItem);
            MessageShow("ลบรายการเรียบร้อยแล้ว");
            BindGrid();
            BindTree();
            SetDefaultControl();
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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    test();
        //}

        //private void test()
        //{
        //    // do any thing
        //    string tt = LinkButton1.Text;
        //    //LinkButton1.Text = HiddenField1.Value;
        //    LinkButton1.Text = "save";
        //}

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    test();
        //}


        private void MessageShow(string txt)
        {
            msg.Visible = true;
            lblmsg.Text = txt;
        }

        private void MessageVisible(bool bl)
        {
            msg.Visible = bl;
        }

    }
}