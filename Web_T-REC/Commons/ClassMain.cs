using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


/// <summary>
/// Summary description for ClassMain
/// </summary>
/// 

public class ClassMain
{
    public ClassMain()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection ConnDB()
    {
        SqlConnection Cnn;
        Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        return Cnn;
    }

    public static Boolean ExecuteComand(SqlCommand ComSql)
    {
        bool strValue = false;
        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection ConnSave = ConnDB();
        ConnSave.Open();

        Com.CommandType = CommandType.Text;
        Com.Connection = ConnSave;
        Com.CommandTimeout = 0;

        tr = ConnSave.BeginTransaction();
        Com.Transaction = tr;



        try
        {
            Com.ExecuteNonQuery();
            tr.Commit();
            strValue = true;

        }
        catch
        {
            tr.Rollback();
            strValue = false;
        }
        finally
        {
            ConnSave.Close();
            tr.Dispose();
        }

        return strValue;
    }
    public static Boolean ExecuteQuery(string sql)
    {
        bool strValue = false;
        SqlCommand Com = new SqlCommand();
        

        SqlTransaction tr;
        SqlConnection ConnSave = ConnDB();
        ConnSave.Open();

        Com.CommandText = sql;
        Com.CommandType = CommandType.Text;
        Com.Connection = ConnSave;
        Com.CommandTimeout = 0;

        tr = ConnSave.BeginTransaction();
        Com.Transaction = tr;



        try
        {
            Com.ExecuteNonQuery();
            tr.Commit();
            strValue = true;

        }
        catch
        {
            tr.Rollback();
            strValue = false;
        }
        finally
        {
            ConnSave.Close();
            tr.Dispose();
        }

        return strValue;
    }

    public static DataTable ExecuteComandTable(string sql)
    {

        DataTable DT = new DataTable();
        SqlDataReader Dr;
        SqlCommand Com = new SqlCommand();
      
        SqlConnection Conn = ConnDB();
        Conn.Open();

        Com.CommandText = sql;
        Com.CommandType = CommandType.Text;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;


        try
        {
            Dr = Com.ExecuteReader();
            DT.Load(Dr);
            Conn.Close();
           
        }
        catch
        {
            Conn.Close();
            DT = null;

        }
        finally
        {
            Conn.Close();
        }

        return DT;
    }

    public static DataTable ExecuteComandTable(SqlCommand ComSql)
    {

        DataTable DT = new DataTable();
        SqlDataReader Dr;
        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection Conn = ConnDB();
        Conn.Open();

        Com.CommandType = CommandType.Text;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;

        tr = Conn.BeginTransaction();
        Com.Transaction = tr;


        try
        {
            Dr = Com.ExecuteReader();
            DT.Load(Dr);
            tr.Commit();
            Conn.Close();
            tr.Dispose();
        }
        catch
        {
            tr.Rollback();
            Conn.Close();
            DT = null;

        }
        finally
        {
            Conn.Close();
            tr.Dispose();

        }

        return DT;
    }

    public static SqlConnection GetConn()
    {
        SqlConnection Conn = ConnDB();
        return Conn;
    }


    public static bool ExecuteComand(SqlCommand ComSql, Boolean isTransaction)
    {
        //SqlCommand Com = new SqlCommand();
        //Com = ComSql;
        SqlConnection Conn = ConnDB();
        Conn.Open();
        if (ComSql.Connection == null)
        {
            ComSql.Connection = Conn;
        }

        Int32 intValue = 0;
        //intValue = Convert.ToInt32(ComSql.ExecuteScalar());

        intValue = Convert.ToInt32(ComSql.ExecuteNonQuery());
        if (intValue > 0)
        { return true; }
        else { return false; }

    }

