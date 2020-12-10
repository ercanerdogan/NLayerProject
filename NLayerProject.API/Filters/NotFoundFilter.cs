using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {

        private readonly IProductService _productService;
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;

        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAysnc(id);

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
                errorDto.Errors.Add($"Product not found : id({id}) ");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
