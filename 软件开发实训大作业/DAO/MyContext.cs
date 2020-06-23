using ERestaurant.DAO.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ERestaurant.DAO
{
    public class MyContext : DbContext
    {
        public DbSet<TakeOut> TakeOuts { get; set; }
        public DbSet<TakeOutAndFood> TakeOutAndFoods { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Food> Foods { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>().Property(x => x.Name).HasMaxLength(200);
            modelBuilder.Entity<Account>().Property(x => x.Password).HasMaxLength(200);
            modelBuilder.Entity<Account>().Property(x => x.Phone).HasMaxLength(200);
            modelBuilder.Entity<Account>().Property(x => x.Address).HasMaxLength(500);
            modelBuilder.Entity<Account>().Property(x => x.Avatar).HasMaxLength(500);
            modelBuilder.Entity<Account>().Property(x => x.NickName).HasMaxLength(500);

            modelBuilder.Entity<Food>().HasKey(x => x.Id);
            modelBuilder.Entity<Food>().Property(x => x.Name).HasMaxLength(200);
            modelBuilder.Entity<Food>().Property(x => x.Description).HasMaxLength(500);
            modelBuilder.Entity<Food>().Property(x => x.Image).HasMaxLength(500);

            modelBuilder.Entity<TakeOut>().HasKey(x => x.Id);

            modelBuilder.Entity<TakeOutAndFood>().HasKey(x => x.Id);

            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(500);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "荤菜"
                },
                 new Category()
                 {
                     Id = 2,
                     Name = "素菜"
                 });

            modelBuilder.Entity<TakeOutAndFood>().HasData(
                 new TakeOutAndFood()
                 {
                     Id = 1,
                     OrderId = 1,
                     FoodId = 1,
                 },
                  new TakeOutAndFood()
                  {
                      Id = 2,
                      OrderId = 1,
                      FoodId = 2,
                  },
                  new TakeOutAndFood()
                  {
                      Id = 3,
                      OrderId = 2,
                      FoodId = 2
                  });

            modelBuilder.Entity<Food>().HasData(
               new Food()
               {
                   Id = 1,
                   Name = "麻辣香锅",
                   Description = "好吃的油焖大虾，2斤一份",
                   Price = 128,
                   StockCount = 100,
                   Image = "/upload/youmendaxie.jpg",
                   CreateTime = DateTime.Now,
                   Type = "荤菜"
               });

            modelBuilder.Entity<TakeOut>().HasData(
              new TakeOut()
              {
                  Id = 1,
                  AccountId = 1,
                  Price = 120,
                  CreateTime = DateTime.Now,
                  Status="已付款"
              },
               new TakeOut()
               {
                   Id = 2,
                   AccountId = 3,
                   Price = 120,
                   CreateTime = DateTime.Now,
                   Status = "已送货"
               },
               new TakeOut()
               {
                   Id = 3,
                   AccountId = 3,
                   Price = 120,
                   CreateTime = DateTime.Now,
                   Status = "已完成"
               });

            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    Id = 1,
                    RoleId = 2,
                    Name = "马云",
                    NickName = "Jack Ma",
                    Password = "123",
                    Phone = "13568955684",
                    Address = "北京市海淀区洪城大道18号 开饭了2401室",
                    CreateTime = DateTime.Now
                },
                new Account()
                {
                    Id = 2,
                    RoleId = 2,
                    Name = "马化腾",
                    Password = "123",
                    NickName = "Pony Ma",
                    Phone = "13668955684",
                    Address = "北京市海淀区洪城大道18号 开饭了2401室",
                    CreateTime = DateTime.Now
                },
                new Account()
                {
                    Id = 3,
                    RoleId = 2,
                    Name = "李彦宏",
                    NickName = "SSSSSS",
                    Password = "13668955684",
                    Phone = "13668234244",
                    Address = "北京市海淀区洪城大道18号 开饭了2401室",
                    CreateTime = DateTime.Now
                },
                new Account()
                 {
                     Id = 4,
                     RoleId = 1,
                     Name = "Admin",
                     NickName = "Jack Ma",
                     Password = "123",
                     Phone = "13568955684",
                     Address = "北京市海淀区洪城大道18号 开饭了2401室",
                     CreateTime = DateTime.Now
                 });
        }
    }
}
