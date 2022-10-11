using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentVlidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DatAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService; 
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
             
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                           CheckIfProductCountOfCategoryCorrect(product.CategoryID), 
                           CheckIfCategoryLimitExceded());

                if(result !=null)
                {
                 return result;
                }
            
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> getAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCateoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }

        public IDataResult<Product> GetById(int productid)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProdutDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProdutDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
           
            _productDal.Update(product);

            throw new NotImplementedException();
        }
        
        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryId)
        {
            //Select Count(*) from products where CategoryId=1=Aşagıdaki kodda bu linq ile bu sqp scripti oluşturulur
            var result = _productDal.GetAll(p => p.CategoryID == CategoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            //Select Count(*) from products where CategoryId=1=Aşagıdaki kodda bu linq ile bu sqp scripti oluşturulur
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult(); 
        }

    }
}
 
