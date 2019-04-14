using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;

namespace DAL.Car
{
  public  class CarDavnote:ICarDavnote
    {
        #region ICarDavnote 成员

        public IList<Car_Davnote> GetAllDavnote()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
