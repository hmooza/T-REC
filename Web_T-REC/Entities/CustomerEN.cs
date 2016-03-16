using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC.Entities
{
    public class CustomerEN
    {
        public int ID { get; set; }

        public string C_ID { get; set; }

        public string Name { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string EXT { get; set; }

        public string Name_Company { get; set; }

        public string Address { get; set; }

        public string Tax_Number { get; set; }

        public string Tel_Company { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}