using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{
    
    public static class SiteDal
    {

        public static Site Load(UInt32 sit_id)
        {
            return HelperDal<Site>.Load("SELECT * FROM site WHERE sit_id=" + sit_id);
        }

        public static List<Site> LoadAll()
        {
            return HelperDal<Site>.LoadAll("SELECT * FROM site");
        }

        public static bool Update(Site sit)
        {
            return HelperDal<Site>.Update(sit, "SELECT * FROM site WHERE sit_id=" + sit.sit_id);
        }

        public static UInt32 Insert(Site sit)
        {
            return HelperDal<Site>.Insert(sit, "SELECT * FROM site WHERE sit_id=0");
        }

        public static void Delete(UInt32 sit_id)
        {
            HelperDal<Site>.Delete("DELETE FROM site WHERE sit_id=" + sit_id);
        }

    }

}
