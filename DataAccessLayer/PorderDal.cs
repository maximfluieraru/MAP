using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class PorderDal
    {

        public static Porder Load(String pom_id)
        {
            return HelperDal<Porder>.Load("SELECT * FROM porder WHERE pom_id=" + pom_id);
        }

        public static List<Porder> LoadAll()
        {
            return HelperDal<Porder>.LoadAll("SELECT * FROM porder");
        }

        public static List<Porder> LoadAll(UInt32 sit_id)
        {
            return HelperDal<Porder>.LoadAll("SELECT * FROM porder WHERE sit_id=" + sit_id);
        }

        public static bool Update(Porder pom)
        {
            return HelperDal<Porder>.Update(pom, "SELECT * FROM porder WHERE pom_id=" + pom.pom_id);
        }

        public static UInt32 Insert(Porder pom)
        {
            return HelperDal<Porder>.Insert(pom, "SELECT * FROM porder WHERE pom_id=0");
        }

        public static void Delete(String pom_id)
        {
            HelperDal<Porder>.Delete("DELETE FROM porder WHERE pom_id=" + pom_id);
        }

    }

}
