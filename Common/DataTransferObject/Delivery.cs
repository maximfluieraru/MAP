using System;

namespace Common.DataTransferObject
{
    public class Delivery
    {
        public UInt32 dlm_id { get; set; }
        public Decimal dlm_cost { get; set; }
        public String dlm_date { get; set; }
        public String dlm_rec_date { get; set; }
    }
}
