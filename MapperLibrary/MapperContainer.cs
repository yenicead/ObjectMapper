using System;
using System.Collections.Generic;

namespace MapperLibrary
{
    public static class MapperContainer
    {
        private static readonly IList<TypeTuples> typeTupleList = new List<TypeTuples>();

        public static void Assign<TSource, TDestination>()
            where TSource: class
            where TDestination: class
        {
            TypeTuples typeTuples = new TypeTuples
            {
                SourceType = typeof(TSource),
                DestinationType = typeof(TDestination)
            };

            AddMapperToList(typeTuples);
        }

        public static void AddMapperToList(TypeTuples mapper)
        {
            typeTupleList.Add(mapper);
        }

        public static IList<TypeTuples> GetMapper()
        {
            return typeTupleList;
        }
    }

    public class TypeTuples 
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
    }
}
