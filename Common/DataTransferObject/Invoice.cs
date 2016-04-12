using System;

namespace Common.DataTransferObject
{
    public class Invoice
    {
        public UInt32 inv_id { get; set; }
        public String inv_sup_no { get; set; }
        public Decimal inv_amount { get; set; }
        public String inv_date_due { get; set; }
        public String inv_date_paid { get; set; }
    }
}
