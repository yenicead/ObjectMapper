using System.Collections.Generic;
using System.Reflection;

namespace MapperLibrary.Interfaces
{
    public interface IMapper
    {
        object Map(object source);
        IDictionary<string, PropertyInfo> GetProperties(object T);
    }
}
