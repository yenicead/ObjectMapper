using MapperLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public static class MapperContainer
    {
        private static readonly IList<object> mapperList = new List<object>();

        public static void Assign<TSource, TDestination>()
            where TSource: class
            where TDestination: class, new()
        {
            IMapperHelper<TSource> sourceMapperHelper = new MapperHelper<TSource>();
            IMapperHelper<TDestination> destinationMapperHelper = new MapperHelper<TDestination>();
            IMapperType<TSource, TDestination> mapper = new MapperType<TSource, TDestination>(sourceMapperHelper, destinationMapperHelper);
            AddMapperToList(mapper);
        }

        public static void AddMapperToList(object mapper)
        {
            mapperList.Add(mapper);
        }

        public static IList<object> GetMapper()
        {
            return mapperList;
        }
    }
}
