using FakerLibrary.IntegratedGenerators;
using System;

namespace FakerLibrary
{
    public interface IExternalTypesGenerator : IIntegratedTypesGenerator
    {
        Type GetCurrentType();
    }
}
