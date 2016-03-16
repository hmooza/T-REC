using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC.Entities
{
    public class JobPosition_EmpEN
    {

        private string _empid;
        public string empid
        {
            get { return _empid; }
            set { _empid = value; }
        }

        private int _posid;
        public int posid
        {
            get { return _posid; }
            set { _posid = value; }
        }

        private decimal _cost;
        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; }
        }


    }
}