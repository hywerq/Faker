using System;
using System.Text;

namespace FakerLibrary.IntegratedGenerators
{
    class StringGenerator : IIntegratedTypesGenerator
    {
        private Random _random;

        public StringGenerator() 
        {
            _random = new Random();
        }

        public object Generate()
        {
            int size = _random.Next(10, 100);

            StringBuilder builder = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                builder.Append((char)_random.Next(20, 80));
            }

            return builder.ToString();
        }
    }
}
