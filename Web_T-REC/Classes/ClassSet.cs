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


        public static string GetRunno()
        {
            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select ISNULL(MAX(a.running),1) as runno from dbo.Equipment_SET_detail");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt.Rows.Count > 0)
            {
                int no = Convert.ToInt32(dt.Rows[0][0]);
                no += 1;
                return no.ToString("00");
            }


            return "01";
        }

        public static bool Insert(List<Equipment_SET_detail> en)
        {
            //ResultEN res = new ResultEN();

            // Gen Employee code
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            string code = "E" + DateTime.Now.Date.Year.ToString(cultureinfo);

            string runno = GetRunno();
            code += runno;

            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("Emp_id", code));
            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            //SetField(fields, en);


            //res = ClassMain.Insert(tb_name, fields);
            return true;
        }

        //public static ResultEN Update(EmployeeEN en)
        //{
        //    ResultEN res = new ResultEN();
        //    List<ClassFieldValue> fields = new List<ClassFieldValue>();

        //    fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));
        //    fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
        //    SetField(fields, en);

        //    List<ClassFieldValue> fieldscon = new List<ClassFieldValue>();
        //    fieldscon.Add(new ClassFieldValue("Emp_id", en.Emp_id));

        //    res = ClassMain.Update(tb_name, fields, fieldscon);
        //    return res;
        //}

        public static ResultEN Delete(int id)
        {
            ResultEN res = new ResultEN();
            string sql = "DELETE From Employees Where id=" + id;
            res.result = ClassMain.ExecuteQuery(sql);
            return res;
        }

    }
}