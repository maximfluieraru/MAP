using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class DeliveryDal
    {

        public static Delivery Load(UInt32 dlm_id)
        {
            return HelperDal<Delivery>.Load("SELECT * FROM delivery WHERE dlm_id=" + dlm_id);
        }

        public static List<Delivery> LoadAll()
        {
            return HelperDal<Delivery>.LoadAll("SELECT * FROM delivery");
        }

        public static bool Update(Delivery dlm)
        {
            return HelperDal<Delivery>.Update(dlm, "SELECT * FROM delivery WHERE dlm_id=" + dlm.dlm_id);
        }

        public static UInt32 Insert(Delivery dlm)
        {
            return HelperDal<Delivery>.Insert(dlm, "SELECT * FROM delivery WHERE dlm_id=0");
        }

        public static void Delete(UInt32 dlm_id)
        {
            HelperDal<Delivery>.Delete("DELETE FROM delivery WHERE dlm_id=" + dlm_id);
        }

    }

}
