using System;
using System.Collections.Generic;
using System.Reflection;

namespace MapperLibrary
{
    public class MapperHelper
    {
        public static void BindProperties(
            IDictionary<string, PropertyInfo> sourceProperties, 
            IDictionary<string, PropertyInfo> destinationProperties, 
            object source, 
            object destination)
        {
            if (sourceProperties is null)
                throw new ArgumentNullException(nameof(sourceProperties));

            if (destinationProperties is null)
                throw new ArgumentNullException(nameof(destinationProperties));

            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            foreach (KeyValuePair<string, PropertyInfo> sourceProperty in sourceProperties)
            {
                string sourcePropertyName = sourceProperty.Key;
                object sourcePropertyValue = sourceProperty.Value.GetValue(source);

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
