using Devon.Domain.Entities;
using System;

namespace Devon.Domain.Events
{
    public class ProductAddedEvent
    {
        public Product Product { get; }

        public DateTime Timestamp { get; }

        public ProductAddedEvent(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Timestamp = DateTime.UtcNow; // Set the timestamp to current UTC time
        }
    }
}
