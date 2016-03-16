using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enumeration
/// </summary>
public class Enumeration
{
    public Enumeration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum ObjectStutus
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        NoEvent = 4

    }

    //public enum MonthNameTH
    //{ 
    //  1 = "มกราคม",
    //  2 = "กุมภาพันธ์"
    //}

    public enum ShortThaiMonth
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }

    public static string GetShortMonthNameTh(int val)
    {
        string name = "";
        switch (val)
        {
            case (int)ShortThaiMonth.Jan:
                name= "ม.ค.";
                break;
            case (int)ShortThaiMonth.Feb:
                name ="ก.พ.";
                break;
            case (int)ShortThaiMonth.Mar:
                name = "มี.ค.";
                break;
            case (int)ShortThaiMonth.Apr:
                name = "เม.ย.";
                break;
            case (int)ShortThaiMonth.May:
                name = "พ.ค.";
                break;
            case (int)ShortThaiMonth.Jun:
                name = "มิ.ย.";
                break;
            case (int)ShortThaiMonth.Jul:
                name = "ก.ค.";
                break;
            case (int)ShortThaiMonth.Aug:
                name = "ส.ค.";
                break;
            case (int)ShortThaiMonth.Sep:
                name = "ก.ย.";
                break;
            case (int)ShortThaiMonth.Oct:
                name = "ต.ค.";
                break;
            case (int)ShortThaiMonth.Nov:
                name = "พ.ย.";
                break;
            case (int)ShortThaiMonth.Dec:
                name = "ธ.ค.";
                break;
        }
        return name;
    }

    public static string GetLongMonthNameTh(int val)
    {
        string name = "";
        switch (val)
        {
            case (int)ShortThaiMonth.Jan:
                name = "มกราคม";
                break;
            case (int)ShortThaiMonth.Feb:
                name = "กุมภาพันธ์";
                break;
            case (int)ShortThaiMonth.Mar:
                name = "มีนาคม";
                break;
            case (int)ShortThaiMonth.Apr:
                name = "เมษายน";
                break;
            case (int)ShortThaiMonth.May:
                name = "พฤษภาคม";
                break;
            case (int)ShortThaiMonth.Jun:
                name = "มิถุนายน";
                break;
            case (int)ShortThaiMonth.Jul:
                name = "กรกฎาคม";
                break;
            case (int)ShortThaiMonth.Aug:
                name = "สิงหาคม";
                break;
            case (int)ShortThaiMonth.Sep:
                name = "กันยายน";
                break;
            case (int)ShortThaiMonth.Oct:
                name = "ตุลาคม";
                break;
            case (int)ShortThaiMonth.Nov:
                name = "พฤศจิกายน";
                break;
            case (int)ShortThaiMonth.Dec:
                name = "ธันวาคม";
                break;
        }
        return name;
    }
}