using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

using IDAL.Matter;
using OAFactory;
using IDAL.Power;

namespace BLL.Power
{
  public class DepartmentManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

       // private static ICarsService carService = factory.CreateCarService();
        private static IDepartmentService departmentService = factory.CreateDepartmentService();
        public static IList<Department> GetAllDepartment()
        {
            return departmentService.GetAllDepartment();
        }

        public static Department GetAllDepartementById(int id)
        {
            return departmentService.GetAllDepartementById(id);
        }

       
    }
}
