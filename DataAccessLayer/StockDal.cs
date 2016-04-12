using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class StockDal
    {

        public static Stock Load(UInt32 sit_id, UInt32 prd_id)
        {
            return HelperDal<Stock>.Load("SELECT * FROM stock WHERE sit_id=" + sit_id + " AND prd_id=" + prd_id);
        }

        public static List<Stock> LoadAll()
        {
            return HelperDal<Stock>.LoadAll("SELECT * FROM stock");
        }

        public static List<Stock> LoadAll(UInt32 sit_id)
        {
            return HelperDal<Stock>.LoadAll("SELECT * FROM stock WHERE sit_id=" + sit_id);
        }

        public static bool Update(Stock stk)
        {
            return HelperDal<Stock>.Update(stk, "SELECT * FROM stock WHERE sit_id=" + stk.sit_id + " AND prd_id=" + stk.prd_id);
        }

        public static UInt32 Insert(Stock stk)
        {
            return HelperDal<Stock>.Insert(stk, "SELECT * FROM stock WHERE sit_id=0 AND prd=0");
        }

        public static void Delete(UInt32 sit_id)
        {
            HelperDal<Stock>.Delete("DELETE FROM stock WHERE sit_id=" + sit_id);
        }

        public static void Delete(UInt32 sit_id, UInt32 prd_id)
        {
            HelperDal<Stock>.Delete("DELETE FROM stock WHERE sit_id=" + sit_id + " AND prd_id=" + prd_id);
        }

    }

}
