using System;
using System.Linq;
using Devon.Domain;
using Devon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devon.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Product GetById(int id)
        {
            return _dbContext.Set<Product>().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _dbContext.Set<Product>().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Set<Product>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
