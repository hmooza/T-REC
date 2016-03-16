using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserEN
/// </summary>
public class UserEN
{
    public UserEN()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string _username;
    public string username
    {
        get { return _username; }
        set { _username = value; }
    }

    string _rolename;
    public string rolename
    {
        get { return _rolename; }
        set { _rolename = value; }
    }

    int _role_id;
    public int role_id
    {
        get { return _role_id; }
        set { _role_id = value; }
    }

    int _brance_id;
    public int brance_id
    {
        get { return _brance_id; }
        set { _brance_id = value; }
    }
}