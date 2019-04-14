
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL.Resource
{
    public interface IResourceInfoService : IBaseFace
    {
        IList<ResourceInfo> GetAllResourceInfo(ResourceInfo item);
    }
}
