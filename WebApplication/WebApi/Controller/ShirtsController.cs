using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models;
using WebApi.Models.Repositories;

namespace WebApi.Controller
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ShirtsController : ControllerBase
{
     
        
        [HttpGet]
        //[Route("/shirts")]
        public List<Shirt> GetShirts(){
            return ShirtRepository.GetAllShirts();
        }
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        //[Route("/shirts/{id}")]
        public IActionResult GetShirtById(int id){
           
          return Ok(ShirtRepository.GetShirtById(id));
        }
        [HttpPost]
        [Shirt_ValidateAddShirtFilter]
        //[Route("/shirts")]
        public IActionResult CreateShirt([FromBody]Shirt shirt){
           
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),new {id=shirt.ShirtId},shirt);
        }
        [HttpPut("{id}")]
        [Shirt_ValidateUpdateShirtFilter]
        //[Route("/shirts/{id}")]
        public IActionResult UpdateShirt(int id,Shirt shirt){
           
               ShirtRepository.UpadteShirt(shirt);
         
            return Ok(shirt);
        }
            
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
       // [Route("/shirts/{id}")]
        public IActionResult DeleteShirtById(int id){
            Shirt shirt=ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(shirt);

            return Ok();

        }
    }
}