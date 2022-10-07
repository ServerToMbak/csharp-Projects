﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DatAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
          return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed); 
        }

        //select * from Categories where category = 3 
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));
        }
    }
}
