using System;
using System.Collections.Generic;

namespace FakerLibrary.IntegratedGenerators
{
    public class IntegratedTypesDictionary
    {
        public static Dictionary<Type, IIntegratedTypesGenerator> FillDictionary()
        {
            Dictionary<Type, IIntegratedTypesGenerator> dictionary = new Dictionary<Type, IIntegratedTypesGenerator>
            {
                { typeof(byte), new ByteGenerator() },
                { typeof(int), new IntGenerator() },
                { typeof(long), new LongGenerator() },
                { typeof(string), new StringGenerator() },
                { typeof(DateTime), new DateTimeGenerator() },
            };

            return dictionary;
        }
    }
}