using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebApi.Models.Repositories
{
    public class ShirtRepository
    {
           private static List<Shirt> shirts = new List<Shirt>()
        {
          new Shirt { ShirtId=1,Brand="new Brand",Color="color1",Gender="Men",Price=30,Size=10},
          new Shirt { ShirtId=2,Brand="My Brand",Color="color2",Gender="Men",Price=20,Size=13},
          new Shirt { ShirtId=3,Brand="new Brand",Color="color3",Gender="women",Price=30,Size=8},
          new Shirt { ShirtId=4,Brand="new Brand",Color="cplor4",Gender="women",Price=10,Size=9}
        };

        public static void AddShirt(Shirt shirt){
            int MaxId=shirts.Max(x=>x.ShirtId);
            shirt.ShirtId=MaxId+1;
            shirts.Add(shirt);
        }
        public static List<Shirt> GetAllShirts(){
            return shirts;
        }
        public static bool ShirtExists(int? id)
        {
            return shirts.Any(x=>x.ShirtId==id);
        }

        public static void DeleteShirt(Shirt shirt){
            shirts.Remove(shirt);
        }

        public static Shirt? GetShirtById(int id){
            return shirts.FirstOrDefault(x=> x.ShirtId ==id);
        }

        public static Shirt? GetShirtByproperties(string? brand,string? gender,string? color, int? size){
             return shirts.FirstOrDefault(x=> !string.IsNullOrWhiteSpace(brand) &&!string.IsNullOrWhiteSpace(x.Brand) && x.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase)&&
             !string.IsNullOrWhiteSpace(gender) &&!string.IsNullOrWhiteSpace(x.Gender) && x.Gender.Equals(gender,StringComparison.OrdinalIgnoreCase)&& 
             !string.IsNullOrWhiteSpace(color) &&!string.IsNullOrWhiteSpace(x.Color) && x.Color.Equals(color,StringComparison.OrdinalIgnoreCase)&&size.HasValue&& x.Size.HasValue&& size.Value==x.Size.Value);
        }
        public static void UpadteShirt(Shirt shirt){
         
            Shirt OldShirt=shirts.First(x=>x.ShirtId==shirt.ShirtId);
            OldShirt.Brand=shirt.Brand;
            OldShirt.Color=shirt.Color;
            OldShirt.Price=shirt.Price;
            OldShirt.Size=shirt.Size;
            OldShirt.Gender=shirt.Gender;

        }

        
    }
}