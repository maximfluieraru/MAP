using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class PorderDetailDal
    {

        public static PorderDetail Load(UInt32 pom_id, UInt32 prd_id)
        {
            return HelperDal<PorderDetail>.Load("SELECT * FROM porder_detail WHERE pom_id=" + pom_id + " AND prd_id=" + prd_id);
        }

        public static List<PorderDetail> LoadAll()
        {
            return HelperDal<PorderDetail>.LoadAll("SELECT * FROM porder_detail");
        }

        public static List<PorderDetail> LoadAll(UInt32 pom_id)
        {
            return HelperDal<PorderDetail>.LoadAll("SELECT * FROM porder_detail WHERE pom_id=" + pom_id);
        }

        public static bool Update(PorderDetail pod)
        {
            return HelperDal<PorderDetail>.Update(pod, "SELECT * FROM porder_detail WHERE pom_id=" + pod.pom_id + " AND prd_id=" + pod.prd_id);
        }

        public static UInt32 Insert(PorderDetail pod)
        {
            return HelperDal<PorderDetail>.Insert(pod, "SELECT * FROM porder_detail WHERE pom_id=0 AND prd_id=0");
        }

        public static void Delete(UInt32 pom_id)
        {
            HelperDal<PorderDetail>.Delete("DELETE FROM porder_detail WHERE pom_id=" + pom_id);
        }

        public static void Delete(UInt32 pom_id, UInt32 prd_id)
        {
            HelperDal<PorderDetail>.Delete("DELETE FROM porder_detail WHERE pom_id=" + pom_id + " AND prd_id=" + prd_id);
        }

    }

}
