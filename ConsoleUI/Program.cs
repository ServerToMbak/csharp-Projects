using Business.Concrete;
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
            ProductTest2();
        }

        private static void ProductTest2()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProdutDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategotyName);
                }
            }else
            {
                Console.WriteLine(result.Message);
            } 
            
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetAll();
            foreach (var category in result.Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40,100).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}