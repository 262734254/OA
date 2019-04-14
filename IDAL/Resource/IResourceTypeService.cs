
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL.Resource
{
    public interface IResourceTypeService:IBaseFace
    {
        IList<ResourceType> GetAllResourceType(ResourceType item);
    }
}
