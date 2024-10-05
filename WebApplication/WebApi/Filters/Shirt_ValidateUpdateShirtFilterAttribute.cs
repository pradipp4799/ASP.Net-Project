 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;
using WebApi.Models.Repositories;

namespace WebApi.Filters
{
    public class Shirt_ValidateUpdateShirtFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
             var ShirtId = context.ActionArguments["id"] as int?;
             var shirt=context.ActionArguments["shirt"] as Shirt;

            if(ShirtId.HasValue){
                if(ShirtId.Value <=0){
                    context.ModelState.AddModelError("ShirtId","ShirtId is invalid");
                    var ProblemDetails=new ValidationProblemDetails(context.ModelState)
                    {
                        Status=StatusCodes.Status400BadRequest
                    };
                    context.Result=new BadRequestObjectResult(ProblemDetails);
                }
                else if(ShirtId!=shirt.ShirtId){
                      context.ModelState.AddModelError("ShirtId","Shirt does'nt  Matches to each other");
                         var ProblemDetails=new ValidationProblemDetails(context.ModelState)
                    {
                        Status=StatusCodes.Status404NotFound
                    };
                    context.Result=new NotFoundObjectResult(context.ModelState);
                }
                     else if(!ShirtRepository.ShirtExists(ShirtId.Value)){
                      context.ModelState.AddModelError("ShirtId","Shirt does'nt exit");
                         var ProblemDetails=new ValidationProblemDetails(context.ModelState)
                    {
                        Status=StatusCodes.Status404NotFound
                    };
                    context.Result=new NotFoundObjectResult(context.ModelState);
                }
          }
  
        }
    }
}