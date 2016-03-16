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
    public class ClassEmployee
    {
        const string tb_name = "Employees";

        public static string GetRunno()
        {

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select ISNULL(MAX(CAST( right(Emp_id,2)as int)),0) runno from dbo.Employees");
            sql.AppendLine("where SUBSTRING(Emp_id,2,4) = '" + strY + "'");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt.Rows.Count > 0)
            {
                int no = Convert.ToInt32(dt.Rows[0][0]);
                no += 1;
                return no.ToString("00");
            }


            return "01";
        }

        private static List<ClassFieldValue> SetField(List<ClassFieldValue> fields, EmployeeEN en)
        {
            fields.Add(new ClassFieldValue("Firstname", en.Firstname));
            fields.Add(new ClassFieldValue("Lastname", en.Lastname));
            fields.Add(new ClassFieldValue("Nickname", en.Nickname));
            fields.Add(new ClassFieldValue("Address", en.Address));
            fields.Add(new ClassFieldValue("Phone", en.Phone));
            fields.Add(new ClassFieldValue("idenNumber", en.IdenNumber));
            fields.Add(new ClassFieldValue("AccNo", en.AccNo));
            fields.Add(new ClassFieldValue("AccName", en.AccName));
            fields.Add(new ClassFieldValue("StartWorkDate", Utilities.SetDBNull(en.StartWorkDate)));
            fields.Add(new ClassFieldValue("BirthDate", Utilities.SetDBNull(en.BirthDate)));
            fields.Add(new ClassFieldValue("salary", en.salary));
            fields.Add(new ClassFieldValue("Email", en.Email));
            fields.Add(new ClassFieldValue("DeptId", en.DeptId));

            return fields;
        }

        public static ResultEN Insert(EmployeeEN en)
        {
            ResultEN res = new ResultEN();

            // Gen Employee code
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            string code = "E" + DateTime.Now.Date.Year.ToString(cultureinfo);

            string runno = GetRunno();
            code += runno;

            List<ClassFieldValue> fields = new List<ClassFieldValue>();
            fields.Add(new ClassFieldValue("Emp_id", code));
            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            SetField(fields,en);


            res = ClassMain.Insert(tb_name, fields);
            return res;
        }


        public static ResultEN Update(EmployeeEN en)
        {
            ResultEN res = new ResultEN();
            List<ClassFieldValue> fields = new List<ClassFieldValue>();
           
            fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
            SetField(fields, en);

            List<ClassFieldValue> fieldscon = new List<ClassFieldValue>();
            fieldscon.Add(new ClassFieldValue("Emp_id", en.Emp_id));

            res = ClassMain.Update(tb_name, fields, fieldscon);
            return res;
        }

        public static ResultEN Delete(int id)
        {
            ResultEN res = new ResultEN();
            string sql = "DELETE From Employees Where id=" + id  ;
            res.result = ClassMain.ExecuteQuery(sql);
            return res;
        }
            

        public static DataTable LoadData()
        {

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select top 50 * from Employees");


            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());

            return dt;
        }

        public static EmployeeEN SearchEmp(int id)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select * from dbo.Employees");
            sql.AppendLine("where id = " + id );

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            EmployeeEN en = new EmployeeEN();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = (DataRow)dt.Rows[0];
                en.ID = Convert.ToInt32(dr["id"]);
                en.Emp_id = Convert.ToString(dr["Emp_id"]);
                en.AccName = Convert.ToString(dr["AccName"]);
                en.AccNo = Convert.ToString(dr["AccNo"]);
                en.Firstname = Convert.ToString(dr["Firstname"]);
                en.Lastname = Convert.ToString(dr["Lastname"]);
                en.Nickname = Convert.ToString(dr["Nickname"]);
                en.Phone = Convert.ToString(dr["Phone"]);
                en.IdenNumber = Convert.ToString(dr["IdenNumber"]);
                en.Address =  Convert.ToString(dr["Address"]);
                en.Email = Convert.ToString(dr["Email"]);

                en.salary = (Decimal)dr["salary"];

                en.BirthDate = Convert.ToDateTime(Utilities.SetDefaultValue(dr["BirthDate"], DateTime.MinValue));
                en.StartWorkDate = Convert.ToDateTime(Utilities.SetDefaultValue(dr["StartWorkDate"], DateTime.MinValue));
                en.DeptId = Convert.ToInt16(Utilities.SetDefaultValue(dr["DeptId"],0));
            }


            return en;
        }
    }
}