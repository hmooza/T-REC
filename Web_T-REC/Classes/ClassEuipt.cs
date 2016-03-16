using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Web_T_REC.Entities;


namespace Web_T_REC.Classes
{
    public class ClassEuipt
    {
        const string tb_name_type = "Equipment_Type";
        const string tb_name_master = "Equipment";

        public static DataTable LoadData()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "select * from " + tb_name_type + " order by TypeName";

            DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
            return dt;
        }

        public static DataTable LoadData_Master()
        {
            StringBuilder Sql = new StringBuilder();
            Sql.AppendLine("select e.*, t.TypeName");
            Sql.AppendLine("from "+ tb_name_master +" e ");
            Sql.AppendLine("inner join "+ tb_name_type +" t on e.Equip_type_id = t.ID");
            Sql.AppendLine("");

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = Sql.ToString();

            DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
            return dt;
        }

        public static ResultEN Insert_Type(EquipmentTypeEN en)
        {
            // SqlCommand sqlCmd = new SqlCommand();
            // sqlCmd.CommandText = "insert into " + tb_name_type +" ()";


            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("TypeName", en.TypeName));
            fields.Add(new ClassFieldValue("ParentID", en.ParentID));
            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            ResultEN res = new ResultEN();

            // ClassMain cls = new ClassMain();
            res = ClassMain.Insert(tb_name_type, fields);


            return res;
        }

        public static ResultEN Update_Type(EquipmentTypeEN en)
        {
            // SqlCommand sqlCmd = new SqlCommand();
            // sqlCmd.CommandText = "insert into " + tb_name_type +" ()";


            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("TypeName", en.TypeName));
            fields.Add(new ClassFieldValue("ParentID", en.ParentID));
            fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
            ResultEN res = new ResultEN();

            // ClassMain cls = new ClassMain();
            List<ClassFieldValue> fieldWhere = new List<ClassFieldValue>();
            fieldWhere.Add(new ClassFieldValue("ID", en.ID));
            res = ClassMain.Update(tb_name_type, fields, fieldWhere);

            return res;
        }

        public static ResultEN Delete_Type(EquipmentTypeEN en)
        {
            ResultEN res = new ResultEN();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "Delete From " + tb_name_type + " WHERE ParentID = " + en.ID;
            sqlCmd.CommandType = CommandType.Text;

            // delete child
            res.result = ClassMain.ExecuteComand(sqlCmd);


            // delete parent
            sqlCmd.CommandText = "Delete From " + tb_name_type + " WHERE ID = " + en.ID;
            res.result = ClassMain.ExecuteComand(sqlCmd);

            return res;
        }

        public static EquipmentTypeEN SearchByID(int ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "select * from " + tb_name_type + " Where ID =" + ID.ToString();

            DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
            EquipmentTypeEN en = new EquipmentTypeEN();

            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                en.ID = Convert.ToInt32(dr["ID"]);
                en.TypeName = Convert.ToString(dr["TypeName"]);
                en.ParentID = Convert.ToInt32(dr["ParentID"]);
                return en;
            }
            else
            { return null; }

        }

        public static EquiptmentEN SearchEquipByID(int ID)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.AppendLine("select e.*, t.ID as TypeID, t.TypeName");
            Sql.AppendLine("from " + tb_name_master + " e ");
            Sql.AppendLine("inner join " + tb_name_type + " t on e.Equip_type_id = t.ID");
            Sql.AppendLine("");

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = Sql.ToString();

            DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
            EquiptmentEN en = new EquiptmentEN();

            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                en.ID = Convert.ToInt32(dr["ID"]);
                en.EquipNo = Convert.ToString(dr["Number"]);
                en.Name = Convert.ToString(dr["Name"]);
                en.Fullname = Convert.ToString(dr["Fullname"]);
                en.CostBuy = Convert.ToDecimal(dr["CostBuy"]);
                en.CostRent = Convert.ToDecimal(dr["CostRent"]);
                en.BuyDate = Convert.ToDateTime(dr["BuyDate"]);
                en.Equip_type_id = Convert.ToInt32(dr["Equip_type_id"]);
                en.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
                en.ReceiptTax = Convert.ToString(dr["ReceiptTax"]);
                en.SupplierName = Convert.ToString(dr["SupplierName"]);
                en.SN = Convert.ToString(dr["SN"]);

                en.equipType = new EquipmentTypeEN();
                en.equipType.ID = Convert.ToInt32(dr["TypeID"]);
                en.equipType.TypeName = Convert.ToString(dr["TypeName"]);
                return en;
            }
            else
            { return null; }

        }

        public static ResultEN Insert_Equip(EquiptmentEN en)
        {
            // SqlCommand sqlCmd = new SqlCommand();
            // sqlCmd.CommandText = "insert into " + tb_name_type +" ()";


            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("Name", en.Name));
            fields.Add(new ClassFieldValue("Fullname", en.Fullname));
            fields.Add(new ClassFieldValue("Equip_type_id", en.Equip_type_id));
            fields.Add(new ClassFieldValue("Number", en.EquipNo));
            fields.Add(new ClassFieldValue("SN", en.SN));
            fields.Add(new ClassFieldValue("SupplierName", en.SupplierName));
            fields.Add(new ClassFieldValue("ReceiptTax", en.ReceiptTax));
            fields.Add(new ClassFieldValue("BuyDate", en.BuyDate));
            fields.Add(new ClassFieldValue("CostBuy", en.CostBuy));
            fields.Add(new ClassFieldValue("CostRent", en.CostRent));
            fields.Add(new ClassFieldValue("ExpireDate", en.ExpireDate));

            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            ResultEN res = new ResultEN();

            res = ClassMain.Insert(tb_name_master, fields);


            return res;
        }

        public static ResultEN Update_Equip(EquiptmentEN en)
        {
            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("Name", en.Name));
            fields.Add(new ClassFieldValue("Fullname", en.Fullname));
            fields.Add(new ClassFieldValue("Equip_type_id", en.Equip_type_id));
            fields.Add(new ClassFieldValue("Number", en.EquipNo));
            fields.Add(new ClassFieldValue("SN", en.SN));
            fields.Add(new ClassFieldValue("SupplierName", en.SupplierName));
            fields.Add(new ClassFieldValue("ReceiptTax", en.ReceiptTax));
            fields.Add(new ClassFieldValue("BuyDate", en.BuyDate));
            fields.Add(new ClassFieldValue("CostBuy", en.CostBuy));
            fields.Add(new ClassFieldValue("CostRent", en.CostRent));
            fields.Add(new ClassFieldValue("ExpireDate", en.ExpireDate));

            fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
            ResultEN res = new ResultEN();

            List<ClassFieldValue> fieldWhere = new List<ClassFieldValue>();
            fieldWhere.Add(new ClassFieldValue("ID", en.ID));
            res = ClassMain.Update(tb_name_master, fields, fieldWhere);

            return res;
        }

        public static ResultEN Delete_Type(EquiptmentEN en)
        {
            ResultEN res = new ResultEN();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "Delete From " + tb_name_master + " WHERE ID = " + en.ID;
            sqlCmd.CommandType = CommandType.Text;

            res.result = ClassMain.ExecuteComand(sqlCmd);

            return res;
        }
    }


}