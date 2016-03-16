using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Web_T_REC.Entities;

namespace Web_T_REC.Classes
{
    public class ClassJopPosition
    {
        const string tb_name = "JobPosition";
        const string tb_name_dept = "Department";
        const string tb_name_jopEmp = "JobPosition_Emp";
        public static DataTable LoadData()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "select * from " + tb_name + " order by Position";

            DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
            return dt;
        }


        public static DataTable LoadDept()
        {
            string sql = "Select * from " + tb_name_dept + " Order by Name";
            DataTable dt = ClassMain.ExecuteComandTable(sql);
            return dt;
        }


        public static JobPositionEN SearchByPosid(int id)
        {
            string sql = "Select * from " + tb_name + " Where id = " + id.ToString();
            DataTable dt = ClassMain.ExecuteComandTable(sql);
            JobPositionEN en = new JobPositionEN();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                en.id = Convert.ToInt32(dr["ID"]);
                en.position = Convert.ToString(dr["position"]);
                en.cost = Convert.ToDecimal(dr["cost"]);
            }
            return en;
        }

        public static DataTable SearchPosiionByEmp(string empid)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" select je.pos_id, j.Position, je.cost ");
            sql.AppendLine("From " + tb_name_jopEmp + " je  ");
            sql.AppendLine("inner join " + tb_name + " j on j.ID = je.pos_id");
            sql.AppendLine("where  je.Emp_id ='" + empid + "'");
            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            return dt;
        }

        public static ResultEN InsertPosition_Emp(JobPosition_EmpEN en)
        {
            ResultEN res = new ResultEN();

            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("Emp_id", en.empid));
            fields.Add(new ClassFieldValue("Pos_id", en.posid));
            fields.Add(new ClassFieldValue("cost", en.cost));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));

            res = ClassMain.Insert(tb_name_jopEmp, fields);
            return res;
        }

        public static ResultEN UpdatePosition_Emp(JobPosition_EmpEN en)
        {
            ResultEN res = new ResultEN();

            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("cost", en.cost));
            fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
            fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));

            List<ClassFieldValue> fieldscon = new List<ClassFieldValue>();
            fieldscon.Add(new ClassFieldValue("Emp_id", en.empid));
            fieldscon.Add(new ClassFieldValue("Pos_id", en.posid));

            res = ClassMain.Update(tb_name_jopEmp, fields, fieldscon);
            return res;
        }



    }
}