    public static DataTable ExecuteComandTableStored(SqlCommand ComSql)
    {

        DataTable DT = new DataTable();
        SqlDataReader Dr;
        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection Conn = ConnDB();
        Conn.Open();

        Com.CommandType = CommandType.StoredProcedure;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;

        tr = Conn.BeginTransaction();
        Com.Transaction = tr;


        try
        {
            Dr = Com.ExecuteReader();
            DT.Load(Dr);
            // tr.Commit();
            Conn.Close();
            tr.Dispose();
        }
        catch
        {
            tr.Rollback();
            Conn.Close();
            DT = null;
        }
        finally
        {
            Conn.Close();
            tr.Dispose();
        }

        return DT;
    }

    public static Int32 intExecuteComand(SqlCommand ComSql)
    {
        Int32 intValue = 0;

        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection Conn = ConnDB();
        Conn.Open();

        Com.CommandType = CommandType.Text;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;

        tr = Conn.BeginTransaction();
        Com.Transaction = tr;


        try
        {
            intValue = Convert.ToInt32(Com.ExecuteScalar());

            tr.Commit();
            Conn.Close();
            tr.Dispose();
        }
        catch
        {
            intValue = 0;
            tr.Dispose();
            Conn.Close();

        }
        finally
        {
            Conn.Close();
            tr.Dispose();
        }

        return intValue;
    }

    public static String strExecuteComand(SqlCommand ComSql)
    {
        string strValue = "";

        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection Conn = ConnDB();
        Conn.Open();

        Com.CommandType = CommandType.Text;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;

        tr = Conn.BeginTransaction();
        Com.Transaction = tr;


        try
        {
            strValue = Convert.ToString(Com.ExecuteScalar());

            tr.Commit();
            Conn.Close();
            tr.Dispose();
        }
        catch
        {
            strValue = "Err.";
            tr.Dispose();
            Conn.Close();

        }
        finally
        {
            Conn.Close();
            tr.Dispose();
        }

        return strValue;
    }

    public static String strExecuteComandStored(SqlCommand ComSql)
    {
        string strValue = "";

        SqlCommand Com = new SqlCommand();
        Com = ComSql;

        SqlTransaction tr;
        SqlConnection Conn = ConnDB();
        Conn.Open();

        // Com.CommandType = CommandType.StoredProcedure;
        Com.Connection = Conn;
        Com.CommandTimeout = 0;

        tr = Conn.BeginTransaction();
        Com.Transaction = tr;


        try
        {
            strValue = Convert.ToString(Com.ExecuteScalar());

            tr.Commit();
            Conn.Close();
            tr.Dispose();
        }
        catch
        {
            strValue = "";
            tr.Dispose();
            Conn.Close();

        }
        finally
        {
            Conn.Close();
            tr.Dispose();
        }

        return strValue;
    }

    public static string getUpdateQueryString(string tablename, List<ClassFieldValue> fields, List<ClassFieldValue> conWhere, string UpdDateField)
    {
        StringBuilder sql = new StringBuilder();
        foreach (ClassFieldValue field in fields)
        {
            if (sql.ToString() != "") { sql.Append(","); }
            if (field.Value == null)
            {
                sql.AppendLine(field.FieldName + " = null");
            }
            else
            {
                Type objtype = field.Value.GetType();
                switch (Type.GetTypeCode(objtype))
                {
                    case TypeCode.String:
                        sql.AppendLine(field.FieldName + " = '" + Convert.ToString(field.Value) + "'");
                        break;

                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        sql.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                        break;

                    case TypeCode.DateTime:
                        string strDate = Convert.ToDateTime(field.Value).ToString("yyyy-MM-dd H:mm:ss");
                        //sql.AppendLine("Convert(Datetime,'"+ strDate +"',120)");
                        sql.AppendLine(field.FieldName + " = " + "Convert(Datetime,'" + strDate + "',120)");
                        break;

                    default:
                        sql.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                        break;

                }
            }
        }

        if (UpdDateField != "")
        {
            sql.AppendLine(", " + UpdDateField + "= getdate()");
        }


        StringBuilder sqlWhere = new StringBuilder();
        foreach (ClassFieldValue field in conWhere)
        {
            Type objtype = field.Value.GetType();
            if (sqlWhere.ToString() != "") { sqlWhere.Append(" and "); }

            switch (Type.GetTypeCode(objtype))
            {
                case TypeCode.String:
                    sqlWhere.AppendLine(field.FieldName + " = '" + Convert.ToString(field.Value) + "'");
                    break;

                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    sqlWhere.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                    break;
            }
        }

        string strQuery = "UPDATE " + tablename + " Set " + sql.ToString();
        if (sqlWhere.ToString() != "")
        {
            strQuery += " WHERE " + sqlWhere.ToString();
        }

        return strQuery;
    }

