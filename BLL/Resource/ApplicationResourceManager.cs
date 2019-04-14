using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using OAFactory;
using IDAL.Car;

using Model;

namespace BLL.Resource
{
    public class ApplicationResourceManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IApplicationResourseService ars = factory.CreateApplicationResourseServcie();

        public static int add(ApplicationResourseInfo item)
        {
            return ars.Add(item);
        }

        public static IList<ApplicationResourseInfo> GetAllApplicationResource(int type, int id)
        {
            ApplicationResourseInfo item = new ApplicationResourseInfo();
            item.ARType = type;
            if (type == 1)
                item.Borrow.BAID = id;
            if (type == 2)
                item.Stock.SAID = id;
            return ars.Search(item);
        }

        public static int Delete(int arid,int artype,int riid)
        {
            return ars.Delete(artype, arid, riid);
        }

        public static ApplicationResourseInfo GetApplicationResourse(int arid, int riid)
        {
            ApplicationResourseInfo item = new ApplicationResourseInfo();
            item.ARType = 1;
            item.Borrow.BAID=arid;
            item.Resource.RIID=riid;
            return (ApplicationResourseInfo)(ars.Search(item))[0];
        }

        public static IList<ApplicationResourseInfo> SearchByResourceNameAndBorrowType(string resourceName, int borrowType)
        {
            return ars.SearchByResourceNameAndBorrowType(resourceName, borrowType);
        }
    }
}
