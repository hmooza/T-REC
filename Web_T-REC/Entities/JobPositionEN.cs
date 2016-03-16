using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC.Entities
{
    public class JobPositionEN
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _position;
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

       

        private decimal _cost;
        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
}