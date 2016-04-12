using System;
using System.Collections.Generic;
using Common.DataTransferObject;
using Common.Exceptions;
using DataAccessLayer;

namespace BusinessLogicLayer.RoleAdmin
{

    public class SiteBll
    {

        public static List<Site> LoadAllSite()
        {
            return SiteDal.LoadAll();
        }

        public static void UpdateSite(Site sit)
        {
            SiteDal.Update(sit);
        }

        public static UInt32 InsertSite(Site sit)
        {
            return SiteDal.Insert(sit);
        }

        public static void DeleteSite(UInt32 sit_id)
        {
            SiteDal.Delete(sit_id);
        }

    }

}
