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
            TypeTuples typeTuples = MapperContainer.GetMapper()
                                           .Where(m => m.SourceType == source.GetType())
                                           .FirstOrDefault();

            if (typeTuples == null)
                throw new ArgumentException($"Mapper is not found for { source.GetType() } type." +
                    $"\nPlease add this type to MapperContainer and try again.");

            object destinationInstance = Activator.CreateInstance(typeTuples.DestinationType);

            IDictionary<string, PropertyInfo> sourceProperties = GetProperties(source);
            IDictionary<string, PropertyInfo> destinationProperties = GetProperties(destinationInstance);

            BindProperties(sourceProperties, destinationProperties, source, destinationInstance);

            return destinationInstance;
        }

        public IDictionary<string, PropertyInfo> GetProperties(object T)
        {
            if (T is null)
                throw new ArgumentNullException($"Parameter {T} is null.");

            return T.GetType().GetProperties()
                        .ToDictionary(key => key.Name, value => value);
        }

        // This method may be belong to different helper class.
        private static void BindProperties(
            IDictionary<string, PropertyInfo> sourceProperties,
            IDictionary<string, PropertyInfo> destinationProperties,
            object source,
            object destination)
        {
            foreach (var sourceProperty in sourceProperties)
            {
                string sourcePropertyName = sourceProperty.Key;
                object sourcePropertyValue = sourceProperty.Value.GetValue(source);

                // TODO: What if destination property is another class? Find a solution for this case.
                if (destinationProperties.ContainsKey(sourcePropertyName) &&
                    destinationProperties[sourcePropertyName].PropertyType == sourceProperty.Value.PropertyType)
                {
                    PropertyInfo destinationPropertyValue = destinationProperties[sourcePropertyName];
                    destinationPropertyValue.SetValue(destination, sourcePropertyValue);
                }
            }
        }
    }
}
