namespace Shop.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Data.Entities;
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
           
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            var user = await this.userHelper.GetUserByEmailAsync("jose.arroyo@bismarck.com.pe");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Jose",
                    LastName = "Arroyo",
                    Email = "jose.arroyo@bismarck.com.pe",
                    PhoneNumber = "962770338",
                    UserName = "jose.arroyo@bismarck.com.pe"
                };
                var result = await this.userHelper.AddUserAsync(user, "060285");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Cebolla x KGR", user);
                this.AddProduct("Tomate x KGR", user);
                this.AddProduct("Arroz x KGR", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }

    }
}
