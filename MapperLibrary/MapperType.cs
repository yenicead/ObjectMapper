using System;
using System.Collections.Generic;
using System.Reflection;
using MapperLibrary.Interfaces;

namespace MapperLibrary
{
    public class MapperType<TSource, TDestination> : IMapperType<TSource, TDestination>
        where TSource: class
        where TDestination : class, new()
    {
        public TDestination Map(TSource T)
        {
            try
            {
                TDestination destination = new TDestination();
                IDictionary<string, PropertyInfo> sourceProperties = new MapperHelper<TSource>().GetProperties(T);
                IDictionary<string, PropertyInfo> destinationProperties = new MapperHelper<TDestination>().GetProperties(destination);

                BindProperties(sourceProperties, destinationProperties, T, destination);

                return destination;
            }
            catch (Exception exception)
            {
                throw new Exception($"An exception has occurred, details: { exception }");
            }
        }

        private static void BindProperties(
            IDictionary<string, PropertyInfo> sourceProperties,
            IDictionary<string, PropertyInfo> destinationProperties,
            TSource sourceObject,
            TDestination destinationObject)
        {
            foreach (var sourceProperty in sourceProperties)
            {
                string sourcePropertyName = sourceProperty.Key;
                object sourcePropertyValue = sourceProperty.Value.GetValue(sourceObject);

                // TODO: What if destination property is another class? Find a solution for this case.
                if (destinationProperties.ContainsKey(sourcePropertyName) && 
                    destinationProperties[sourcePropertyName].PropertyType == sourceProperty.Value.PropertyType)
                {
                    PropertyInfo destinationPropertyValue = destinationProperties[sourcePropertyName];
                    destinationPropertyValue.SetValue(destinationObject, sourcePropertyValue);
                }
            }
        }
    }
}
