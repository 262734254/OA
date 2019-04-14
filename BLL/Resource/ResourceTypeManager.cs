using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAFactory;
using IDAL.Resource;
using Model;

namespace BLL.Resource
{
    public class ResourceTypeManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IResourceTypeService rts = factory.CreateResourceTypeService();

        public static IList<ResourceType> GetAllResourceType()
        {
            ResourceType item = new ResourceType();
            return rts.GetAllResourceType(item);
        }
    }
}
