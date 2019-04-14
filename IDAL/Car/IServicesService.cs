using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace IDAL.Car
{
    public interface IServicesService
    {
        IList<Services> getAllService(string statime, string endtime, string carType, string s_FactoryName);
        int addService(Services se);
        int updateService(Services se);
        Services getServiceById(int s_Id);
        int deleteServiceById(int s_Id);
        IList<Services> getFactoryName();
        IList<Car_Cars> getCarsByType();
    }
}
