using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controller
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        
        [HttpGet]
        //[Route("/shirts")]
        public string GetShirts(){
            return "Reading all the shirts";
        }
        [HttpGet("{id}")]
        //[Route("/shirts/{id}")]
        public string GetShirtById(int id){
            return $"Reading Shirt: {id}";
        }
        [HttpPost]
        //[Route("/shirts")]
        public string CreateShirt([FromBody]Shirt shirt){
             Console.WriteLine(shirt.ShirtId);
            Console.WriteLine(shirt.Brand);
            return $"Creating a shirt";
        }
        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        public string UpdateShirt(int id){
            return $"Update shirt:{id}";
        }
        [HttpDelete("{id}")]
       // [Route("/shirts/{id}")]
        public string DeleteShirtById(int id){
            return $"Deleting Shirt :{id}";
        }
    }
}