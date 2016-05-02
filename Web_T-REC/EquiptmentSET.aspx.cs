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
        public static int? VSSet_Id { get; set; }

        public static List<Equipment> SSEquipments { get; set; }

        private static Enum_Mode VSEnum_Mode { get; set; }

        private enum Enum_Mode
        {
            Add = 1,
            Edit = 2,
            Delete = 3
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager sp = ScriptManager.GetCurrent(this);
            sp.RegisterAsyncPostBackControl(btnSave);
            sp.RegisterAsyncPostBackControl(btnDelete);

            if (!Page.IsPostBack)
            {
                VSEnum_Mode = Enum_Mode.Add;
                SSEquipments = null;
                LoadConfig();
                initial();
            }
        }

        private void LoadConfig()
        {
            this.ddlType.Items.Add(new ListItem("กรุณาเลือก", "-1"));
            this.ddlCategory.Items.Add(new ListItem("กรุณาเลือก", "-1"));
            this.ddlEquipmentList.Items.Add(new ListItem("กรุณาเลือก", "-1"));

            Equipment_Type[] Equipment_Types = null;
            ClassSet.LoadType(out Equipment_Types, 0);
            if (Equipment_Types != null && Equipment_Types.Any())
            {
                foreach (Equipment_Type en in Equipment_Types)
                {
                    this.ddlType.Items.Add(new ListItem(en.TypeName, en.ID.ToString()));
                }

                ddlType_SelectedIndexChanged(null, null);

                ddlCategory.SelectedIndex = 0;
                ddlEquipmentList.SelectedIndex = 0;
            }
        }

        private void MessageShow(string text)
        {
            msg.Visible = true;
            lblmsg.Text = text;
        }

        private void initial(int? Set_id = null)
        {
            Equipment_SET[] Equipment_SETs = null;
            ClassSet.GetDate_Equipment_SET(out Equipment_SETs, Set_id);

            grid_SetName.DataSource = Equipment_SETs;
            grid_SetName.DataBind();
        }

        private void initial_Detail(int? Set_id = null)
        {
            Equipment_SET_detail[] Equipment_SET_details = null;
            ClassSet.GetDate_Equipment_SET_Detail(out Equipment_SET_details, Set_id);

            if (Equipment_SET_details != null && Equipment_SET_details.Any())
            {
                SSEquipments = null;
                     
                int?[] Equip_IDs = Equipment_SET_details.Select(x => (int?)x.Equip_ID).Distinct().ToArray();

                Addgrid_Detail(Equip_IDs);
            }
        }

        private void Addgrid_Detail(int?[] Equip_ID)
        {
            List<Equipment> lstEquipments = null;
            Equipment[] Equipments = null;

            ClassSet.LoadTypeEquipment(out Equipments, null, Equip_ID);

            if (Equipments != null && Equipments.Any())
            {
                lstEquipments = SSEquipments;

                if (lstEquipments == null || !lstEquipments.Any() || lstEquipments.Count < 1)
                {
                    lstEquipments = new List<Equipment>();
                }

                lstEquipments.AddRange(Equipments);
                lstEquipments = lstEquipments.OrderBy(x => x.Name).ToList();
            }

            SSEquipments = lstEquipments;
            grid_Detail.DataSource = lstEquipments;
            grid_Detail.DataBind();
        }

        private void Save()
        {
            Equipment_SET Equipment_SETone = new Equipment_SET();
            List<Equipment_SET_detail> lstEquipment_SET_detail = null;

            //GridView grid_Detail = grid_Detail;
            if (this.grid_Detail != null && this.grid_Detail.Rows.Count > 0)
            {
                lstEquipment_SET_detail = new List<Equipment_SET_detail>();

                foreach (GridViewRow item in grid_Detail.Rows)
                {
                    Equipment_SET_detail en = new Equipment_SET_detail();

                    en.Equip_ID = Convert.ToInt32(item.Cells[Enum_grid_Detail.ID.GetHashCode()].Text);//ID
                    en.cost = Convert.ToDecimal(item.Cells[Enum_grid_Detail.CostRent.GetHashCode()].Text);//CostRent

                    lstEquipment_SET_detail.Add(en);
                }
            }

            if (VSEnum_Mode == Enum_Mode.Add)
            {
                Equipment_SETone.Price = Convert.ToDecimal(this.txtPrice.Text);
                Equipment_SETone.SETName = this.txtSetName.Text;
                Equipment_SETone.Description = this.txtDescription.Text;
            }
            else if (VSEnum_Mode == Enum_Mode.Edit)
            {
                //Equipment_SET[] Equipment_SETs = null;
                //ClassSet.GetDate_Equipment_SET(out Equipment_SETs, VSSet_Id);
                lstEquipment_SET_detail.ToList().ForEach(x => x.SET_ID = VSSet_Id.Value);
                //SSEquipments
            }
            else if (VSEnum_Mode == Enum_Mode.Delete)
            {
            }

            //Call Save
            int? SET_ID = ClassSet.SetData_Equipment(Equipment_SETone, lstEquipment_SET_detail, VSEnum_Mode.GetHashCode());
            if (SET_ID != null)
            {
                initial(SET_ID);

                string message = "บันทึกเรียบร้อยแล้ว";
                MessageShow(message);
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "ToggleScript", "Alert(" + message + ")", true);
            }
        }

        private void Delete()
        {
            if (VSSet_Id != null)
            {
                int?[] _set_id = { VSSet_Id };
                ResultEN result_detail = ClassSet.Delete_Equipment_SET_detail(_set_id);
                if (result_detail != null && result_detail.result)
                {
                    ResultEN result_Set_detail = ClassSet.Delete_Equipment_SET(_set_id);

                    string message = "ลบสำเร็จ";
                    MessageShow(message);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "ToggleScript", "Alert(" + message + ")", true);
                }
            }
        }

        #region " Event "

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtPrice.Text = "";
            this.txtSetName.Text = "";
            this.txtDescription.Text = "";

            this.txtPrice.Enabled = true;
            this.txtSetName.Enabled = true;
            this.txtDescription.Enabled = true;

            grid_Detail.DataSource = null;
            grid_Detail.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _type = Convert.ToInt32(ddlType.SelectedItem.Value);
            Equipment_Type[] Equipment_Types = null;
            ClassSet.LoadType(out Equipment_Types, _type);
            if (Equipment_Types != null && Equipment_Types.Any())
            {
                this.ddlCategory.Items.Clear();
                this.ddlCategory.Items.Add(new ListItem("กรุณาเลือก", "-1"));
                foreach (Equipment_Type en in Equipment_Types)
                {
                    this.ddlCategory.Items.Add(new ListItem(en.TypeName, en.ID.ToString()));
                }
                this.ddlCategory.SelectedIndex = 0;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Equipment[] Equipments = null;
            int _type = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            ClassSet.LoadTypeEquipment(out Equipments, _type, null);
            if (Equipments != null && Equipments.Any())
            {
                this.ddlEquipmentList.Items.Clear();
                this.ddlEquipmentList.Items.Add(new ListItem("กรุณาเลือก", "-1"));
                foreach (Equipment en in Equipments)
                {
                    this.ddlEquipmentList.Items.Add(new ListItem(en.Fullname, en.ID.ToString()));
                }
                this.ddlEquipmentList.SelectedIndex = 0;
            }
        }

        protected void btnAddEq_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(this.ddlEquipmentList.SelectedItem.Value);
            int?[] Equip_ID = { _id };
            Addgrid_Detail(Equip_ID);
        }

        protected void btnCreateSetName_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private enum Enum_grid_Detail
        {
            No = 0,
            Name = 1,
            strCostRent = 2,
            UpdatedDate = 3,
            UpdatedBy = 4,
            ID = 5,
            CostRent = 6
        }

        private enum Enum_grid_SetName
        {
            No = 0,
            SETName = 1,
            Price = 2,
            Description = 3,
            SET_ID = 4
        }

        protected void grid_SetName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("lnkSetName"))
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;

                int SET_ID = Convert.ToInt32(clickedRow.Cells[Enum_grid_SetName.SET_ID.GetHashCode()].Text);//ID
                string SETName = Convert.ToString(clickedRow.Cells[Enum_grid_SetName.SETName.GetHashCode()].Text);//ID
                decimal Price = Convert.ToDecimal(clickedRow.Cells[Enum_grid_SetName.Price.GetHashCode()].Text);//ID
                string Description = Convert.ToString(clickedRow.Cells[Enum_grid_SetName.Description.GetHashCode()].Text);//ID

                this.txtPrice.Text = Price.ToString("n2");
                this.txtSetName.Text = SETName;
                this.txtDescription.Text = Description;

                this.txtPrice.Enabled = false;
                this.txtSetName.Enabled = false;
                this.txtDescription.Enabled = false;

                VSEnum_Mode = Enum_Mode.Edit;

                RequiredFieldValidator_SetName.Enabled = false;
                RequiredFieldValidator_Description.Enabled = false;
                RequiredFieldValidator_Price.Enabled = false;

                initial_Detail(SET_ID);
                VSSet_Id = SET_ID;
            }
        }

    }
}