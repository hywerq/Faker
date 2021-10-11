using System;
using System.Collections.Generic;

namespace FakerLibrary.IntegratedGenerators
{
    public class ArrayGenerator
    {
        private Random _random;
        private Dictionary<Type, IIntegratedTypesGenerator> _integratedTypesGenerators;

        public ArrayGenerator(Dictionary<Type, IIntegratedTypesGenerator> generators)
        {
            _random = new Random();
            _integratedTypesGenerators = generators;
        }

        public object Generate(Type type)
        {
            
            Array generated = Array.CreateInstance(type, _random.Next(5, 15));

            if (_integratedTypesGenerators.TryGetValue(type, out IIntegratedTypesGenerator generator))
            {
                for (int i = 0; i < generated.Length; i++)
                {
                    generated.SetValue(generator.Generate(), i);
                }
            }

            return generated;
        }
    }
}
