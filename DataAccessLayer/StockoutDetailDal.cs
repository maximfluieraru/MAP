using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class StockoutDetailDal
    {

        public static StockoutDetail Load(UInt32 som_id, UInt32 prd_id)
        {
            return HelperDal<StockoutDetail>.Load("SELECT * FROM stockout_detail WHERE som_id=" + som_id + " AND prd_id=" + prd_id);
        }

        public static List<StockoutDetail> LoadAll()
        {
            return HelperDal<StockoutDetail>.LoadAll("SELECT * FROM stockout_detail");
        }

        public static List<StockoutDetail> LoadAll(UInt32 som_id)
        {
            return HelperDal<StockoutDetail>.LoadAll("SELECT * FROM stockout_detail WHERE som_id=" + som_id);
        }

        public static bool Update(StockoutDetail sod)
        {
            return HelperDal<StockoutDetail>.Update(sod, "SELECT * FROM stockout_detail WHERE som_id=" + sod.som_id + " AND prd_id=" + sod.prd_id);
        }

        public static UInt32 Insert(StockoutDetail sod)
        {
            return HelperDal<StockoutDetail>.Insert(sod, "SELECT * FROM stockout_detail WHERE som_id=0 AND prd_id=0");
        }

        public static void Delete(UInt32 som_id)
        {
            HelperDal<StockoutDetail>.Delete("DELETE FROM stockout_detail WHERE som_id=" + som_id);
        }

        public static void Delete(UInt32 som_id, UInt32 prd_id)
        {
            HelperDal<StockoutDetail>.Delete("DELETE FROM stockout_detail WHERE som_id=" + som_id + " AND prd_id=" + prd_id);
        }

    }

}
