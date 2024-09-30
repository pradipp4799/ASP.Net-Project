using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.Xml;
using WebApplication2.Controllers;
using WebApplication2.Filters;

namespace WebApplication2.Models.Repository
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
        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x =>x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x=>x.ShirtId==id);
        }

        public static void AddShirt(Shirt shirt)
        {
           int shirtId= shirts.Max(x => x.ShirtId);
            shirt.ShirtId = shirtId+1;
            shirts.Add(shirt);
        }
        public static void UpdateShirt(Shirt shirt)
        {
            var shirtUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtUpdate.Brand = shirt.Brand;
            shirtUpdate.Price = shirt.Price;
            shirtUpdate.Size = shirt.Size;
            shirtUpdate.Color = shirt.Color;
            shirtUpdate.Gender = shirt.Gender;

        }
        public static Shirt? GetShirtByProperties(string? brand,string? gender,string? color,int? size)
        {
            return shirts.FirstOrDefault(x => !string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(x.Brand)&&
            x.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) && size.HasValue &&  x.Size.HasValue && size.Value==x.Size.Value) ;  
        }
        public static void RemoveShirt(Shirt shirt)
        {
            Console.WriteLine(shirt.ShirtId);

            shirts.Remove(shirt);
        }
    }
}
