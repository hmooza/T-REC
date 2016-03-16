using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;



/// <summary>
/// Summary description for ClassUser
/// </summary>
public class ClassUser
{
    private static string salt = System.Configuration.ConfigurationManager.AppSettings["salt"];
    public ClassUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataTable LoadUser()
    {
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "select * from dbo.Users where username <> LOWER('system') order by Username";

        DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
        return dt;
    }

    public static DataTable LoadUser(string username)
    {
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "select * from dbo.Users where username='" + username + "' and username <> LOWER('system')";

        DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
        return dt;
    }

    public static UserEN FindUser(string username)
    {
        string sql = "select * from dbo.Users inner join Roles on Roles.id = Users.Role_ID ";
        sql += "where Username=LOWER('" + username + "')";
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = sql;

        DataTable dt = ClassMain.ExecuteComandTable(sqlCmd);
        UserEN useren = new UserEN();
        if (dt.Rows.Count > 0) 
        {
            useren.username = Convert.ToString(dt.Rows[0]["username"]);
            useren.rolename = Convert.ToString(dt.Rows[0]["rolename"]);
            useren.role_id = Convert.ToInt32(dt.Rows[0]["role_id"]);
            
        }
        return useren;
    }

    public static ResultEN CreateUser(string username, string password, int role_id, int branch_id )
    {
        ResultEN res = new ResultEN();

        username = username.Trim().ToLower();
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "select username from Users where username ='" + username + "'";

        // check duplicate username
        int count = ClassMain.intExecuteComand(sqlCmd);
        if (count > 0)
        {
            res.result = false;
            res.returnValue = "Duplicate Username";
            return res;
        }


        string strEnCrypt = SHA256.EcryptPassword(password, salt);

        StringBuilder Sql = new StringBuilder();
        Sql.AppendLine("INSERT INTO [dbo].[Users]");
        Sql.AppendLine("           ([Username]");
        Sql.AppendLine("           ,[Password]");
        Sql.AppendLine("           ,[Role_id]");
        Sql.AppendLine("           ,[CreatedDate]");
        Sql.AppendLine("           ,[CreatedBy]");  
       
        Sql.AppendLine(")");
        Sql.AppendLine("     VALUES");
        Sql.AppendLine("           ('" + username + "'");
        Sql.AppendLine("           ,'" + strEnCrypt + "'");
        Sql.AppendLine("           ,"+ role_id);
        Sql.AppendLine("           ,getdate()");         
        Sql.AppendLine("           ,'" + HttpContext.Current.User.Identity.Name + "')");

        sqlCmd = new SqlCommand();
        sqlCmd.CommandText = Sql.ToString();
        res.result = ClassMain.ExecuteComand(sqlCmd);
        if (res.result) { res.returnValue = "Create Username Success."; }

        return res;
    }

    public static string ChangePassword(string username, string password)
    {
        // EnCryptPassword
        string salt = System.Configuration.ConfigurationManager.AppSettings["salt"];
        string strEnCrypt = SHA256.EcryptPassword(password, salt);

        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "update  dbo.Users set Password = '" + strEnCrypt + "' where username =LOWER('" + username + "')";

        string res = ClassMain.strExecuteComand(sqlCmd);
        return res;
    }

    public static ResultEN ChangeUsername(int id, string username_old, string username_new, string password)
    {
        ResultEN res = new ResultEN();
        SqlCommand sqlCmd = new SqlCommand();
        username_old = username_old.Trim().ToLower();
        username_new = username_new.Trim().ToLower();
        sqlCmd.CommandText = "select username from Users where username ='" + username_new + "' and username <> '" + username_old + "'";

        // check duplicate username not self
        int count = ClassMain.intExecuteComand(sqlCmd);
        if (count > 0)
        {
            res.result = false;
            res.returnValue = "Duplicate Username";
            return res;
        }

        string strEnCrypt = SHA256.EcryptPassword(password, salt);

        sqlCmd = new SqlCommand();
        StringBuilder Sql = new StringBuilder();
        Sql.AppendLine("UPDATE [dbo].[Users]");
        Sql.AppendLine("   SET [Username] = '" + username_new + "'");
        Sql.AppendLine("      ,[Password] = '" + strEnCrypt + "'");
        Sql.AppendLine("      ,[UpdDate] = getdate()");
        Sql.AppendLine("      ,[UpdTime] = getdate()");
        Sql.AppendLine("      ,[UpdBy] = '" + HttpContext.Current.User.Identity.Name + "'");
        Sql.AppendLine(" WHERE id = " + id);
        sqlCmd.CommandText = sqlCmd.ToString();

        res.result = ClassMain.ExecuteComand(sqlCmd);
        return res;
    }

    public static string DeleteUser(string username)
    {
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "delete from  dbo.Users where username ='" + username + "'";

        string res = ClassMain.strExecuteComand(sqlCmd);
        return res;
    }


}