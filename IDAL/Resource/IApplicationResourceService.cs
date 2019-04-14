
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL.Resource
{
    public interface IApplicationResourseService : IBaseFace
    {
        int Delete(int type, int arid, int riid);

        object Get(int type, int arid, int riid);

        IList<ApplicationResourseInfo> Search(ApplicationResourseInfo item);

        IList<ApplicationResourseInfo> SearchByResourceNameAndBorrowType(string resourceName, int borrowType);
    }
}
