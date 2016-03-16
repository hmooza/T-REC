using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_T_REC.Entities;

namespace Web_T_REC.Entities
{
    public class EquiptmentEN : BaseEntity
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Equip_type_id;
        public int Equip_type_id
        {
            get { return _Equip_type_id; }
            set { _Equip_type_id = value; }
        }

        private EquipmentTypeEN _equipType;
        public EquipmentTypeEN equipType
        {
            get { return _equipType; }
            set { _equipType = value; }
        }



        private string _Fullname;
        public string Fullname
        {
            get { return _Fullname; }
            set { _Fullname = value; }
        }

        private string _EquipNo;
        public string EquipNo
        {
            get { return _EquipNo; }
            set { _EquipNo = value; }
        }

        private string _SN;
        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }

        private decimal _CostBuy;
        public decimal CostBuy
        {
            get { return _CostBuy; }
            set { _CostBuy = value; }
        }

        private decimal _CostRent;
        public decimal CostRent
        {
            get { return _CostRent; }
            set { _CostRent = value; }
        }

        private string _SupplierName;
        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        private DateTime _BuyDate;
        public DateTime BuyDate
        {
            get { return _BuyDate; }
            set { _BuyDate = value; }
        }

        private string _ReceiptTax;
        public string ReceiptTax
        {
            get { return _ReceiptTax; }
            set { _ReceiptTax = value; }
        }

        private DateTime _ExpireDate;
        public DateTime ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }
    }
}