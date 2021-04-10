using System;
using System.Collections.Generic;
using System.Reflection;

namespace MapperLibrary.Interfaces
{
    public interface IMapperHelper<in T>
    {
        IDictionary<string, PropertyInfo> GetProperties(T T);
    }
}
