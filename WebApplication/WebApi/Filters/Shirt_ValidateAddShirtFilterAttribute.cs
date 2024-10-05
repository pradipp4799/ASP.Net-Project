using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;
using WebApi.Models.Repositories;

namespace WebApi.Filters
{
    public class Shirt_ValidateAddShirtFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt=context.ActionArguments["shirt"] as Shirt;
            Console.WriteLine(shirt.Brand);
            if(shirt==null){
                context.ModelState.AddModelError("Shirt","shirt Object null");
                var ProblemDetails=new ValidationProblemDetails(context.ModelState)
                {
                    Status=StatusCodes.Status400BadRequest

                };
                context.Result= new BadRequestObjectResult(ProblemDetails);
            }

            else{
                 var existingShirt =ShirtRepository.GetShirtByproperties(shirt.Brand,shirt.Gender,shirt.Color,shirt.Size);
                Console.WriteLine(shirt.Brand);
               
               if(existingShirt!=null){
                context.ModelState.AddModelError("Shirt","shirt Alrady exit");
                var ProblemDetails=new ValidationProblemDetails(context.ModelState)
                {
                    Status=StatusCodes.Status400BadRequest

                };
                context.Result= new BadRequestObjectResult(ProblemDetails);
            }

            
        }

    }
    }
}