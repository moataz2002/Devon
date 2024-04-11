using System;

namespace Devon.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be null or empty", nameof(street));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be null or empty", nameof(city));

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be null or empty", nameof(country));

            Street = street;
            City = city;
            Country = country;
        }
    }
}
