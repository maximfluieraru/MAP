using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class DeliveryDetailDal
    {

        public static DeliveryDetail Load(UInt32 dlm_id, UInt32 prd_id)
        {
            return HelperDal<DeliveryDetail>.Load("SELECT * FROM delivery_detail WHERE dlm_id=" + dlm_id + " AND prd_id=" + prd_id);
        }

        public static List<DeliveryDetail> LoadAll()
        {
            return HelperDal<DeliveryDetail>.LoadAll("SELECT * FROM delivery_detail");
        }

        public static List<DeliveryDetail> LoadAll(UInt32 dlm_id)
        {
            return HelperDal<DeliveryDetail>.LoadAll("SELECT * FROM delivery_detail WHERE dlm_id=" + dlm_id);
        }

        public static bool Update(DeliveryDetail dld)
        {
            return HelperDal<DeliveryDetail>.Update(dld, "SELECT * FROM delivery_detail WHERE dlm_id=" + dld.dlm_id + " AND prd_id=" + dld.prd_id);
        }

        public static UInt32 Insert(DeliveryDetail dld)
        {
            return HelperDal<DeliveryDetail>.Insert(dld, "SELECT * FROM delivery_detail WHERE dlm_id=0 AND prd_id=0");
        }

        public static void Delete(UInt32 dlm_id)
        {
            HelperDal<DeliveryDetail>.Delete("DELETE FROM delivery_detail WHERE dlm_id=" + dlm_id);
        }

        public static void Delete(UInt32 dlm_id, UInt32 prd_id)
        {
            HelperDal<DeliveryDetail>.Delete("DELETE FROM delivery_detail WHERE dlm_id=" + dlm_id + " AND prd_id=" + prd_id);
        }

    }

}
