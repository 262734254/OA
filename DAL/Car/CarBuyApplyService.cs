using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL.Car;

namespace DAL.Car
{
   public class CarBuyApplyService:ICarBuyApplyService
    {
       
        #region ICarBuyApplyService 成员

        public IList<Car_BuyApply> GetAllBuyApply()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICarBuyApplyService 成员

        IList<Car_BuyApply> ICarBuyApplyService.GetAllBuyApply()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
