using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Context
{
    public class EfDbContext
        : DbContext
    {
        public EfDbContext()
            : base("EfDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserEntityConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }

    public class EfDbInitializer
        : DropCreateDatabaseAlways<EfDbContext>
    {
        public EfDbInitializer()
        {

        }

        protected override void Seed(EfDbContext context)
        {
            context.Roles.AddRange(new List<Role>
            {
                new Role { Name = "Guest", DisplayName = "Гость" },
                new Role { Name = "User", DisplayName = "Пользователь" },
                new Role { Name = "Administrator", DisplayName = "Администратор" }
            });

            context.SaveChanges();

            context.Groups.AddRange(new List<Group>
            {
                new Group { Name = "Guests", DisplayName = "Гости", RoleId = 1 },
                new Group { Name = "Users", DisplayName = "Пользователи", RoleId = 2 },
                new Group { Name = "Administrators", DisplayName = "Администраторы", RoleId = 3 }
            });

            context.SaveChanges();

            context.Users.AddRange(new List<User>
            {
                new User { Login = "Guest", Password = "111111", GroupId = 1 },
                new User { Login = "User", Password = "111111", GroupId = 2 },
                new User { Login = "Admin", Password = "111111", GroupId = 3 }
            });

            context.SaveChanges();

            context.ProductTypes.AddRange(new List<ProductType>
            {
                new ProductType {Name = "Sport", Description = "Спортивный товар"},
                new ProductType {Name = "Kids", Description = "Товары для детей"},
                new ProductType {Name = "Home", Description = "Товары для дома"},
                new ProductType {Name = "Everyone", Description = "Товары для всех"}
            });

            context.SaveChanges();

            context.Products.AddRange(new List<Product>
            {
                new Product { ProductTypeId = 1, Description = "Футбольный мяч", Name = "Ball", Cost = 221 },
                new Product { ProductTypeId = 1, Description = "Горный велосипед", Name = "Bicyle", Cost = 222 },
                new Product { ProductTypeId = 2, Description = "Детская игрушка", Name = "Toy", Cost = 322 },
                new Product { ProductTypeId = 2, Description = "Детское молоко", Name = "Milk", Cost = 232 },
                new Product { ProductTypeId = 3, Description = "Мягкая подушка", Name = "Pillow", Cost = 2444 },
                new Product { ProductTypeId = 3, Description = "Мыло для душа", Name = "Soap", Cost = 2442 },
                new Product { ProductTypeId = 4, Description = "Ручка шариковая", Name = "Pen", Cost = 2552 },
                new Product { ProductTypeId = 4, Description = "Домашний телефон", Name = "Phone", Cost = 5522 }
            });

            context.SaveChanges();
        }
    }
}