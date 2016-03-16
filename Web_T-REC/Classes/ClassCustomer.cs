using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Web_T_REC.Entities;

namespace Web_T_REC.Classes
{
    public class ClassCustomer
    {
        const string tb_name = "Customer";

        public static string GetC_ID()
        {
            string result = "";
            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select SUBSTRING(C_ID,2,4) -- CAST( right(C_ID,2)as int) as C_ID from dbo.Customer");
            sql.AppendLine("from dbo.Customer");
            sql.AppendLine("where SUBSTRING(C_ID,2,4) = '" + strY + "'");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                int YearDB = Convert.ToInt32(dt.Rows[0][0]);
                int Year = DateTime.Now.Year;
                if (YearDB != Year)
                {
                    result = "C" + strY + "01";
                }
                else
                {
                    string no = Get_EXT();
                    result = "C" + strY + no;
                }
            }
            else
            {
                result = "C" + strY + "01";
            }
            return result;
        }

        public static string Get_EXT()
        {
            //string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select SUBSTRING( MAX(C_ID),6,2) from dbo.Customer");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                int no = Convert.ToInt32(dt.Rows[0][0]);
                no += 1;
                return no.ToString("00");
            }
            return "01";
        }

        private static List<ClassFieldValue> SetField(List<ClassFieldValue> fields, CustomerEN en)
        {
            //fields.Add(new ClassFieldValue("ID", en.ID));
            fields.Add(new ClassFieldValue("C_ID", en.C_ID));
            fields.Add(new ClassFieldValue("Name", en.Name));
            fields.Add(new ClassFieldValue("Address", en.Address));
            fields.Add(new ClassFieldValue("Email", en.Email));
            fields.Add(new ClassFieldValue("EXT", en.EXT));
            fields.Add(new ClassFieldValue("Fax", en.Fax));
            fields.Add(new ClassFieldValue("Name_Company", en.Name_Company));
            fields.Add(new ClassFieldValue("Tax_Number", en.Tax_Number));
            fields.Add(new ClassFieldValue("Tel", en.Tel));
            fields.Add(new ClassFieldValue("Tel_Company", en.Tel_Company));

            //fields.Add(new ClassFieldValue("CreatedBy", en.CreatedBy));
            //fields.Add(new ClassFieldValue("UpdatedBy", en.UpdatedBy));
            //fields.Add(new ClassFieldValue("CreatedDate", Utilities.SetDBNull(en.CreatedDate)));
            //fields.Add(new ClassFieldValue("UpdatedDate", Utilities.SetDBNull(en.UpdatedDate)));

            return fields;
        }

        private static void SetData(out CustomerEN[] Objects, DataTable dt)
        {
            Objects = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                var _CustomerEN = (from a in dt.AsEnumerable()
                                   select new CustomerEN
                                   {
                                       ID = a.Field<int>("ID"),
                                       C_ID = a.Field<string>("C_ID"),
                                       Name = a.Field<string>("Name"),
                                       Address = a.Field<string>("Address"),
                                       Email = a.Field<string>("Email"),
                                       EXT = a.Field<string>("EXT") != null ? a.Field<string>("EXT") : "",
                                       Fax = a.Field<string>("Fax"),

                                       Name_Company = a.Field<string>("Name_Company"),
                                       Tax_Number = a.Field<string>("Tax_Number"),
                                       Tel = a.Field<string>("Tel"),
                                       Tel_Company = a.Field<string>("Tel_Company"),

                                       CreatedBy = a.Field<string>("CreatedBy"),
                                       UpdatedBy = a.Field<string>("UpdatedBy") != null ? a.Field<string>("UpdatedBy") : "",
                                       CreatedDate = a.Field<DateTime?>("CreatedDate") != null ? a.Field<DateTime>("CreatedDate") : DateTime.MinValue,
                                       UpdatedDate = a.Field<DateTime?>("UpdatedDate") != null ? a.Field<DateTime>("UpdatedDate") : DateTime.MinValue
                                   }).ToArray();

                if (_CustomerEN != null && _CustomerEN.Any())
                {
                    Objects = _CustomerEN;
                }
            }
        }

        public static ResultEN Insert(CustomerEN en)
        {
            ResultEN res = new ResultEN();
            // Gen Employee code
            string C_ID = GetC_ID();
            List<ClassFieldValue> fields = new List<ClassFieldValue>();

            en.C_ID = C_ID;
            //fields.Add(new ClassFieldValue("C_ID", C_ID));
            fields.Add(new ClassFieldValue("CreatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("CreatedDate", DateTime.Now));
            SetField(fields, en);

            res = ClassMain.Insert(tb_name, fields);
            return res;
        }

        public static ResultEN Update(CustomerEN en)
        {
            ResultEN res = new ResultEN();
            List<ClassFieldValue> fields = new List<ClassFieldValue>();

            fields.Add(new ClassFieldValue("UpdatedBy", HttpContext.Current.User.Identity.Name));
            fields.Add(new ClassFieldValue("UpdatedDate", DateTime.Now));
            SetField(fields, en);

            List<ClassFieldValue> fieldscon = new List<ClassFieldValue>();
            fieldscon.Add(new ClassFieldValue("C_ID", en.C_ID));

            res = ClassMain.Update(tb_name, fields, fieldscon);
            return res;
        }

        public static ResultEN Delete(string C_ID)
        {
            ResultEN res = new ResultEN();
            string sql = "DELETE From Customer Where C_ID='" + C_ID + "'";
            res.result = ClassMain.ExecuteQuery(sql);
            return res;
        }


        public static DataTable LoadData()
        {
            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select top 50 * from Customer");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            return dt;
        }

        public static void LoadData(out CustomerEN[] Objects)
        {
            Objects = null;
            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select top 50 * from Customer");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());

            SetData(out Objects, dt);
        }

        public static CustomerEN SearchEmp(string C_ID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select * from dbo.Customer");
            sql.AppendLine("where C_ID = '" + C_ID + "'");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            CustomerEN en = new CustomerEN();

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = (DataRow)dt.Rows[0];
                en.C_ID = Convert.ToString(dr["C_ID"]);
                en.Name = Convert.ToString(dr["Name"]);
                en.Tel = Convert.ToString(dr["Tel"]);
                en.Email = Convert.ToString(dr["Email"]);
                en.Fax = Convert.ToString(dr["Fax"]);
                en.Name_Company = Convert.ToString(dr["Name_Company"]);
                en.Address = Convert.ToString(dr["Address"]);
                en.Tel_Company = Convert.ToString(dr["Tel_Company"]);
                en.Tax_Number = Convert.ToString(dr["Tax_Number"]);

                en.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                en.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                en.UpdatedDate = Convert.ToDateTime(Utilities.SetDefaultValue(dr["UpdatedDate"], DateTime.MinValue));
                en.CreatedDate = Convert.ToDateTime(Utilities.SetDefaultValue(dr["CreatedDate"], DateTime.MinValue));
            }
            return en;
        }
    }
}