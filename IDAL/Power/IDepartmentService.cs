using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Power
{
  public interface IDepartmentService
    {
          IList<Department> GetAllDepartment();

          Department GetAllDepartementById(int id);
    }
}
