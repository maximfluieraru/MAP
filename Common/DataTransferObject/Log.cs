using System;

namespace Common.DataTransferObject
{
    public class Log
    {
        public UInt32 log_id { get; set; }
        public UInt32 emp_id { get; set; }
        public String log_datetime { get; set; }
        public String log_desc { get; set; }
    }
}
