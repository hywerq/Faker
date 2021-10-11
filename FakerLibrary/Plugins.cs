using FakerLibrary.IntegratedGenerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FakerLibrary
{
    internal class Plugins
    {
        private Dictionary<Type, IIntegratedTypesGenerator> _integratedTypesGenerators;

        internal Plugins(Dictionary<Type, IIntegratedTypesGenerator> generators)
        {
            _integratedTypesGenerators = generators;
        }

        internal void Plug()
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
