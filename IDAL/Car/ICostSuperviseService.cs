
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace IDAL.Car
{
    public interface ICostSuperviseService
    {
       IList<CostSupervise> getAllCostSupervise(string statime, string endtime, string cs_CarType, string carMark);
       int updateCostSupervise(CostSupervise cs);
       CostSupervise getCostSuperviseById(int cs_Id);
       int delCostSuperviseById(int cs_Id);
       int addCostSupervise(CostSupervise cs);
       IList<CostSupervise> getCostSupervise();
    }
}
