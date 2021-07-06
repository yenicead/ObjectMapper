using MapperLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MapperLibrary
{
    public class Mapper : IMapper
    {
        public object Map(object source)
        {
            TypeTuple typeTuple = GetTypeTuple(source);

            object destinationInstance = Activator.CreateInstance(typeTuple.DestinationType);

            IDictionary<string, PropertyInfo> sourceProperties = GetProperties(source);
            IDictionary<string, PropertyInfo> destinationProperties = GetProperties(destinationInstance);

            MapperHelper.BindProperties(sourceProperties, destinationProperties, source, destinationInstance);

            return destinationInstance;
        }

        public T Map<T>(object source)
        {
            T destinationInstance = Activator.CreateInstance<T>();

            IDictionary<string, PropertyInfo> sourceProperties = GetProperties(source);
            IDictionary<string, PropertyInfo> destinationProperties = GetProperties(destinationInstance);

            MapperHelper.BindProperties(sourceProperties, destinationProperties, source, destinationInstance);

            return destinationInstance;
        }

        private static IDictionary<string, PropertyInfo> GetProperties(object T)
        {
            if (T is null)
                throw new ArgumentNullException($"Parameter {T} is null.");

            return T.GetType().GetProperties()
                        .ToDictionary(key => key.Name, value => value);
        }

        private static TypeTuple GetTypeTuple(object source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            TypeTuple typeTuple = MapperContainer.GetMapperList()
                               .Where(m => m.SourceType == source.GetType())
                               .FirstOrDefault();

            if (typeTuple == null)
                throw new Exception($"Mapper is not found for { source.GetType() } type.");

            return typeTuple;
        }
    }
}
