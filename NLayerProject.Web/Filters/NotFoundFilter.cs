using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Web.DTOs;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {

        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryService.GetByIdAysnc(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto
                {
                    StatusCode = 404
                };
                errorDto.Errors.Add($"Category not found : id({id}) ");

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
