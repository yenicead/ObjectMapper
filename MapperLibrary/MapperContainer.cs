using System;
using System.Collections.Generic;
using System.Linq;

namespace MapperLibrary
{
    public static class MapperContainer
    {
        private static readonly IList<TypeTuple> typeTupleList = new List<TypeTuple>();

        public static void Assign<TSource, TDestination>()
            where TSource: class
            where TDestination: class
        {
            if (typeof(TSource) == typeof(TDestination))
                throw new Exception($"Source type: { typeof(TSource) } and destination type { typeof(TDestination) } cannot be same type.");

            if (typeTupleList.Any(x => x.SourceType == typeof(TSource) && x.DestinationType == typeof(TDestination)))
                throw new Exception($"Source type: { typeof(TSource) } and destination type: { typeof(TDestination) } are already exist in the MapperContainer.");

            AddMapperToList(new TypeTuple { SourceType = typeof(TSource), DestinationType = typeof(TDestination) });
        }

        private static void AddMapperToList(TypeTuple mapper)
        {
            typeTupleList.Add(mapper);
        }

        public static IList<TypeTuple> GetMapperList()
        {
            return typeTupleList;
        }
    }

    public class TypeTuple 
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
    }
}
