using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
       public  DbSet<Items> Items{ get;set;}
       public DbSet<Category> Categories{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, name = "select type items" }, new Category() { Id = 2, name = "Computers" }, new Category() { Id = 3, name = "phones" }
            , new Category() { Id = 4, name = "alimentation" } 
       
        );
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole()
               {
                   Id=Guid.NewGuid().ToString(),Name ="Admin",NormalizedName="admin",ConcurrencyStamp= Guid.NewGuid().ToString()
               }, new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "User",
                   NormalizedName = "user",
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
