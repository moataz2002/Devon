using System;
using System.Collections.Generic;
using Devon.Application.Services;
using Devon.Domain;
using Devon.Domain.Entities;
using Devon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Devon.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dependency injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer("DESKTOP-3D4H9RS"))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<ProductService>()
                .BuildServiceProvider();



            // Resolve ProductService from the service provider
            var productService = serviceProvider.GetService<ProductService>();

            // Example usage of ProductService methods
            try
            {
                // Add a new product
                productService.AddProduct("Product1", 10.99m);
                Console.WriteLine("Product added successfully.");

                // Update an existing product
                productService.UpdateProduct(1, "UpdatedProduct", 15.99m);
                Console.WriteLine("Product updated successfully.");

                // Delete an existing product
                productService.DeleteProduct(1);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Additional classes and namespaces can be added below

    // Example DbContext class for Entity Framework Core
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Add DbSet properties for your domain entities
        public DbSet<Product> Products { get; set; }

        // Add any additional configuration or overrides as needed
    }
}
