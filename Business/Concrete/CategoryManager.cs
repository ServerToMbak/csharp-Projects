using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentVlidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            IResult result= BusinessRules.Run(checkIfCategoryNameExists(category.CategoryName));

            if (result != null)
            {
                return result;
            }
           _categoryDal.Add(category);
           return new SuccessResult(Messages.CategoryAdded);
        }

        public IDataResult<List<Category>> GetAll()
        {
          return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed); 
        }

        //select * from Categories where category = 3 
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            IResult result=BusinessRules.Run(checkIfCategoryNameExists(category.CategoryName));
            if(result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccessResult();
        }

        private IResult checkIfCategoryNameExists(string CategoryName)
        {
            var result = _categoryDal.GetAll(c=>c.CategoryName==CategoryName).Any();

            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        } 
    }
}
