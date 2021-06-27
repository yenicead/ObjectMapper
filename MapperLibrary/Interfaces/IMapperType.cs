using System.Collections.Generic;
using System.Reflection;

namespace MapperLibrary.Interfaces
{
    public interface IMapperType<in TSource, out TDestination>
    {
        TDestination Map(TSource T);
    }
}
