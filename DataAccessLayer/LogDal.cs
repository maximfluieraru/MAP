using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class LogDal
    {

        public static Log Load(UInt32 log_id)
        {
            return HelperDal<Log>.Load("SELECT * FROM log WHERE inv_id=" + log_id);
        }

        public static List<Log> LoadAll()
        {
            return HelperDal<Log>.LoadAll("SELECT * FROM log");
        }

        public static bool Update(Log log)
        {
            return HelperDal<Log>.Update(log, "SELECT * FROM log WHERE inv_id=" + log.log_id);
        }

        public static UInt32 Insert(Log log)
        {
            return HelperDal<Log>.Insert(log, "SELECT * FROM log WHERE log_id=0");
        }

        public static void Delete(UInt32 log_id)
        {
            HelperDal<Log>.Delete("DELETE FROM log WHERE log_id=" + log_id);
        }

    }

}
