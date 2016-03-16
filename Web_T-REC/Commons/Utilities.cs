using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    public Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static object Readfield(DataRow dr, string columname, object defaultValue)
    {
        //if (dr[columnName] == null)
        //{
        //    return defaultValue;
        //}

        //if (vals.GetType() == typeof(string))
        //{
        //    if (vals == null)
        //        defaultValue = "";
        //}
        //return defaultValue;

        if (dr["" + columname + ""] == DBNull.Value)
        {
            if (defaultValue == null) return null;

            if (defaultValue.GetType() == typeof(string))
            {
                return (string)defaultValue;
            }

            if (defaultValue.GetType() == typeof(Int32))
            { return (int)defaultValue; }

        }
        return dr["" + columname + ""];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strDate"></param>
    /// <returns></returns>
    /// <remark>DB Format >>  25470209 ,15/07/2557 convert to 15 กรกฏาคม 2547</remark>
    public static string FormatStringToLongDateTH(string strDate)
    {
        // DB Format >>  25470209 ,15/07/2557 convert to 15 กรกฏาคม 2547
        string[] str = strDate.Split('/');
        //string[] splitString = input.split(',');
        if (str.Length == 3)
        {
            //CultureInfo ci = new CultureInfo("en-US");
            CultureInfo ci = new CultureInfo("th-TH");
            //var month = DateTime.Now.ToString("MMMM", ci);
            int Y;
            int D;
            int M;

            D = Convert.ToInt16(str[0]);
            M = Convert.ToInt16(str[1]);
            Y = Convert.ToInt16(str[2]);
            DateTime _date = new DateTime(Y, M, D);
            var month = _date.ToString("MMMM", ci);

            // alternatively you can use CultureInfo.InvariantCulture:
            //var month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            return D.ToString() + " " + month + " " + Y.ToString();

        }
        return "";
    }

    public static string FormatStringToDBDate(DateTime datevalue)
    {
        CultureInfo ci = new CultureInfo("th-TH");
        //DB Format >>  25470209
        string strYear = datevalue.Year.ToString();
        if (datevalue.Year < 2500)
        { strYear = datevalue.AddYears(543).Year.ToString(); }

        string str = strYear + datevalue.Month.ToString("00", ci) + datevalue.Day.ToString("00", ci);

        return str;
    }

    public static string FormatStringDDMMYYY(DateTime datevalue)
    {
        CultureInfo ci = new CultureInfo("en-US");
        //>> 01/10/2015

        string strd = "";
        if (datevalue != DateTime.MinValue)
        {
            strd = datevalue.ToString("dd/MM/yyyy", ci);
        }
        return strd;
    }
    public static DateTime SetCarlendarFromDBDate(string strDate)
    {
        //2556/07/15

        DateTime _date;
        int Y;
        int D;
        int M;
        string[] str = strDate.Split('/');
        if (str.Length == 3)
        {
            Y = Convert.ToInt16(str[0]);
            if (Y > 2500) { Y = Y - 543; }

            M = Convert.ToInt16(str[1]);
            D = Convert.ToInt16(str[2]);

            _date = new DateTime(Y, M, D);
            return _date;
        }

        return DateTime.MinValue;
    }


    public static string SetMMDDYYYYToDBDate(string strDate)
    {
        // input 15/07/2015 to 25580715

        string _date = "";
        int Y;
        int D;
        int M;
        string[] str = strDate.Split('/');
        if (str.Length == 3)
        {
            Y = Convert.ToInt16(str[2]);
            if (Y < 2500) { Y = Y + 543; }

            M = Convert.ToInt16(str[1]);
            D = Convert.ToInt16(str[0]);

            _date = Y.ToString() + M.ToString("00") + D.ToString("00");
            return _date;
        }

        return _date;
    }

    public static string FormatShortThaiFromDBDate(string strDate)
    {
        //2556/07/15 to 15 ก.ค. 2556
        CultureInfo ci = new CultureInfo("th-TH");
        //DateTime _date;
        int Y;
        int D;
        int M;
        string[] str = strDate.Split('/');
        if (str.Length == 3)
        {
            Y = Convert.ToInt16(str[0]);
            //if (Y > 2500) { Y = Y - 543; }

            M = Convert.ToInt16(str[1]);
            D = Convert.ToInt16(str[2]);

            // _date = new DateTime(Y, M, D);

            string newstrDate = "";
            newstrDate = D.ToString() + " " + Enumeration.GetShortMonthNameTh(M) + " " + Y.ToString();
            return newstrDate;
            //return _date;
        }

        return "";
    }

    public static DateTime ConvertoDate(string strDate)
    {
        // 03/11/2015

        int Y;
        int D;
        int M;
        DateTime _date;
        string[] str = strDate.Split('/');
        if (str.Length == 3)
        {
            D = Convert.ToInt16(str[0]);
            M = Convert.ToInt16(str[1]);
            Y = Convert.ToInt16(str[2]);

            _date = new DateTime(Y, M, D);
            return _date;
        }

        return DateTime.MinValue;
    }

    public static Decimal ConvertToDecimal(object obj)
    {
        Type objtype = obj.GetType();
        switch (Type.GetTypeCode(objtype))
        {
            case TypeCode.String:
                if (Convert.ToString(obj) != "")
                {
                    return Convert.ToDecimal(obj);
                }
                break;


            case TypeCode.Decimal:
                return Convert.ToDecimal(obj);

                break;

            default:
                break;
        }
        return 0;
    }

    public static object SetDBNull(object obj)
    {

        Type objtype = obj.GetType();
        switch (Type.GetTypeCode(objtype))
        {
            case TypeCode.String:
                if (Convert.ToString(obj) != "")
                {
                    return Convert.ToString(obj);
                }
                break;


            case TypeCode.DateTime:
                if (Convert.ToDateTime(obj) != DateTime.MinValue)
                {
                    return obj;
                }

                break;

            default:
                break;
        }
        return null;
    }

    public static object SetDefaultValue(object obj, object returnVal)
    {
        Type objtype = obj.GetType();
        switch (Type.GetTypeCode(objtype))
        {
            case TypeCode.DateTime:
                if (Convert.ToDateTime(obj) != DateTime.MinValue)
                {
                    return obj;
                }

                break;

            default:
                if (Type.GetTypeCode(objtype) == TypeCode.DBNull)
                {
                    return returnVal;
                }

                break;
        }

        return null;
    }
}