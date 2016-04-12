using System;

namespace Common.DataTransferObject
{
    public class Supplier
    {
        public UInt32 sup_id { get; set; }
        public String sup_name { get; set; }
        public String sup_tel { get; set; }
        public String sup_adr_no { get; set; }
        public String sup_adr_street { get; set; }
        public String sup_adr_city { get; set; }
        public String sup_adr_prov { get; set; }
        public String sup_adr_pcode { get; set; }
    }
}
