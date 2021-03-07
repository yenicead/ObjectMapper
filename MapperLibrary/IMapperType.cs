using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public interface IMapperType<in TSource, out TDestination>
    {
        TDestination Map(TSource mappedObject);
    }
}
