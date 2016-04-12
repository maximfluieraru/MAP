using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class RoleDal
    {

        public static Role Load(UInt32 rol_id)
        {
            return HelperDal<Role>.Load("SELECT * FROM role WHERE rol_id=" + rol_id);
        }

        public static List<Role> LoadAll()
        {
            return HelperDal<Role>.LoadAll("SELECT * FROM role");
        }

        public static bool Update(Role rol)
        {
            return HelperDal<Role>.Update(rol, "SELECT * FROM role WHERE rol_id=" + rol.rol_id);
        }

        public static UInt32 Insert(Role rol)
        {
            return HelperDal<Role>.Insert(rol, "SELECT * FROM role WHERE rol_id=0");
        }

        public static void Delete(UInt32 rol_id)
        {
            HelperDal<Role>.Delete("DELETE FROM role WHERE rol_id=" + rol_id);
        }

    }

}
