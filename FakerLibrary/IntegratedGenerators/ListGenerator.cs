using System;
using System.Collections;
using System.Collections.Generic;

namespace FakerLibrary.IntegratedGenerators
{
    public class ListGenerator 
    {
        private Random _random;
        private Dictionary<Type, IIntegratedTypesGenerator> _integratedTypesGenerators;

        public ListGenerator(Dictionary<Type, IIntegratedTypesGenerator> generators)
        {
            _random = new Random();
            _integratedTypesGenerators = generators;
        }

        public object Generate(Type type)
        {
            IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));

            if (_integratedTypesGenerators.TryGetValue(type, out IIntegratedTypesGenerator generator))
            {
                int size = _random.Next(5, 15);

                for (int i = 0; i < size; i++)
                {
                    list.Add(generator.Generate());
                }
            }
            return list;
        }
    }
}
