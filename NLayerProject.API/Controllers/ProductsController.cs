using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mappper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mappper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mappper.Map<IEnumerable<ProductDto>>(products));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAysnc(id);

            return Ok(_mappper.Map<ProductDto>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto) 
        {
            var newProduct = await _productService.AddAsync(_mappper.Map<Product>(productDto));
            return Created(string.Empty, _mappper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _productService.Update(_mappper.Map<Product>(productDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAysnc(id).Result;
            _productService.Remove(product);

            return NoContent();

        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryByPrductId(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mappper.Map<ProductWithCategoryDto>(product));
        }

    }
}