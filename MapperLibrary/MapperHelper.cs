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

                // If source property type is enum and destination property type is primitive type (string, int, long etc), 
                // then convert and assign source property value to destination property.
                if (sourceProperty.Value.PropertyType.IsEnum)
                {
                    Type destinationPropertyType = destinationProperties[sourcePropertyName].PropertyType;
                    switch (destinationPropertyType)
                    {
                        case Type when destinationPropertyType == typeof(string):
                            destinationProperties[sourcePropertyName].SetValue(destination, sourcePropertyValue.ToString());
                            continue;

                        case Type when destinationPropertyType == typeof(short):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToInt16(sourcePropertyValue));
                            continue;

                        case Type when destinationPropertyType == typeof(int):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToInt32(sourcePropertyValue));
                            continue;

                        case Type when destinationPropertyType == typeof(uint):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToUInt32(sourcePropertyValue));
                            continue;

                        case Type when destinationPropertyType == typeof(long):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToInt64(sourcePropertyValue));
                            continue;

                        case Type when destinationPropertyType == typeof(ulong):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToUInt64(sourcePropertyValue));
                            continue;

                        case Type when destinationPropertyType == typeof(bool):
                            destinationProperties[sourcePropertyName].SetValue(destination, Convert.ToBoolean(sourcePropertyValue));
                            continue;

                        default:
                            break;
                    }
                }

                // TODO<Adem>: 1. If sourceProperty is class (Address) and destinationProperty is another class (AddressDto) then find a solution.
                // TODO<Adem>: 2. If Source type is class and destination type is not class then find a solution.
                // TODO<Adem>: 3. If Source type is list and destination type is also list then test if it maps.
            }
        }
    }
}
