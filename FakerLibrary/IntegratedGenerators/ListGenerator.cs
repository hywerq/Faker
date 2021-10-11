using System;
using System.Collections;
using System.Collections.Generic;

namespace FakerLibrary.IntegratedGenerators
{
    public class ListGenerator 
    {
        private Random _random;
        private Faker _faker;

        public ListGenerator(Faker faker)
        {
            _random = new Random();
            _faker = faker;
        }

        public object Generate(Type type)
        {
            IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));

            int size = _random.Next(1, 10);

            for (int i = 0; i < size; i++)
            {
                var obj = _faker.CreateDTO(type);
                list.Add(obj);
            }
            
            return list;
        }
    }
}
