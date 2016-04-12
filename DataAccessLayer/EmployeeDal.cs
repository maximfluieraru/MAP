using System;
using System.Collections.Generic;
using Common.DataTransferObject;

namespace DataAccessLayer
{

    public static class EmployeeDal
    {

        public static Employee Load(UInt32 emp_id)
        {
            return HelperDal<Employee>.Load("SELECT * FROM employee WHERE emp_id=" + emp_id);
        }

        public static Employee Load(String emp_login)
        {
            return HelperDal<Employee>.Load("SELECT * FROM employee WHERE emp_login='" + emp_login + "'");
        }

        public static List<Employee> LoadAll()
        {
            return HelperDal<Employee>.LoadAll("SELECT * FROM employee");
        }

        public static List<Employee> LoadAll(UInt32 sit_id)
        {
            return HelperDal<Employee>.LoadAll("SELECT * FROM employee WHERE sit_id=" + sit_id);
        }

        public static bool Update(Employee emp)
        {
            return HelperDal<Employee>.Update(emp, "SELECT * FROM employee WHERE emp_id=" + emp.emp_id);
        }

        public static UInt32 Insert(Employee emp)
        {
            return HelperDal<Employee>.Insert(emp, "SELECT * FROM employee WHERE emp_id=0");
        }

        public static void Delete(UInt32 emp_id)
        {
            HelperDal<Employee>.Delete("DELETE FROM employee WHERE emp_id=" + emp_id);
        }

    }

}
