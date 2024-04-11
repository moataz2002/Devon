using Devon.Domain.Entities;

namespace Devon.Domain
{
    public interface IProductRepository
    {
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
