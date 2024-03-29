﻿using Business.Abstract;
using Business.Concrete;
using DatAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //IoC Controller -->Inversıon of Control
        IProductService _productService;
       public ProductsController(IProductService productService)
        { 
            _productService=productService;
        }
        [HttpGet("getall")]
    
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
          var result=_productService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int CategoryId)
        {
            var result = _productService.GetAllByCateoryId(CategoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getProductDetail")]
        public IActionResult getProductDetail()
        {
            var result = _productService.GetProdutDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);           
        }   
    }
}
