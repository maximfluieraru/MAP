using System;

namespace Common.DataTransferObject
{
    
    public class Site
    {
        public UInt32 sit_id { get; set; }
        public String sit_name { get; set; }
        public String sit_tel { get; set; }
        public String sit_adr_no { get; set; }
        public String sit_adr_street { get; set; }
        public String sit_adr_city { get; set; }
        public String sit_adr_prov { get; set; }
        public String sit_adr_pcode { get; set; }
    }
}