    public static string getUpdateQueryString(string tablename, List<ClassFieldValue> fields, List<ClassFieldValue> conWhere)
    {
        StringBuilder sql = new StringBuilder();
        foreach (ClassFieldValue field in fields)
        {
            if (sql.ToString() != "") { sql.Append(","); }
            if (field.Value == null)
            {
                sql.AppendLine(field.FieldName + " = null");
            }
            else
            {
                Type objtype = field.Value.GetType();
                switch (Type.GetTypeCode(objtype))
                {
                    case TypeCode.String:
                        sql.AppendLine(field.FieldName + " = '" + Convert.ToString(field.Value) + "'");
                        break;

                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        sql.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                        break;

                    case TypeCode.DateTime:
                        string strDate = Convert.ToDateTime(field.Value).ToString("yyyy-MM-dd H:mm:ss");
                        //sql.AppendLine("Convert(Datetime,'"+ strDate +"',120)");
                        sql.AppendLine(field.FieldName + " = " + "Convert(Datetime,'" + strDate + "',120)");
                        break;

                    default:
                        sql.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                        break;

                }
            }
        }

        StringBuilder sqlWhere = new StringBuilder();
        foreach (ClassFieldValue field in conWhere)
        {
            Type objtype = field.Value.GetType();
            if (sqlWhere.ToString() != "") { sqlWhere.Append(" and "); }

            switch (Type.GetTypeCode(objtype))
            {
                case TypeCode.String:
                    sqlWhere.AppendLine(field.FieldName + " = '" + Convert.ToString(field.Value) + "'");
                    break;

                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    sqlWhere.AppendLine(field.FieldName + " = " + Convert.ToString(field.Value));
                    break;
            }
        }

        string strQuery = "UPDATE " + tablename + " Set " + sql.ToString();
        if (sqlWhere.ToString() != "")
        {
            strQuery += " WHERE " + sqlWhere.ToString();
        }

        return strQuery;
    }


    public static string getInsertQueryString(string tablename, List<ClassFieldValue> fields, string UpdDateField)
    {
        StringBuilder sqlValue = new StringBuilder();
        StringBuilder sqlFieldname = new StringBuilder();

        foreach (ClassFieldValue field in fields)
        {
            if (sqlFieldname.ToString() != "") { sqlFieldname.Append(","); }
            sqlFieldname.Append(field.FieldName);
        }
        if (UpdDateField != "")
        {
            sqlFieldname.Append("," + UpdDateField);
        }


        foreach (ClassFieldValue field in fields)
        {
            if (sqlValue.ToString() != "") { sqlValue.Append(","); }

            if (field.Value == null)
            {
                sqlValue.AppendLine("null");
            }
            else
            {
                Type objtype = field.Value.GetType();
                switch (Type.GetTypeCode(objtype))
                {
                    case TypeCode.String:
                        sqlValue.AppendLine("'" + Convert.ToString(field.Value) + "'");
                        break;

                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        sqlValue.AppendLine(Convert.ToString(field.Value));
                        break;

                    case TypeCode.DateTime:
                        string strDate = Convert.ToDateTime(field.Value).ToString("yyyy-MM-dd H:mm:ss");
                        //DateTime.Parse(field.Value, new System.Globalization.CultureInfo("th-TH")).ToString("yyyy-MM-dd");
                        sqlValue.AppendLine("Convert(Datetime,'" + strDate + "',120)");
                        break;
                }
            }
        }

        if (UpdDateField != "")
        {
            sqlValue.AppendLine(", getdate()");
        }



        StringBuilder strQuery = new StringBuilder();
        strQuery.AppendLine("INSERT INTO " + tablename + " ( " + sqlFieldname.ToString() + ")");
        strQuery.AppendLine(" VALUES (" + sqlValue.ToString() + ")");

        return strQuery.ToString();
    }

