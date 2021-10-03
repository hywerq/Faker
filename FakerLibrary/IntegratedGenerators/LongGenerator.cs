using System;

namespace FakerLibrary.IntegratedGenerators
{
    class LongGenerator : IIntegratedTypesGenerator
    {
        private Random _random;

        public LongGenerator() 
        {
            _random = new Random(); 
        }

        public object Generate()
        {
            return (long)_random.Next(-100, 100);
        }
    }
}
