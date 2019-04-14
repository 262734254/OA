using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL.Resource;
using OAFactory;
using Model;

namespace BLL.Resource
{
    public class ProviderInfoManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IProviderInfoService pis = factory.CreateProviderInfoService();

        public static IList<ProviderInfo> GetAllProvider()
        {
            ProviderInfo item = new ProviderInfo();
            return pis.GetAllProvider(item);
        }

    }
}
