using System;

namespace Common.DataTransferObject
{
    public class Porder
    {
        public UInt32 pom_id { get; set; }
        public UInt32 sit_id { get; set; }
        public UInt32 emp_id { get; set; }
        public UInt32 inv_id { get; set; }
        public UInt32 dlm_id { get; set; }
        public UInt32 sup_id { get; set; }
        public String pom_datetime { get; set; }
        public String pom_desc { get; set; }
    }
}
