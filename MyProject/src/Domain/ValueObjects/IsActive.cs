using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.src.Domain.ValueObjects
{
    public class IsActive
    {
        public bool Value { get; private set; }

        public IsActive(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(IsActive isActive)
        {
            return isActive.Value;
        }

        public static implicit operator IsActive(bool value)
        {
            return new IsActive(value);
        }

        public static readonly IsActive True = new IsActive(true);
        public static readonly IsActive False = new IsActive(false);
    }
}