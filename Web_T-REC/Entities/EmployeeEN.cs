using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC.Entities
{
    public class EmployeeEN
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Emp_id;
        public string Emp_id
        {
            get { return _Emp_id; }
            set { _Emp_id = value; }
        }

        private string _Firstname;
        public string Firstname
        {
            get { return _Firstname; }
            set { _Firstname = value; }
        }

        private string _Lastname;
        public string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }

        private string _Nickname;
        public string Nickname
        {
            get { return _Nickname; }
            set { _Nickname = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }



        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        private string _IdenNumber;
        public string IdenNumber
        {
            get { return _IdenNumber; }
            set { _IdenNumber = value; }
        }

        private string _AccNo;
        public string AccNo
        {
            get { return _AccNo; }
            set { _AccNo = value; }
        }

        private string _AccName;
        public string AccName
        {
            get { return _AccName; }
            set { _AccName = value; }
        }


        private DateTime _BirthDate;
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        private DateTime _StartWorkDate;
        public DateTime StartWorkDate
        {
            get { return _StartWorkDate; }
            set { _StartWorkDate = value; }
        }


        private DateTime _EndWorkDate;
        public DateTime EndWorkDate
        {
            get { return _EndWorkDate; }
            set { _EndWorkDate = value; }
        }


        private string _position;
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }


        private decimal _salary;
        public decimal salary
        {
            get { return _salary; }
            set { _salary = value; }
        }


        private int _DeptId;
        public int DeptId
        {
            get { return _DeptId; }
            set { _DeptId = value; }
        }
    }
}