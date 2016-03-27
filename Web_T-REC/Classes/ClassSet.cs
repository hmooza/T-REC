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

        public static void LoadTypeEquipment(out Equipment[] objects, int? Equip_type_id, int? _id = null)
        {
            objects = null;

            string condition = "";

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select * FROM [dbo].[Equipment] ");
            //sql.AppendLine("where Equip_type_id = " + Equip_type_id);

            if (Equip_type_id != null)
            {
                if (condition == "")
                    condition = condition + "WHERE\n    ";
                else
                    condition = condition + "   AND ";
                condition = condition + "Equip_type_id = " + Equip_type_id + "\n";
            }

            if (_id != null)
            {
                if (condition == "")
                    condition = condition + "WHERE\n    ";
                else
                    condition = condition + "   AND ";
                condition = condition + " id = " + _id + "\n";
            }

            sql.AppendLine(condition);

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

                    en.CostBuy = item["CostBuy"] != DBNull.Value ? Convert.ToDecimal(item["CostBuy"].ToString()) : (decimal?)null;//int.Parse(item["CostBuy"].ToString());
                    en.CostRent = item["CostRent"] != DBNull.Value ? Convert.ToDecimal(item["CostRent"].ToString()) : (decimal?)null;// int.Parse(item["CostRent"].ToString());

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

        public static int? GetID(string TB_Name, string Id)
        {
            int? no = null;
            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select ISNULL(MAX(a." + Id + "),1) as runno from dbo." + TB_Name + " a");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                no = Convert.ToInt32(dt.Rows[0][0]);
            }
            return no;
        }

        public static void GetDate_Equipment_SET(out Equipment_SET[] Equipment_SETs,int SET_ID)
        {
            Web_T_REC.DataModel.Entities efen = new DataModel.Entities();

            Equipment_SETs = (from a in efen.Equipment_SET
                              where a.SET_ID == SET_ID 
                              select a).ToArray();
        }

        private static List<ClassFieldValue> SetField_SET(List<ClassFieldValue> fields, Equipment_SET en)
        {
            //fields.Add(new ClassFieldValue("SET_ID", en.SET_ID));
            fields.Add(new ClassFieldValue("SETName", en.SETName));
            fields.Add(new ClassFieldValue("Price", en.Price));
            fields.Add(new ClassFieldValue("Description", en.Description));
            return fields;
        }

        private static List<ClassFieldValue> SetField_SET_DETAIL(List<ClassFieldValue> fields, Equipment_SET_detail en)
        {
            //fields.Add(new ClassFieldValue("SET_DET_ID", en.SET_DET_ID));
            fields.Add(new ClassFieldValue("SET_ID", en.SET_ID));
            fields.Add(new ClassFieldValue("Equip_ID", en.Equip_ID));
            fields.Add(new ClassFieldValue("cost", en.cost));
            return fields;
        }

        public static ResultEN Insert_Equipment_SET_detail(Equipment_SET_detail en)
        {
            ResultEN res = new ResultEN();

            //int? _Id = GetID("Equipment_SET_detail", "SET_DET_ID");

            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            //en.SET_DET_ID = _Id.Value;
            fields = SetField_SET_DETAIL(fields, en);

            res = ClassMain.Insert("Equipment_SET_detail", fields);
            return res;
        }

        public static ResultEN Insert_Equipment_SET(ref Equipment_SET en)
        {
            ResultEN res = new ResultEN();

            // int? _Id = GetID("Equipment_SET", "SET_ID");
            List<ClassFieldValue> fields = new List<ClassFieldValue>();

            //en.SET_ID = _Id.Value;
            fields = SetField_SET(fields, en);

            res = ClassMain.Insert("Equipment_SET", fields);
            return res;
        }

        public static ResultEN Delete(int id)
        {
            ResultEN res = new ResultEN();
            string sql = "DELETE From Employees Where id=" + id;
            res.result = ClassMain.ExecuteQuery(sql);
            return res;
        }

        public static bool SetData_Equipment(Equipment_SET Equipment_SETone, List<Equipment_SET_detail> lstEquipment_SET_detail)
        {
            bool result = false;
            ResultEN ResultENs = new ResultEN();
            if (Equipment_SETone != null)
            {
                ResultENs = Insert_Equipment_SET(ref Equipment_SETone);

                if (ResultENs != null && ResultENs.result == true)
                {
                    if (lstEquipment_SET_detail != null && lstEquipment_SET_detail.Any())
                    {
                        Equipment_SET[] Equipment_SETs = null;
                        lstEquipment_SET_detail.ForEach(x => x.SET_ID = Convert.ToInt32(ResultENs.returnValue));

                        foreach (var item in lstEquipment_SET_detail)
                        {
                            ResultENs = Insert_Equipment_SET_detail(item);
                            if (ResultENs.result == false)
                            {
                                result = false;
                            }
                            else

                            {
                                result = true;
                            }
                        }
                    }
                }
                else
                {
                    //break;
                }
            }

            return result;
        }

    }
}