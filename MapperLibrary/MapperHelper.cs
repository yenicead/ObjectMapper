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

            // Iterating each property of source class.
            foreach (KeyValuePair<string, PropertyInfo> sourceProperty in sourceProperties)
            {
                string sourcePropertyName = sourceProperty.Key;
                object sourcePropertyValue = sourceProperty.Value.GetValue(source);

                if (!destinationProperties.ContainsKey(sourcePropertyName))
                    continue;

                // If source and destination property types match, then assign source property value to destination property.
                if (destinationProperties[sourcePropertyName].PropertyType == sourceProperty.Value.PropertyType)
                {
                    PropertyInfo destinationPropertyValue = destinationProperties[sourcePropertyName];
                    destinationPropertyValue.SetValue(destination, sourcePropertyValue);
                    continue;
                }

                // If source property type is enum and destination property type is string, then convert and assign source property value to destination property.
                if (destinationProperties[sourcePropertyName].PropertyType.FullName.Contains("String") && !sourceProperty.Value.PropertyType.IsClass)
                {
                    PropertyInfo destinationPropertyValue = destinationProperties[sourcePropertyName];
                    destinationPropertyValue.SetValue(destination, sourcePropertyValue.ToString());
                    continue;
                }
            }
        }
    }
}
