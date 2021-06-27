using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MapperLibrary.Interfaces;

namespace MapperLibrary
{
    public class MapperHelper<T> : IMapperHelper<T>
        where T : class
    {
        public IDictionary<string, PropertyInfo> GetProperties(T T)
        {
            if (T is null)
                throw new ArgumentNullException($"Parameter {(T) null} is null.");

            var result = T.GetType()
                            .GetProperties()
                            .ToDictionary(key => key.Name, value => value);

            return result;
        }
    }
}
