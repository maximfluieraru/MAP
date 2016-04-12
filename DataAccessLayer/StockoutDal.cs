using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class StockoutDal
    {

        public static Stockout Load(String som_id)
        {
            return HelperDal<Stockout>.Load("SELECT * FROM stockout WHERE som_id=" + som_id);
        }

        public static List<Stockout> LoadAll()
        {
            return HelperDal<Stockout>.LoadAll("SELECT * FROM stockout");
        }

        public static List<Stockout> LoadAll(UInt32 sit_id)
        {
            return HelperDal<Stockout>.LoadAll("SELECT * FROM stockout WHERE sit_id=" + sit_id);
        }

        public static bool Update(Stockout som)
        {
            return HelperDal<Stockout>.Update(som, "SELECT * FROM stockout WHERE som_id=" + som.som_id);
        }

        public static UInt32 Insert(Stockout som)
        {
            return HelperDal<Stockout>.Insert(som, "SELECT * FROM stockout WHERE som_id=0");
        }

        public static void Delete(String som_id)
        {
            HelperDal<Stockout>.Delete("DELETE FROM stockout WHERE som_id=" + som_id);
        }

    }

}
