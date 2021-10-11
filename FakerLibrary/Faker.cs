using FakerLibrary.IntegratedGenerators;
using System;
using System.Collections.Generic;

namespace FakerLibrary
{
    public class Faker
    {
        private Dictionary<Type, IIntegratedTypesGenerator> _integratedTypesGenerators;
        private ArrayGenerator _arrayGenerator;
        private ListGenerator _listGenerator;
        private ObjectGenerator _objectGenerator;

        private List<Type> _usedTypes = new List<Type>();
        private Plugins plugins;

        public Faker()
        {            
            _integratedTypesGenerators = IntegratedTypesDictionary.FillDictionary();
            _arrayGenerator = new ArrayGenerator(_integratedTypesGenerators);
            _listGenerator = new ListGenerator(this);
            _objectGenerator = new ObjectGenerator(this);

            plugins = new Plugins(_integratedTypesGenerators);
            plugins.Plug();
        }

        public T Create<T>()
        {
            return (T)CreateDTO(typeof(T));
        }

        internal object CreateDTO(Type type)
        {       
            object obj = null;
            if (_integratedTypesGenerators.TryGetValue(type, out IIntegratedTypesGenerator generator))
            {
                obj = generator.Generate();
            }
            else if (type.IsArray)
            {
                obj = _arrayGenerator.Generate(type.GetElementType());
            }
            else if (type.IsClass && !type.IsGenericType)
            {
                _usedTypes.Add(type);

                if (CountTypeEntriesInList(type) <= 3)
                {
                    obj = _objectGenerator.CreateObject(type);
                }

                _usedTypes.Remove(type);
            }
            else if (type.IsGenericType)
            {
                obj = _listGenerator.Generate(type.GenericTypeArguments[0]);
            }

            return obj;            
        }

        private int CountTypeEntriesInList(Type type)
        {
            int count = 0;
            foreach (Type item in _usedTypes)
            {
                if (item == type)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
