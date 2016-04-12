using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class InvoiceDal
    {

        public static Invoice Load(UInt32 inv_id)
        {
            return HelperDal<Invoice>.Load("SELECT * FROM invoice WHERE inv_id=" + inv_id);
        }

        public static List<Invoice> LoadAll()
        {
            return HelperDal<Invoice>.LoadAll("SELECT * FROM invoice");
        }

        public static bool Update(Invoice inv)
        {
            return HelperDal<Invoice>.Update(inv, "SELECT * FROM invoice WHERE inv_id=" + inv.inv_id);
        }

        public static UInt32 Insert(Invoice inv)
        {
            return HelperDal<Invoice>.Insert(inv, "SELECT * FROM invoice WHERE inv_id=0");
        }

        public static void Delete(UInt32 inv_id)
        {
            HelperDal<Invoice>.Delete("DELETE FROM invoice WHERE inv_id=" + inv_id);
        }

    }

}
