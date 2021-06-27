using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MapperLibrary.Interfaces;

namespace MapperLibrary
{
    public class MapperType<TSource, TDestination> : IMapperType<TSource, TDestination>
        where TSource: class
        where TDestination : class, new()
    {
        private readonly IMapperHelper<TSource> _sourceMapperHelper;
        private readonly IMapperHelper<TDestination> _destinationMapperHelper;

        public MapperType(IMapperHelper<TSource> sourceMapperHelper, IMapperHelper<TDestination> destinationMapperHelper)
        {
            _sourceMapperHelper = sourceMapperHelper ?? throw new ArgumentNullException($"{sourceMapperHelper}");
            _destinationMapperHelper = destinationMapperHelper ?? throw new ArgumentNullException($"{destinationMapperHelper}");
        }

        public TDestination Map(TSource TSource)
        {
            try
            {
                TDestination destination = new TDestination();
                IDictionary<string, PropertyInfo> sourceProperties = _sourceMapperHelper.GetProperties(TSource);
                IDictionary<string, PropertyInfo> destinationProperties = _destinationMapperHelper.GetProperties(destination);

                BindProperties(sourceProperties, destinationProperties, TSource, destination);

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
