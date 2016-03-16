using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Web_T_REC.DataModel;

namespace Web_T_REC.Classes
{
    public class ClassSet
    {
        public static void LoadType(out Equipment_Type[] objects, int Level)
        {
            objects = null;

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select * FROM [dbo].[Equipment_Type] ");
            sql.AppendLine("where ParentID = " + Level);

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                List<Equipment_Type> lstEquipment_Type = new List<Equipment_Type>();
                foreach (DataRow item in dt.Rows)
                {
                    Equipment_Type en = new Equipment_Type();
                    en.ID = int.Parse(item["Id"].ToString());
                    en.TypeName = item["TypeName"].ToString();
                    en.ParentID = int.Parse(item["ParentID"].ToString());
                    en.CreatedDate = item["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(item["CreatedDate"].ToString()) : (DateTime?)null;
                    en.CreatedBy = item["CreatedBy"].ToString();
                    en.UpdatedDate = item["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(item["UpdatedDate"].ToString()) : (DateTime?)null;
                    en.UpdatedBy = item["UpdatedBy"].ToString();

                    lstEquipment_Type.Add(en);
                }

                if (lstEquipment_Type != null && lstEquipment_Type.Any())
                {
                    objects = lstEquipment_Type.ToArray();
                }
            }
        }

        public static void LoadTypeEquipment(out Equipment[] objects, int Equip_type_id)
        {
            objects = null;

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * FROM [dbo].[Equipment] ");
            sql.AppendLine("where Equip_type_id = " + Equip_type_id);

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                List<Equipment> lstEquipment = new List<Equipment>();
                foreach (DataRow item in dt.Rows)
                {
                    Equipment en = new Equipment();
                    en.ID = int.Parse(item["Id"].ToString());
                    en.Equip_type_id = int.Parse(item["Equip_type_id"].ToString());
                    en.CreatedDate = item["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(item["CreatedDate"].ToString()) : (DateTime?)null;
                    en.CreatedBy = item["CreatedBy"].ToString();
                    en.UpdatedDate = item["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(item["UpdatedDate"].ToString()) : (DateTime?)null;
                    en.UpdatedBy = item["UpdatedBy"].ToString();

                    en.Fullname = item["Fullname"].ToString();
                    en.SN = item["SN"].ToString();
                    en.Number = item["Number"].ToString();

                    en.CostBuy = int.Parse(item["CostBuy"].ToString());
                    en.CostRent = int.Parse(item["CostRent"].ToString());
                    en.ID = int.Parse(item["Id"].ToString());

                    en.SupplierName = item["SupplierName"].ToString();
                    en.BuyDate = item["BuyDate"] != DBNull.Value ? Convert.ToDateTime(item["BuyDate"].ToString()) : (DateTime?)null;
                    en.ReceiptTax = item["ReceiptTax"].ToString();
                    en.ExpireDate = item["ExpireDate"] != DBNull.Value ? Convert.ToDateTime(item["ExpireDate"].ToString()) : (DateTime?)null;

                    lstEquipment.Add(en);
                }

                if (lstEquipment != null && lstEquipment.Any())
                {
                    objects = lstEquipment.ToArray();
                }
            }
        }


    }
}