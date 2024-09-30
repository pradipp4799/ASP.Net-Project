using WebApplication2.Models.Repository;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Filters.ActionFilters
{
    public class Shirt_ValidateShirtAddFilterAttributer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
            

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                return ;
            }
            else
            {
                // Check for existing shirt without considering the ID
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("Shirt", "A shirt with the same brand, gender, color, and size already exists.");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
