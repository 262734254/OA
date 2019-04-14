using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using OAFactory;
using Model;
using IDAL.Car;
namespace BLL.Resource
{
    public class StockApplicationManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IStockApplicationService sas = factory.CreateStockApplicationService();

        public static int Add(StockApplication item)
        {
            return sas.Add(item);
        }

        public static IList<StockApplication> SearchStockApplication(int said,string time,int uid)
        {
            StockApplication item=new StockApplication();
            item.User.UID=uid;
            item.SAID=said;
            item.SATime=time;
            return sas.Search(item);
        }

        public static int DeleteById(int id)
        {
            return sas.Delete(id);
        }

        public static StockApplication Get(int id)
        {
            return (StockApplication)sas.Get(id);
        }

        public static int Update(StockApplication item)
        {
            return sas.Update(item);
        }
    }
}
