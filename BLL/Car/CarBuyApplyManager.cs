using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;
using OAFactory;

namespace BLL.Car
{
    public class CarBuyApplyManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static ICarsService carService = factory.CreateCarService();
    }
}
