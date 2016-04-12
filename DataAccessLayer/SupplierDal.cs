using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class SupplierDal
    {

        public static Supplier Load(UInt32 sup_id)
        {
            return HelperDal<Supplier>.Load("SELECT * FROM supplier WHERE sup_id=" + sup_id);
        }

        public static List<Supplier> LoadAll()
        {
            return HelperDal<Supplier>.LoadAll("SELECT * FROM supplier");
        }

        public static List<Supplier> LoadAll(UInt32 sit_id)
        {
            return HelperDal<Supplier>.LoadAll("SELECT * FROM supplier where ");
        }

        public static bool Update(Supplier sup)
        {
            return HelperDal<Supplier>.Update(sup, "SELECT * FROM supplier WHERE sup_id=" + sup.sup_id);
        }

        public static UInt32 Insert(Supplier sup)
        {
            return HelperDal<Supplier>.Insert(sup, "SELECT * FROM supplier WHERE sup_id=0");
        }

        public static void Delete(UInt32 sup_id)
        {
            HelperDal<Supplier>.Delete("DELETE FROM supplier WHERE sup_id=" + sup_id);
        }

    }

}
