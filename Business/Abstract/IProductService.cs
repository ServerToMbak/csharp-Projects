﻿using Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> getAll();
        IDataResult<List<Product>> GetAllByCateoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProdutDetails();
        IDataResult<Product> GetById(int id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);


    }

}
