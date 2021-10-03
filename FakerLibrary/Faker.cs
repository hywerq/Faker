using FakerLibrary.IntegratedGenerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        private Dictionary<Type, IIntegratedTypesGenerator> _integratedTypesGenerators;
        private ArrayGenerator _arrayGenerator;
        private ListGenerator _listGenerator;
        private ObjectGenerator _objectGenerator;

        private List<Type> _usedTypes = new List<Type>();

        public Faker()
        {            
            _integratedTypesGenerators = IntegratedTypesDictionary.FillDictionary();
            _arrayGenerator = new ArrayGenerator(_integratedTypesGenerators);
            _listGenerator = new ListGenerator(_integratedTypesGenerators);
            _objectGenerator = new ObjectGenerator(this);
            
            PlugPlugins();
        }

        public T Create<T>()
        {
            return (T)CreateDTO(typeof(T));
        }

        internal object CreateDTO(Type type)
        {
            if (_usedTypes.Contains(type))
            {
                return null;
            }
            else
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

                    obj = _objectGenerator.CreateObject(type);

                    _usedTypes.Remove(type);
                }
                else if (type.IsGenericType)
                {
                    obj = _listGenerator.Generate(type.GenericTypeArguments[0]);
                }

                return obj;
            }
        }

        private void PlugPlugins()
        {
            List<Assembly> assemblies = new List<Assembly>();

            try
            {
                foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Plugins", "*.dll"))
                {
                    try
                    {                       
                        assemblies.Add(Assembly.LoadFile(new FileInfo(file).FullName));
                    }
                    catch (FileLoadException) { }
                }
            }
            catch (DirectoryNotFoundException)
            { }

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IExternalTypesGenerator).IsAssignableFrom(type) && type.IsClass)
                    {
                        IExternalTypesGenerator generator = (IExternalTypesGenerator)Activator.CreateInstance(type);
                        _integratedTypesGenerators.Add(generator.GetCurrentType(), generator);
                    }
                }
            }

        }
    }
}
