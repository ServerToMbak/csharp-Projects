﻿using Business.Concrete;
using DatAccess.Concrete.EntityFramework;
using DatAccess.Concrete.InMemory;
namespace ConsoleUI
    // Note: actual namespace depends on the project name.
{
     class Program
    {
        public static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProdutDetails())
            {
                Console.WriteLine(product.ProductName+"/"+product.CategotyName);
            }
        }

        
        
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}