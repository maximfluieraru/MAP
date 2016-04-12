using System;

namespace Common.DataTransferObject
{
    public class Employee
    {
        public UInt32 emp_id { get; set; }
        public UInt32 sit_id { get; set; }
        public UInt32 dep_id { get; set; }
        public UInt32 rol_id { get; set; }
        public String emp_fname { get; set; }
        public String emp_lname { get; set; }
        public String emp_email { get; set; }
        public String emp_date_begin { get; set; }
        public String emp_date_end { get; set; }
        public String emp_login { get; set; }
        public String emp_pw { get; set; }
    }
}
