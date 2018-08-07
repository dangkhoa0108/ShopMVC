using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeduShop.Model.Models;

namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));
            //var user = new ApplicationUser
            //{
            //    UserName = "admin",
            //    Email = "tdangkhoa.itute@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName = "Tran Dang Khoa"
            //};
            //manager.Create(user,"123456");
            //if (roleManager.Roles.Any()) return;
            //roleManager.Create(new IdentityRole { Name = "Admin" });
            //roleManager.Create(new IdentityRole { Name = "User" });
            //var admin = manager.FindByEmail("tdangkhoa.itute@gmail.com");
            //manager.AddToRole(admin.Id,new[]{"Admin", "User"}.ToString());
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (!context.ProductCategories.Any())
            {
                List<ProductCategory> listCategory = new List<ProductCategory>()
                {
                    new ProductCategory()
                    {
                        Name = "Dien Lanh", Alias = "dien-lanh", Status = true
                    },
                    new ProductCategory()
                    {
                        Name = "Vien Thong", Alias = "vien-thong", Status = true
                    },
                    new ProductCategory()
                    {
                        Name = "Do gia dung", Alias = "do-gia-dung", Status = true
                    },
                };
                context.ProductCategories.AddRange(listCategory);
                context.SaveChanges();
            }
            
        }
    }
}
