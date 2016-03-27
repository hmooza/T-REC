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
        public static List<Equipment> SSEquipments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SSEquipments = null;
                LoadConfig();
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

        private void Addgrid_Detail()
        {
            List<Equipment> lstEquipments = null;
            Equipment[] Equipments = null;

            int _id = Convert.ToInt32(this.ddlEquipmentList.SelectedItem.Value);
            ClassSet.LoadTypeEquipment(out Equipments, null, _id);

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
            Equipment_SETone.Price = Convert.ToDecimal(this.txtPrice.Text);
            Equipment_SETone.SETName = this.txtSetName.Text;
            Equipment_SETone.Description = this.txtDescription.Text;

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

            //Call Save
            bool result = ClassSet.SetData_Equipment(Equipment_SETone, lstEquipment_SET_detail);
            if (result)
            {
            }

        }

        #region " Event "

        protected void btnCencel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

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
            ClassSet.LoadTypeEquipment(out Equipments, _type);
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
            Addgrid_Detail();
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

        protected void grid_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.FindControl("ID");
            //}
            //else if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //}
        }

    }
}