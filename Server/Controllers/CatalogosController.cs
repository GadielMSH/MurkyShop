using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Server.Extensions;
using MurkyShop.Server.Repositories.Contracts;
using MurkyShop.Shared.Dtos;
using MurkyShop.Shared.Models;
using System;

namespace MurkyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        //private readonly ApplicationDbContext dbContext;

        public CatalogosController(IProductRepository productRepository)//, ApplicationDbContext dbContext)
        {
            this.productRepository = productRepository;
            //this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var product = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();

                if (product == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = product.ConvertToDto(productCategories);

                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productCategory = await this.productRepository.GetCategory(product.CategoryId);
                    var productDto = product.ConvertToDto(productCategory);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}

