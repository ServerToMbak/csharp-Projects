using Entities.Concrete;


namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> getAll();
        List<Product> GetAllByCateoryId(int id);

        List<Product> GetByUnitPrice(decimal min, decimal max);  
    }

}
