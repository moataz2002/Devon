using System;
using Devon.Domain;
using Devon.Domain.Entities;
using Devon.Domain.Events;

namespace Devon.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void AddProduct(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero", nameof(price));
            }

            var product = new Product(name, price);
            _productRepository.Add(product);

            // Raise domain event
            var productAddedEvent = new ProductAddedEvent(product);
            // You can propagate this event further in your application
        }

        public void UpdateProduct(int productId, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero", nameof(price));
            }

            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found", nameof(productId));
            }

            existingProduct.UpdateDetails(name, price);
            _productRepository.Update(existingProduct);
        }

        public void DeleteProduct(int productId)
        {
            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found", nameof(productId));
            }

            _productRepository.Delete(productId);
        }
    }
}
