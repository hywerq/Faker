using System;

namespace FakerLibrary.IntegratedGenerators
{
    public class DateTimeGenerator : IIntegratedTypesGenerator
    {
        public object Generate()
        {
            return DateTime.Now;
        }
    }
}
