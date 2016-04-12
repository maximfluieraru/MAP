using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class SiteSupplierDal
    {

        public static SiteSupplier Load(UInt32 sit_id, UInt32 sup_id)
        {
            return HelperDal<SiteSupplier>.Load("SELECT * FROM site_supplier WHERE sit_id=" + sit_id + " AND sup_id=" + sup_id);
        }

        public static List<SiteSupplier> LoadAll()
        {
            return HelperDal<SiteSupplier>.LoadAll("SELECT * FROM site_supplier");
        }

        public static List<SiteSupplier> LoadAll(UInt32 sit_id)
        {
            return HelperDal<SiteSupplier>.LoadAll("SELECT * FROM site_supplier WHERE sit_id=" + sit_id);
        }

        public static UInt32 Insert(SiteSupplier ssu)
        {
            return HelperDal<SiteSupplier>.Insert(ssu, "SELECT * FROM site_supplier WHERE sit_id=0 AND sup_id=0");
        }

        public static void Delete(UInt32 sit_id)
        {
            HelperDal<SiteSupplier>.Delete("DELETE FROM site_supplier WHERE sit_id=" + sit_id);
        }

        public static void Delete(UInt32 sit_id, UInt32 sup_id)
        {
            HelperDal<SiteSupplier>.Delete("DELETE FROM site_supplier WHERE sit_id=" + sit_id + " AND sup_id=" + sup_id);
        }

    }

}
