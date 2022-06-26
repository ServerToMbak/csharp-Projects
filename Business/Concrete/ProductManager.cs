using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DatAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //BUSİNESS CODES    
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInValid); 
            }
           _productDal.Add(product);
           return new SuccessResult(Messages.ProductAdded);  
        }

        public IDataResult<List<Product>> getAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }
           return  new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler Listelendi");                                                                                                 
        }

        public IDataResult<List<Product>> GetAllByCateoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryID == id);
        }

        public Product GetById(int productid)
        {
            return _productDal.Get(p => p.ProductID == productid) ;
        }

        public IDataResult< List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public IDataResult<List<ProductDetailDto>> GetProdutDetails()
        {
            return _productDal.GetProdutDetails();
        }
    }   
}
