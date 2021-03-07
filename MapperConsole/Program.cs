using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;

namespace MapperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = Guid.NewGuid(),
                Name = "Adem",
                Surname = "Yenice",
                BirthDate = DateTime.Now,
                IdentityNumber = 12345678901
            };

            var xMapper = new MapperType<Person, PersonDTO>();
            PersonDTO personDto = xMapper.Map(person);

            Console.WriteLine(personDto.ToString());
        }
    }

    public interface IMapperType<in TSource, out TDestination>
    {
        TDestination Map(TSource mappedObject);
    }

    public class MapperType<TSource, TDestination> : IMapperType<TSource, TDestination>
        where TDestination: new()
    {
        public TDestination Map(TSource mappedObject)
        {
            Type sourceType = typeof(TSource);
            Dictionary<string, Type> sourceProperties = sourceType.GetProperties().ToDictionary(x => x.Name, y => y.PropertyType);

            TDestination destination = new TDestination();
            Type destinationType = destination.GetType();

            foreach (var sourceProperty in sourceType.GetProperties())
            {
                string propertyName = sourceProperty.Name;
                object propertyValue = sourceProperty.GetValue(mappedObject);

                PropertyInfo propertyInfo = destinationType.GetProperty(propertyName);
                propertyInfo?.SetValue(destination, propertyValue);

            }

            return destination;
        }
    }
}
