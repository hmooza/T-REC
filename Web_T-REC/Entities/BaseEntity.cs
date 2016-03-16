using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaseEntity
/// </summary>
public class BaseEntity
{
	public BaseEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private Enumeration.ObjectStutus _ObjectStatus;
    public Enumeration.ObjectStutus ObjectStatus
    {
        get { return _ObjectStatus; }
        set { _ObjectStatus = value; }
    }


    private string _CreatedBy;
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }

    }

    private DateTime _CreatedDate;
    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }

    }

    private string _UpdatedBy;
    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }

    }

    private DateTime _UpdatedDate;
    public DateTime UpdatedDate
    {
        get { return _UpdatedDate; }
        set { _UpdatedDate = value; }

    }

    
}