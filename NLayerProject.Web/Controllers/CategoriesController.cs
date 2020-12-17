using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using NLayerProject.Web.ApiServices;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;


        public CategoriesController(ICategoryService categoryService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Update(int Id)
        {
            //throw new Exception("Test Global error handling");

            var category = await _categoryService.GetByIdAysnc(Id);

            return View(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
            
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int Id)
        {
            var category = _categoryService.GetByIdAysnc(Id).Result;

            _categoryService.Remove(category);

            return RedirectToAction("Index");

        }

    }
}