using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using OAFactory;
using IDAL.Resource;

namespace BLL.Resource
{
    public class ResourceStoreManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IResourceStoreService rss = factory.CreateResourceStoreService();

        public static IList<ResourceStore> GetAllResourceStore()
        {
            ResourceStore item = new ResourceStore();
            return rss.GetAllResourceStore(item);
        }
    }
}
