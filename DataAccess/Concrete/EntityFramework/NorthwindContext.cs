using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
namespace DataAccess.Concrete.EntityFramework
{

    // Tablolar ile classları bağlamak için kullanılır.
    public class NorthwindContext:DbContext
    {
        //SQL SERVERI BAGLAMAK ICIN kullanıyoruz

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=SERCAN\SQLEXPRESS; User Id=sa; Password=1; Initial Catalog=Northwind;TrustServerCertificate=True;", builder => builder.EnableRetryOnFailure());
            }
            //"Server=TheServerAddress; Database=TheDataBase; User Id=TheUsername; Password=ThePassword; TrustServerCertificate=True"
            
            
        }

        public DbSet<Product> Products { get; set; }//Prop adları veritanaıyla aynı olmak zorrunda Tablo adıyla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers{ get; set; }

        public DbSet<Order> Orders { get; set; }






    }
}
