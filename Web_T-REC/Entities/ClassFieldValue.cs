using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassFieldValue
/// </summary>
public class ClassFieldValue
{
    public ClassFieldValue(string fieldname, object val)
    {
        //
        // TODO: Add constructor logic here
        //
        _FieldName = fieldname;
        _Value = val;
    }


    private string _FieldName;
    public string FieldName
    {
        get { return _FieldName; }
        set { _FieldName = value; }
    }

    private object _Value;
    public object Value
    {
        get
        {
            //switch (_Value.GetType())
            //{
            //    case  typeof(string):


            //        break;
            //    case typeof(string):
            //        break;
            //}

            //if (_Value.GetType() == typeof(string))
            //{                
            //    return _Value;
            //}
            return _Value;
        }
        set { _Value = value; }
    }
}