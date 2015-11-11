﻿using System;
using AxUnit.Sample.Interfaces;

namespace AxUnit.Sample
{
    public class Accumulator : IAccumulator
    {
        private readonly IValidator _validator;

        public double Value { get; set; }

        public Accumulator(IValidator validator)
        {
            _validator = validator;
        }

        public void Add(double number)
        {
            if (!_validator.IsValid(number))
            {
                throw new ArgumentException();
            }
            Value += number;
        }
    }
}