using Business.Abstract;
using Business.Concrete;
using DatAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            
        }
    }
}
