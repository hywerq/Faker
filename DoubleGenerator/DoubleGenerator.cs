using FakerLibrary;
using System;

namespace DoubleGeneratorPlugin
{
    public class DoubleGenerator : IExternalTypesGenerator
    {
        private Random _random;

        public DoubleGenerator()
        {
            _random = new Random();
        }

        public object Generate()
        {
            return Math.Round(_random.NextDouble(), 3);
        }

        public Type GetCurrentType()
        {
            return typeof(double);
        }
    }
}
