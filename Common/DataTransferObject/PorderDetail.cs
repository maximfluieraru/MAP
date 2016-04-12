using System;

namespace Common.DataTransferObject
{
    public class PorderDetail
    {
        public UInt32 pom_id { get; set; }
        public UInt32 prd_id { get; set; }
        public UInt32 pod_prd_qty { get; set; }
        public Decimal pod_prd_price { get; set; }
    }
}
