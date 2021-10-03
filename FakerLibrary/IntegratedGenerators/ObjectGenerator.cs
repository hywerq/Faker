using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibrary.IntegratedGenerators
{
    public class ObjectGenerator
    {
        private Faker _faker;

        public ObjectGenerator(Faker faker)
        {
            _faker = faker;
        }

        private void SetFields(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                object field = _faker.CreateDTO(fieldInfo.FieldType);

                fieldInfo.SetValue(obj, field);
            }
        }

        private void SetProperties(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                object property = _faker.CreateDTO(propertyInfo.PropertyType);
                propertyInfo.SetValue(obj, property);
            }
        }

        public object CreateObject(Type type)
        {
            ConstructorInfo[] constructor = type.GetConstructors();
            List<object> constructorParams = new List<object>();

            foreach (ParameterInfo parameter in constructor[0].GetParameters())
            {
                var obj = _faker.CreateDTO(parameter.ParameterType);
                constructorParams.Add(obj);
            }

            var newObj = constructor[0].Invoke(constructorParams.ToArray());
            if (newObj != null)
            {
                SetFields(newObj);
                SetProperties(newObj);
            }

            return newObj;
        }

    }
}
