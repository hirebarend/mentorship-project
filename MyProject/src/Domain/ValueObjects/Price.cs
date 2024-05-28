using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.src.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; }

        public Price(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(value));
            }

            Value = value;
        }

        public static implicit operator decimal(Price price)
        {
            return price.Value;
        }

        public static implicit operator Price(decimal value)
        {
            return new Price(value);
        }
    }
}