using System;

namespace Common.DataTransferObject
{
    public class Product
    {
        public UInt32 prd_id { get; set; }
        public UInt32 sup_id { get; set; }
        public String prd_sup_no { get; set; }
        public String prd_name { get; set; }
        public Decimal prd_price { get; set; }
        public String prd_memo { get; set; }
    }
}
