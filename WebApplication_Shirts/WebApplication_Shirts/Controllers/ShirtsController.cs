using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Filters;
using WebApplication2.Models;
using WebApplication2.Filters.ActionFilters;
using WebApplication2.Models.Repository;
using WebApplication2.Filters.ExceptionFilters;


namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController: ControllerBase
    {
       
        [HttpGet]
       // [Route("/shirts")]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetAllShirts());
        }

        [HttpGet("{id}/{color}" )]
        [Shirt_ValidateShirtIdFilter]
        // [Route("/shirts/{id}")]
        public IActionResult GetShirtById(int id,[FromRoute]string color)
        {
            //if (id <= 0)
            //{
            //    return BadRequest();
            //}
            //var shirt=ShirtRepository.GetShirtById(id);
            //if (shirt == null)
            //{
            //    return NotFound();
            //}
            //return Ok(shirt);
            return Ok(ShirtRepository.GetShirtById(id));
        }



        [HttpPost]
        [Shirt_ValidateShirtAddFilterAttributer]
        // [Route("/shirts")]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            
            ShirtRepository.AddShirt(shirt);
            Console.WriteLine(shirt.Brand);
            return Ok("Creating a shirt" + shirt.ShirtId);
        }
        [HttpPut("{id}")]
       [Shirt_ValidateUpdateShirtFilterAttribute]
       [Shirt_HandleUpdateExceptionFilter]
        // [Route("/shirts/{id}")]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
         
                ShirtRepository.UpdateShirt(shirt);
            
          
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        // [Route("/shirts/{id}")]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            Console.WriteLine(shirt.ShirtId);
            if (shirt != null)

                ShirtRepository.RemoveShirt(shirt);
            return Ok("ok");
        }

    }
}
