﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
    
    }
}
