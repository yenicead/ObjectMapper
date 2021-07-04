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
            TypeTuple isTypeExist = typeTupleList.Where(x => x.SourceType == typeof(TSource) && x.DestinationType == typeof(TDestination)).FirstOrDefault();
            
            if (isTypeExist != null)
                throw new Exception($"{ typeof(TSource) } and { typeof(TDestination) } exists in the MapperContainer.");

            TypeTuple typeTuple = new TypeTuple
            {
                SourceType = typeof(TSource),
                DestinationType = typeof(TDestination)
            };

            AddMapperToList(typeTuple);
        }

        public static void AddMapperToList(TypeTuple mapper)
        {
            typeTupleList.Add(mapper);
        }

        public static IList<TypeTuple> GetMapper()
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
