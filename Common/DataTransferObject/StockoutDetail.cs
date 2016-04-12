using System;

namespace Common.DataTransferObject
{
    public class StockoutDetail
    {
        public UInt32 som_id { get; set; }
        public UInt32 prd_id { get; set; }
        public UInt32 sod_prd_qty { get; set; }
        public Decimal sod_prd_price { get; set; }
    }
}
