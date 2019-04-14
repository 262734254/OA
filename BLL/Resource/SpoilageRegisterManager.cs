using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using OAFactory;
using Model;

namespace BLL.Resource
{
    public class SpoilageRegisterManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ISpoilageRegisterService srs = factory.CreateSpoilageRegisterService();

        public static int Add(SpoilageRegister item)
        {
            return srs.Add(item);
        }
    }
}
