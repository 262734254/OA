
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL.Resource
{
    public interface IResourceStoreService:IBaseFace
    {
        IList<ResourceStore> GetAllResourceStore(ResourceStore item);
    }
}
