using MapperLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class Mapper : IMapper
    {
        public object Map(object source)
        {
            IList<object> mapperList = MapperContainer.GetMapper();
            object mapper = MapperContainer.GetMapper()
                                           .Where(m => m.GetType().GetGenericArguments().Contains(source.GetType()))
                                           .FirstOrDefault();

            if (mapper == null)
                return null;

            Type[] genericArguments = mapper.GetType().GetGenericArguments();
            Type sourceType = genericArguments[0];
            Type destinationType = genericArguments[1];

            Type mapperType = typeof(IMapperType<,>).MakeGenericType(sourceType, destinationType);
            var mapperTypeInstance = Activator.CreateInstance(mapperType);

            return null;
        }
    }
}
