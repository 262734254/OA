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
    public class ResourceRestoreManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IResourceRestoreService rrs = factory.CreateResourceRestoreServcie();

        public static int Add(ResourceRestore item)
        {
            return rrs.Add(item);
        }

        public static ResourceRestore GetRestoreByBAIDAndRIID(int baid, int riid)
        {
            ResourceRestore item = new ResourceRestore();
            item.Borrow.BAID = baid;
            item.Resource.RIID = riid;
            return (ResourceRestore)rrs.GetAllResourceRestore(item);
        }
    }
}
