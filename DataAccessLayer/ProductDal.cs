using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class ProductDal
    {

        public static Product Load(UInt32 prd_id)
        {
            return HelperDal<Product>.Load("SELECT * FROM product WHERE prd_id=" + prd_id);
        }

        public static List<Product> LoadAll()
        {
            return HelperDal<Product>.LoadAll("SELECT * FROM product");
        }

        public static List<Product> LoadAll(UInt32 sup_id)
        {
            return HelperDal<Product>.LoadAll("SELECT * FROM product WHERE sup_id=" + sup_id);
        }

        public static bool Update(Product prd)
        {
            return HelperDal<Product>.Update(prd, "SELECT * FROM product WHERE prd_id=" + prd.prd_id);
        }

        public static UInt32 Insert(Product prd)
        {
            return HelperDal<Product>.Insert(prd, "SELECT * FROM product WHERE prd_id=0");
        }

        public static void Delete(UInt32 prd_id)
        {
            HelperDal<Product>.Delete("DELETE FROM product WHERE prd_id=" + prd_id);
        }

    }

}