    public static string getInsertQueryString(string tablename, List<ClassFieldValue> fields)
    {
        StringBuilder sqlValue = new StringBuilder();
        StringBuilder sqlFieldname = new StringBuilder();

        foreach (ClassFieldValue field in fields)
        {
            if (sqlFieldname.ToString() != "") { sqlFieldname.Append(","); }
            sqlFieldname.Append(field.FieldName);
        }

        foreach (ClassFieldValue field in fields)
        {
            if (sqlValue.ToString() != "") { sqlValue.Append(","); }

            if (field.Value == null)
            {
                sqlValue.AppendLine("null");
            }
            else
            {
                Type objtype = field.Value.GetType();
                switch (Type.GetTypeCode(objtype))
                {
                    case TypeCode.String:
                        sqlValue.AppendLine("'" + Convert.ToString(field.Value) + "'");
                        break;

                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Decimal:
                        sqlValue.AppendLine(Convert.ToString(field.Value));
                        break;

                    case TypeCode.DateTime:
                        if (Convert.ToDateTime(field.Value) == DateTime.MinValue)
                        {
                            sqlValue.AppendLine("Null");
                        }
                        else
                        {
                            string strDate = Convert.ToDateTime(field.Value).ToString("yyyy-MM-dd H:mm:ss");
                            //DateTime.Parse(field.Value, new System.Globalization.CultureInfo("th-TH")).ToString("yyyy-MM-dd");
                            sqlValue.AppendLine("Convert(Datetime,'" + strDate + "',120)");
                        }
                        break;

                    


                }
            }
        }

   
        StringBuilder strQuery = new StringBuilder();
        strQuery.AppendLine("INSERT INTO " + tablename + " ( " + sqlFieldname.ToString() + ")");
        strQuery.AppendLine(" VALUES (" + sqlValue.ToString() + ")");

        return strQuery.ToString();
    }

    public static ResultEN Insert(string tb_name, List<ClassFieldValue> fields)
    {
        ResultEN res = new ResultEN();
        res.result = false;

        SqlCommand sqlCom = new SqlCommand();

        SqlConnection Conn = ConnDB();
        Conn.Open();
        if (sqlCom.Connection == null)
        {
            sqlCom.Connection = Conn;
        }

        sqlCom.CommandType =CommandType.Text;
        sqlCom.CommandTimeout = 0;
        sqlCom.CommandText = getInsertQueryString(tb_name, fields);


        Int32 intValue = 0;
        try
        {
            intValue = Convert.ToInt32(sqlCom.ExecuteScalar());
            Conn.Close();
            res.result = true;
            res.returnValue = intValue;
            
        }
        catch (Exception)
        {
            intValue = -1;
            Conn.Close();
            res.result = false; 
            res.returnValue = intValue;
            throw;
            
        }
        finally
        {
            Conn.Close();
        }

        return res;
    }

    public static ResultEN Update(string tb_name, List<ClassFieldValue> fields, List<ClassFieldValue> keyVals)
    {
        ResultEN res = new ResultEN();
        res.result = false;

        SqlCommand sqlCom = new SqlCommand();

        SqlConnection Conn = ConnDB();
        Conn.Open();
        if (sqlCom.Connection == null)
        {
            sqlCom.Connection = Conn;
        }

        sqlCom.CommandType = CommandType.Text;
        sqlCom.CommandTimeout = 0;
        sqlCom.CommandText = getUpdateQueryString(tb_name, fields, keyVals);


        Int32 intValue = 0;
        try
        {
            intValue = Convert.ToInt32(sqlCom.ExecuteScalar());
            Conn.Close();
            res.result = true;
            res.returnValue = intValue;

        }
        catch (Exception)
        {
            intValue = -1;
            Conn.Close();
            res.result = false;
            res.returnValue = intValue;
            throw;

        }
        finally
        {
            Conn.Close();
        }

        return res;
    }
}