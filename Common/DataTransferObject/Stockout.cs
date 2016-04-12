using System;

namespace Common.DataTransferObject
{
    public class Stockout
    {
        public UInt32 som_id { get; set; }
        public UInt32 sit_id { get; set; }
        public UInt32 emp_id { get; set; }
        public String som_datetime { get; set; }
        public String som_lost_flag { get; set; }
        public String som_desc { get; set; }
    }
}
