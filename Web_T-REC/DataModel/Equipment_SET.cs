//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_T_REC.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment_SET
    {
        public Equipment_SET()
        {
            this.Package_Set = new HashSet<Package_Set>();
        }
    
        public string SETName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public int SET_ID { get; set; }
    
        public virtual ICollection<Package_Set> Package_Set { get; set; }
    }
}
