﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL.Resource
{
    public interface IStockApplicationService:IBaseFace
    {
        IList<StockApplication> Search(StockApplication item);
    }
}