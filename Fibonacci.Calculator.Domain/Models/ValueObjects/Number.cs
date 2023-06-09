﻿using Calculator.Domain.Models.Base;

namespace Calculator.Domain.Models.ValueObjects
{
    public class Number : ValueObject
    {
        public long Value { get; private set; }


        public Number(long value)
        {
            Value = value;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public void Set(long number)
        {
            Value = number;
        }
    }
}