using FakerLibrary;
using System;

namespace FloatGeneratorPlugin
{
    public class FloatGenerator : IExternalTypesGenerator
    {
        private Random _random;

        public FloatGenerator()
        {
            _random = new Random();
        }

        public object Generate()
        {
            return (float)_random.NextDouble();
        }

        public Type GetCurrentType()
        {
            return typeof(float);
        }
    }
}
