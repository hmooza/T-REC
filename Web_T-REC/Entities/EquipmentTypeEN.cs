using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC.Entities
{
    public class EquipmentTypeEN : BaseEntity
    {
        public int ID;
        public string TypeName;
        public Int32 ParentID;        
    }
}