using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Web.ApiServices;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;


        public CategoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {
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
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Update(int Id)
        {
            //throw new Exception("Test Global error handling");

            //var category = await _categoryService.GetByIdAsync(Id);
            var category = await _categoryApiService.GetByIdAsync(Id);

            return View(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
            
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int Id)
        {

            await _categoryApiService.Remove(Id);

            return RedirectToAction("Index");

        }

    }
}