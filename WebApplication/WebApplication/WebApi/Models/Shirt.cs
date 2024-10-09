using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Validations;

namespace WebApi.Models
{
    public class Shirt
    {
        public int ShirtId {get; set;}
        [Required]
        public string? Brand { get; set;}
        [Required]
        public string? Color {get;set;}
        [Shirt_EnsureCorrectSizing]
        public int? Size {get; set;}
        [Required]
        public string? Gender {get;set;}
        public int Price{get;set;}

    }
}