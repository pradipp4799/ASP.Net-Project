
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Shirt> Shirts {set; get;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shirt>().HasData(
         new Shirt { ShirtId=1,Brand="new Brand",Color="color1",Gender="Men",Price=30,Size=10},
          new Shirt { ShirtId=2,Brand="My Brand",Color="color2",Gender="Men",Price=20,Size=13},
          new Shirt { ShirtId=3,Brand="new Brand",Color="color3",Gender="women",Price=30,Size=8},
          new Shirt { ShirtId=4,Brand="new Brand",Color="cplor4",Gender="women",Price=10,Size=9}
        
            );
        }
    }
}