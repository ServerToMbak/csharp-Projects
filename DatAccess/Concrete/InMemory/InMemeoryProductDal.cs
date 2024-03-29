﻿using DatAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Concrete.InMemory
{
    public class InMemeoryProductDal : IProductDal
    {  
        List<Product> _products;
        public InMemeoryProductDal()
        {
            Console.WriteLine("in memory'de");
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryID=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryID=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryID=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryID=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryID=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            
            _products.Remove(productToDelete);
                    

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitsInStock = product.UnitsInStock; 
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {


            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProdutDetails()
        {
            throw new NotImplementedException();
        }
    }
}   
