using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class MapperType<TSource, TDestination> : IMapperType<TSource, TDestination>
        where TDestination : new()
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
