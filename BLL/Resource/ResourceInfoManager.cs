using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using OAFactory;
using IDAL.Resource;

namespace BLL.Resource
{
    public class ResourceInfoManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IResourceInfoService ris = factory.CreateResourceInfoService();

        public static int Add(ResourceInfo item)
        {
            return ris.Add(item);
        }

        public static ResourceInfo GetResourceInfoByRTIDAndName(string name, int typeid)
        {

            ResourceInfo item = new ResourceInfo(0, name, new ResourceType(typeid, "", ""), new ResourceStore(), new ProviderInfo(), 0, 0, "", "", 0, "");
            if (ris.GetAllResourceInfo(item).Count == 0)
            {
                return null;
            }
            return ris.GetAllResourceInfo(item)[0];
        }

        public static int UpdateResourceInfo(ResourceInfo item)
        {
            return ris.Update(item);
        }

        public static IList<ResourceInfo> GetAllResourceInfo(string name, int typeid, int state)
        {
            ResourceInfo item = new ResourceInfo(0, name, new ResourceType(typeid, "", ""), new ResourceStore(), new ProviderInfo(), 0, 0, "", "", state, "");
            return ris.GetAllResourceInfo(item);
        }

        public static IList<ResourceInfo> GetAllResourceInfo()
        {
            ResourceInfo item = new ResourceInfo();
            return ris.GetAllResourceInfo(item);
        }

        public static int Delete(int id)
        {
            return ris.Delete(id);
        }

        public static ResourceInfo Get(int id)
        {
            return (ResourceInfo)ris.Get(id);
        }

        public static IList<ResourceInfo> GetAllResourceInfo(int typeid)
        {
            ResourceInfo item = new ResourceInfo(0, "", new ResourceType(typeid, "", ""), new ResourceStore(), new ProviderInfo(), 0, 0, "", "", 0, "");
            return ris.GetAllResourceInfo(item);
        }

        public static IList<ResourceInfo> GetAllResourceById(int id)
        {
            ResourceInfo item = new ResourceInfo(id, "", new ResourceType(0, "", ""), new ResourceStore(), new ProviderInfo(), 0, 0, "", "", 0, "");
            return ris.GetAllResourceInfo(item);
        }

    }
}
