using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class DepartmentDal
    {

        public static Department Load(UInt32 dep_id)
        {
            return HelperDal<Department>.Load("SELECT * FROM department WHERE dep_id=" + dep_id);
        }

        public static List<Department> LoadAll()
        {
            return HelperDal<Department>.LoadAll("SELECT * FROM department");
        }

        public static bool Update(Department dep)
        {
            return HelperDal<Department>.Update(dep, "SELECT * FROM department WHERE dep_id=" + dep.dep_id);
        }

        public static UInt32 Insert(Department dep)
        {
            return HelperDal<Department>.Insert(dep, "SELECT * FROM department WHERE dep_id=0");
        }

        public static void Delete(UInt32 dep_id)
        {
            HelperDal<Department>.Delete("DELETE FROM department WHERE dep_id=" + dep_id);
        }

    }

}
