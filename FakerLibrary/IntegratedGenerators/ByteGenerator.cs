using System;

namespace FakerLibrary.IntegratedGenerators
{
    public class ByteGenerator : IIntegratedTypesGenerator
    {
        private Random _random;

        public ByteGenerator() 
        {
            _random = new Random();
        }

        public object Generate()
        {         
            return (byte)_random.Next(byte.MinValue, byte.MaxValue);
        }
    }
}
