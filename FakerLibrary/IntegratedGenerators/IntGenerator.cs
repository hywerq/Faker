using System;

namespace FakerLibrary.IntegratedGenerators
{
    public class IntGenerator : IIntegratedTypesGenerator
    {
        private Random _random;

        public IntGenerator() 
        {
            _random = new Random();
        }

        public object Generate()
        {
            return _random.Next(int.MinValue, int.MaxValue);
        }
    }
}
