using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL.Car
{
    public interface ICarDavnote
    {
        IList<Car_Davnote> GetAllDavnote();
    }
}
