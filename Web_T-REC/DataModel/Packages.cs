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
    
    public partial class Packages
    {
        public int Pack_Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Pack_Set_ID { get; set; }
        public Nullable<int> Pack_Equip_Id { get; set; }
    
        public virtual Package_Equip Package_Equip { get; set; }
        public virtual Package_Set Package_Set { get; set; }
    }
}
