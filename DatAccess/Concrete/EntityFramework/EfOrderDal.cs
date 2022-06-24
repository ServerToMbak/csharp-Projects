﻿using Core.DataAccess.EntityFramework;
using DatAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Concrete.EntityFramework
{
    public class EfOrderDal:EfEntityRepositoryBase<Order, NorthwindContext>,IOrderDal
    {
    }
}       
